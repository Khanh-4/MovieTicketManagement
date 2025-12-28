using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class ResaleDAL
    {
        // Tính toán hoàn tiền
        public RefundCalculationDTO CalculateRefund(int bookingId)
        {
            RefundCalculationDTO result = new RefundCalculationDTO { BookingID = bookingId };

            string query = @"
                SELECT b.BookingID, b.BookingCode, b.TotalAmount, b.BookingStatus,
                       ISNULL(b.IsResold, 0) as IsResold,
                       s.StartTime, m.Title as MovieTitle, r.RoomName
                FROM BOOKINGS b
                INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                WHERE b.BookingID = @BookingID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.BookingCode = reader["BookingCode"].ToString();
                    result.OriginalPrice = Convert.ToDecimal(reader["TotalAmount"]);
                    result.ShowTime = Convert.ToDateTime(reader["StartTime"]);
                    result.MovieTitle = reader["MovieTitle"].ToString();
                    result.RoomName = reader["RoomName"].ToString();

                    string status = reader["BookingStatus"].ToString();
                    bool isResold = Convert.ToBoolean(reader["IsResold"]);

                    // Tính số ngày còn lại
                    result.DaysRemaining = (int)(result.ShowTime.Date - DateTime.Now.Date).TotalDays;

                    // Kiểm tra điều kiện
                    if (status != "Confirmed")
                    {
                        result.CanResale = false;
                        result.Message = "Chỉ có thể pass vé đã xác nhận!";
                    }
                    else if (isResold)
                    {
                        result.CanResale = false;
                        result.Message = "Vé này đã được pass trước đó!";
                    }
                    else if (result.DaysRemaining < 0)
                    {
                        result.CanResale = false;
                        result.Message = "Vé đã quá hạn!";
                    }
                    else if (result.DaysRemaining == 0)
                    {
                        result.CanResale = false;
                        result.Message = "Không thể pass vé trong ngày chiếu!";
                    }
                    else
                    {
                        result.CanResale = true;

                        // Tính % hoàn tiền
                        if (result.DaysRemaining >= 3)
                            result.RefundPercent = 70;
                        else if (result.DaysRemaining >= 2)
                            result.RefundPercent = 50;
                        else
                            result.RefundPercent = 30;

                        result.RefundAmount = result.OriginalPrice * result.RefundPercent / 100;
                        result.ResalePrice = result.OriginalPrice * 0.85m; // Giảm 15%
                        result.Message = $"Có thể pass vé. Hoàn tiền: {result.RefundPercent}%";
                    }
                }
                else
                {
                    result.CanResale = false;
                    result.Message = "Không tìm thấy booking!";
                }
            }

            // Lấy thông tin ghế
            if (result.CanResale)
            {
                result.SeatInfo = GetSeatInfo(bookingId);
            }

            return result;
        }

        // Lấy thông tin ghế của booking
        public string GetSeatInfo(int bookingId)
        {
            List<string> seats = new List<string>();
            string query = @"SELECT se.RowLabel, se.SeatNumber
                            FROM BOOKING_DETAILS bd
                            INNER JOIN SEATS se ON bd.SeatID = se.SeatID
                            WHERE bd.BookingID = @BookingID
                            ORDER BY se.RowLabel, se.SeatNumber";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    seats.Add($"{reader["RowLabel"]}{reader["SeatNumber"]}");
                }
            }
            return string.Join(", ", seats);
        }

        // Tạo vé pass (gọi stored procedure)
        public (bool success, string message, int resaleId) CreateResale(int bookingId, string refundMethod, string notes = null)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_ProcessTicketResale", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Parameters.AddWithValue("@RefundMethod", refundMethod);
                cmd.Parameters.AddWithValue("@Notes", notes ?? (object)DBNull.Value);

                SqlParameter resaleIdParam = new SqlParameter("@ResaleID", SqlDbType.Int);
                resaleIdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(resaleIdParam);

                SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 255);
                messageParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(messageParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                int resaleId = resaleIdParam.Value != DBNull.Value ? Convert.ToInt32(resaleIdParam.Value) : 0;
                string message = messageParam.Value?.ToString() ?? "Lỗi không xác định";

                return (resaleId > 0, message, resaleId);
            }
        }

        // Lấy danh sách vé pass đang bán
        public List<TicketResaleDTO> GetAvailableResales()
        {
            List<TicketResaleDTO> resales = new List<TicketResaleDTO>();
            string query = @"
                SELECT r.*, b.BookingCode, m.Title as MovieTitle, rm.RoomName, 
                       s.StartTime as ShowTime, u.FullName as SellerName
                FROM TICKET_RESALES r
                INNER JOIN BOOKINGS b ON r.BookingID = b.BookingID
                INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                INNER JOIN ROOMS rm ON s.RoomID = rm.RoomID
                INNER JOIN USERS u ON r.SellerUserID = u.UserID
                WHERE r.Status = 'Available' AND r.ExpiredAt > GETDATE()
                ORDER BY r.ExpiredAt ASC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var resale = MapToDTO(reader);
                    resales.Add(resale);
                }
            }

            // Lấy thông tin ghế cho từng vé
            foreach (var resale in resales)
            {
                resale.SeatInfo = GetSeatInfo(resale.BookingID);
            }

            return resales;
        }

        // Lấy vé pass theo ID
        public TicketResaleDTO GetById(int resaleId)
        {
            TicketResaleDTO resale = null;
            string query = @"
                SELECT r.*, b.BookingCode, m.Title as MovieTitle, rm.RoomName, 
                       s.StartTime as ShowTime, 
                       seller.FullName as SellerName,
                       buyer.FullName as BuyerName
                FROM TICKET_RESALES r
                INNER JOIN BOOKINGS b ON r.BookingID = b.BookingID
                INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                INNER JOIN ROOMS rm ON s.RoomID = rm.RoomID
                INNER JOIN USERS seller ON r.SellerUserID = seller.UserID
                LEFT JOIN USERS buyer ON r.BuyerUserID = buyer.UserID
                WHERE r.ResaleID = @ResaleID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ResaleID", resaleId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resale = MapToDTO(reader);
                    resale.SeatInfo = GetSeatInfo(resale.BookingID);

                    if (reader["BuyerName"] != DBNull.Value)
                        resale.BuyerName = reader["BuyerName"].ToString();
                }
            }
            return resale;
        }

        // Mua vé pass (gọi stored procedure)
        public (bool success, string message, int newBookingId) BuyResale(int resaleId, int buyerUserId, string paymentMethod)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_BuyResaleTicket", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ResaleID", resaleId);
                cmd.Parameters.AddWithValue("@BuyerUserID", buyerUserId);
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                SqlParameter newBookingIdParam = new SqlParameter("@NewBookingID", SqlDbType.Int);
                newBookingIdParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(newBookingIdParam);

                SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 255);
                messageParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(messageParam);

                conn.Open();
                cmd.ExecuteNonQuery();

                int newBookingId = newBookingIdParam.Value != DBNull.Value ? Convert.ToInt32(newBookingIdParam.Value) : 0;
                string message = messageParam.Value?.ToString() ?? "Lỗi không xác định";

                return (newBookingId > 0, message, newBookingId);
            }
        }

        // Lấy danh sách vé đã pass của user
        public List<TicketResaleDTO> GetBySellerUserId(int userId)
        {
            List<TicketResaleDTO> resales = new List<TicketResaleDTO>();
            string query = @"
                SELECT r.*, b.BookingCode, m.Title as MovieTitle, rm.RoomName, 
                       s.StartTime as ShowTime, u.FullName as SellerName
                FROM TICKET_RESALES r
                INNER JOIN BOOKINGS b ON r.BookingID = b.BookingID
                INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                INNER JOIN ROOMS rm ON s.RoomID = rm.RoomID
                INNER JOIN USERS u ON r.SellerUserID = u.UserID
                WHERE r.SellerUserID = @UserID
                ORDER BY r.CreatedAt DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var resale = MapToDTO(reader);
                    resales.Add(resale);
                }
            }

            foreach (var resale in resales)
            {
                resale.SeatInfo = GetSeatInfo(resale.BookingID);
            }

            return resales;
        }

        // Cập nhật vé hết hạn
        public int UpdateExpiredResales()
        {
            string query = @"UPDATE TICKET_RESALES 
                            SET Status = 'Expired' 
                            WHERE Status = 'Available' AND ExpiredAt <= GETDATE()";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Map reader to DTO
        private TicketResaleDTO MapToDTO(SqlDataReader reader)
        {
            return new TicketResaleDTO
            {
                ResaleID = Convert.ToInt32(reader["ResaleID"]),
                BookingID = Convert.ToInt32(reader["BookingID"]),
                SellerUserID = Convert.ToInt32(reader["SellerUserID"]),
                OriginalPrice = Convert.ToDecimal(reader["OriginalPrice"]),
                RefundPercent = Convert.ToDecimal(reader["RefundPercent"]),
                RefundAmount = Convert.ToDecimal(reader["RefundAmount"]),
                ResalePrice = Convert.ToDecimal(reader["ResalePrice"]),
                RefundMethod = reader["RefundMethod"].ToString(),
                Status = reader["Status"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                ExpiredAt = Convert.ToDateTime(reader["ExpiredAt"]),
                BuyerUserID = reader["BuyerUserID"] != DBNull.Value ? Convert.ToInt32(reader["BuyerUserID"]) : (int?)null,
                NewBookingID = reader["NewBookingID"] != DBNull.Value ? Convert.ToInt32(reader["NewBookingID"]) : (int?)null,
                SoldAt = reader["SoldAt"] != DBNull.Value ? Convert.ToDateTime(reader["SoldAt"]) : (DateTime?)null,
                Notes = reader["Notes"] != DBNull.Value ? reader["Notes"].ToString() : null,
                BookingCode = reader["BookingCode"] != DBNull.Value ? reader["BookingCode"].ToString() : null,
                MovieTitle = reader["MovieTitle"] != DBNull.Value ? reader["MovieTitle"].ToString() : null,
                RoomName = reader["RoomName"] != DBNull.Value ? reader["RoomName"].ToString() : null,
                ShowTime = reader["ShowTime"] != DBNull.Value ? Convert.ToDateTime(reader["ShowTime"]) : DateTime.MinValue,
                SellerName = reader["SellerName"] != DBNull.Value ? reader["SellerName"].ToString() : null
            };
        }
    }
}