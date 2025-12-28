using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class BookingDAL
    {
        // Tạo booking mới
        public int Insert(BookingDTO booking)
        {
            string query = @"INSERT INTO BOOKINGS (BookingCode, UserID, ShowtimeID, TotalAmount, 
                    FinalAmount, BookingStatus, PaymentStatus, PaymentMethod, BookingTime)
                    VALUES (@BookingCode, @UserID, @ShowtimeID, @TotalAmount,
                    @FinalAmount, @BookingStatus, @PaymentStatus, @PaymentMethod, @BookingTime);
                    SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingCode", booking.BookingCode);
                cmd.Parameters.AddWithValue("@UserID", booking.UserID);
                cmd.Parameters.AddWithValue("@ShowtimeID", booking.ShowtimeID);
                cmd.Parameters.AddWithValue("@TotalAmount", booking.TotalAmount);
                cmd.Parameters.AddWithValue("@FinalAmount", booking.TotalAmount);
                cmd.Parameters.AddWithValue("@BookingStatus", booking.BookingStatus);
                cmd.Parameters.AddWithValue("@PaymentStatus", booking.PaymentStatus ?? "Đã thanh toán");
                cmd.Parameters.AddWithValue("@PaymentMethod", (object)booking.PaymentMethod ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@BookingTime", booking.BookingTime);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Thêm chi tiết booking (ghế)
        public bool InsertBookingDetail(int bookingId, int seatId, decimal price)
        {
            string query = @"INSERT INTO BOOKING_DETAILS (BookingID, SeatID, Price)
                            VALUES (@BookingID, @SeatID, @Price)";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Parameters.AddWithValue("@SeatID", seatId);
                cmd.Parameters.AddWithValue("@Price", price);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // === MỚI: Thêm đồ ăn vào booking ===
        public bool InsertBookingFood(int bookingId, int foodId, int quantity, decimal unitPrice)
        {
            string query = @"INSERT INTO BOOKING_FOODS (BookingID, FoodID, Quantity, UnitPrice, TotalPrice)
                            VALUES (@BookingID, @FoodID, @Quantity, @UnitPrice, @TotalPrice)";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Parameters.AddWithValue("@FoodID", foodId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@TotalPrice", unitPrice * quantity);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // === MỚI: Cập nhật tổng tiền booking (sau khi thêm đồ ăn) ===
        public bool UpdateTotalAmount(int bookingId, decimal totalAmount)
        {
            string query = @"UPDATE BOOKINGS 
                            SET TotalAmount = @TotalAmount, FinalAmount = @TotalAmount 
                            WHERE BookingID = @BookingID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sinh mã booking
        public string GenerateBookingCode()
        {
            return "BK" + DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(100, 999);
        }

        // Lấy lịch sử đặt vé của user
        public List<BookingDTO> GetByUserId(int userId)
        {
            List<BookingDTO> bookings = new List<BookingDTO>();
            string query = @"SELECT b.*, s.StartTime, m.Title as MovieTitle, r.RoomName,
                            u.FullName as CustomerName
                            FROM BOOKINGS b
                            INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                            INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                            INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                            INNER JOIN USERS u ON b.UserID = u.UserID
                            WHERE b.UserID = @UserID
                            ORDER BY b.BookingTime DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bookings.Add(MapToDTO(reader));
                }
            }
            return bookings;
        }

        // Lấy booking theo ID
        public BookingDTO GetById(int bookingId)
        {
            BookingDTO booking = null;
            string query = @"SELECT b.*, s.StartTime, m.Title as MovieTitle, r.RoomName,
                            u.FullName as CustomerName
                            FROM BOOKINGS b
                            INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                            INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                            INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                            INNER JOIN USERS u ON b.UserID = u.UserID
                            WHERE b.BookingID = @BookingID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    booking = MapToDTO(reader);
                }
            }
            return booking;
        }

        // Lấy chi tiết ghế của booking
        public List<BookingDetailDTO> GetBookingDetails(int bookingId)
        {
            List<BookingDetailDTO> details = new List<BookingDetailDTO>();
            string query = @"SELECT bd.*, (s.RowLabel + CAST(s.SeatNumber AS NVARCHAR)) AS SeatCode 
                FROM BOOKING_DETAILS bd
                INNER JOIN SEATS s ON bd.SeatID = s.SeatID
                WHERE bd.BookingID = @BookingID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    details.Add(new BookingDetailDTO
                    {
                        BookingDetailID = Convert.ToInt32(reader["BookingDetailID"]),
                        BookingID = Convert.ToInt32(reader["BookingID"]),
                        SeatID = Convert.ToInt32(reader["SeatID"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        SeatCode = reader["SeatCode"].ToString()
                    });
                }
            }
            return details;
        }

        // === MỚI: Lấy danh sách đồ ăn của booking ===
        public List<TicketFoodItem> GetBookingFoods(int bookingId)
        {
            List<TicketFoodItem> foods = new List<TicketFoodItem>();
            string query = @"SELECT bf.FoodID, f.FoodName, bf.Quantity, bf.UnitPrice, bf.TotalPrice
                            FROM BOOKING_FOODS bf
                            INNER JOIN FOODS f ON bf.FoodID = f.FoodID
                            WHERE bf.BookingID = @BookingID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foods.Add(new TicketFoodItem
                    {
                        FoodID = Convert.ToInt32(reader["FoodID"]),
                        FoodName = reader["FoodName"].ToString(),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                        TotalPrice = Convert.ToDecimal(reader["TotalPrice"])
                    });
                }
            }
            return foods;
        }

        private BookingDTO MapToDTO(SqlDataReader reader)
        {
            var booking = new BookingDTO
            {
                BookingID = Convert.ToInt32(reader["BookingID"]),
                BookingCode = reader["BookingCode"].ToString(),
                UserID = Convert.ToInt32(reader["UserID"]),
                ShowtimeID = Convert.ToInt32(reader["ShowtimeID"]),
                TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                BookingStatus = reader["BookingStatus"].ToString(),
                PaymentStatus = reader["PaymentStatus"].ToString(),
                PaymentMethod = reader["PaymentMethod"]?.ToString(),
                BookingTime = Convert.ToDateTime(reader["BookingTime"]),
                MovieTitle = reader["MovieTitle"]?.ToString(),
                RoomName = reader["RoomName"]?.ToString(),
                CustomerName = reader["CustomerName"]?.ToString(),
                ShowTime = Convert.ToDateTime(reader["StartTime"])
            };

            try
            {
                int isUsedOrdinal = reader.GetOrdinal("IsUsed");
                booking.IsUsed = reader["IsUsed"] != DBNull.Value && Convert.ToBoolean(reader["IsUsed"]);
            }
            catch { booking.IsUsed = false; }

            try
            {
                int usedAtOrdinal = reader.GetOrdinal("UsedAt");
                booking.UsedAt = reader["UsedAt"] != DBNull.Value ? Convert.ToDateTime(reader["UsedAt"]) : (DateTime?)null;
            }
            catch { booking.UsedAt = null; }

            return booking;
        }

        // Hủy booking
        public bool CancelBooking(int bookingId)
        {
            string query = @"UPDATE BOOKINGS 
                    SET BookingStatus = 'Cancelled' 
                    WHERE BookingID = @BookingID 
                    AND BookingStatus IN ('Pending', 'Confirmed')";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra có thể hủy vé không
        public bool CanCancelBooking(int bookingId)
        {
            string query = @"SELECT s.StartTime, b.BookingStatus
                    FROM BOOKINGS b
                    INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                    WHERE b.BookingID = @BookingID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime startTime = Convert.ToDateTime(reader["StartTime"]);
                    string status = reader["BookingStatus"].ToString();

                    bool validStatus = status == "Pending" || status == "Confirmed";
                    bool validTime = startTime > DateTime.Now.AddHours(2);

                    return validStatus && validTime;
                }
            }
            return false;
        }

        // Lấy thông tin vé để in - CẬP NHẬT: Bao gồm đồ ăn
        public TicketDTO GetTicketInfo(int bookingId)
        {
            TicketDTO ticket = null;
            string query = @"SELECT b.BookingID, b.BookingCode, m.Title as MovieTitle, 
                            r.RoomName, s.StartTime,
                            b.TotalAmount, u.FullName as CustomerName, u.Phone as CustomerPhone,
                            b.BookingTime, b.BookingStatus as Status
                     FROM BOOKINGS b
                     INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                     INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                     INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                     INNER JOIN USERS u ON b.UserID = u.UserID
                     WHERE b.BookingID = @BookingID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime startTime = Convert.ToDateTime(reader["StartTime"]);

                    ticket = new TicketDTO
                    {
                        BookingID = Convert.ToInt32(reader["BookingID"]),
                        BookingCode = reader["BookingCode"].ToString(),
                        MovieTitle = reader["MovieTitle"].ToString(),
                        RoomName = reader["RoomName"].ToString(),
                        ShowDate = startTime.Date,
                        ShowTime = startTime.TimeOfDay,
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        CustomerName = reader["CustomerName"].ToString(),
                        CustomerPhone = reader["CustomerPhone"]?.ToString(),
                        BookingDate = Convert.ToDateTime(reader["BookingTime"]),
                        Status = reader["Status"].ToString()
                    };
                }
            }

            if (ticket != null)
            {
                // Lấy thông tin ghế và tính tiền vé
                decimal ticketAmount = 0;
                string seatQuery = @"SELECT se.RowLabel, se.SeatNumber, bd.Price
                             FROM BOOKING_DETAILS bd
                             INNER JOIN SEATS se ON bd.SeatID = se.SeatID
                             WHERE bd.BookingID = @BookingID
                             ORDER BY se.RowLabel, se.SeatNumber";

                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(seatQuery, conn);
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> seats = new List<string>();
                    while (reader.Read())
                    {
                        seats.Add($"{reader["RowLabel"]}{reader["SeatNumber"]}");
                        ticketAmount += Convert.ToDecimal(reader["Price"]);
                    }
                    ticket.SeatInfo = string.Join(", ", seats);
                    ticket.TicketAmount = ticketAmount;
                }

                // === MỚI: Lấy thông tin đồ ăn ===
                ticket.FoodItems = GetBookingFoods(bookingId);
                ticket.FoodAmount = 0;
                foreach (var food in ticket.FoodItems)
                {
                    ticket.FoodAmount += food.TotalPrice;
                }
            }

            return ticket;
        }

        // Lấy booking theo mã vé
        public BookingDTO GetByBookingCode(string bookingCode)
        {
            BookingDTO booking = null;
            string query = @"SELECT b.*, s.StartTime, m.Title as MovieTitle, r.RoomName,
                    u.FullName as CustomerName
                    FROM BOOKINGS b
                    INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                    INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                    INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                    INNER JOIN USERS u ON b.UserID = u.UserID
                    WHERE b.BookingCode = @BookingCode";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingCode", bookingCode);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    booking = MapToDTO(reader);
                }
            }
            return booking;
        }

        // Đánh dấu vé đã sử dụng
        public bool MarkAsUsed(int bookingId)
        {
            string query = @"UPDATE BOOKINGS 
                    SET IsUsed = 1, UsedAt = @UsedAt 
                    WHERE BookingID = @BookingID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Parameters.AddWithValue("@UsedAt", DateTime.Now);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}