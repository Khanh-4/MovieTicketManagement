using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class SeatDAL
    {
        // Lấy tất cả ghế của phòng
        public List<SeatDTO> GetByRoomId(int roomId)
        {
            List<SeatDTO> seats = new List<SeatDTO>();
            string query = @"SELECT s.*, st.TypeName, st.PriceMultiplier 
                            FROM SEATS s
                            INNER JOIN SEAT_TYPES st ON s.SeatTypeID = st.SeatTypeID
                            WHERE s.RoomID = @RoomID AND s.IsActive = 1
                            ORDER BY s.RowLabel, s.SeatNumber";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    seats.Add(new SeatDTO
                    {
                        SeatID = Convert.ToInt32(reader["SeatID"]),
                        RoomID = Convert.ToInt32(reader["RoomID"]),
                        SeatTypeID = Convert.ToInt32(reader["SeatTypeID"]),
                        RowNumber = reader["RowLabel"].ToString(),
                        SeatNumber = Convert.ToInt32(reader["SeatNumber"]),
                        SeatCode = reader["RowLabel"].ToString() + reader["SeatNumber"].ToString(),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        TypeName = reader["TypeName"].ToString(),
                        PriceMultiplier = Convert.ToDecimal(reader["PriceMultiplier"])
                    });
                }
            }
            return seats;
        }

        // Lấy danh sách ghế đã đặt của suất chiếu
        public List<int> GetBookedSeatIds(int showtimeId)
        {
            List<int> bookedSeatIds = new List<int>();
            string query = @"SELECT bd.SeatID 
                            FROM BOOKING_DETAILS bd
                            INNER JOIN BOOKINGS b ON bd.BookingID = b.BookingID
                            WHERE b.ShowtimeID = @ShowtimeID 
                            AND b.BookingStatus != N'Đã hủy'";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShowtimeID", showtimeId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bookedSeatIds.Add(Convert.ToInt32(reader["SeatID"]));
                }
            }
            return bookedSeatIds;
        }

        // Lấy ghế theo ID
        public SeatDTO GetById(int seatId)
        {
            SeatDTO seat = null;
            string query = @"SELECT s.*, st.TypeName, st.PriceMultiplier 
                            FROM SEATS s
                            INNER JOIN SEAT_TYPES st ON s.SeatTypeID = st.SeatTypeID
                            WHERE s.SeatID = @SeatID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SeatID", seatId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    seat = new SeatDTO
                    {
                        SeatID = Convert.ToInt32(reader["SeatID"]),
                        RoomID = Convert.ToInt32(reader["RoomID"]),
                        SeatTypeID = Convert.ToInt32(reader["SeatTypeID"]),
                        RowNumber = reader["RowLabel"].ToString(),
                        SeatNumber = Convert.ToInt32(reader["SeatNumber"]),
                        SeatCode = reader["RowLabel"].ToString() + reader["SeatNumber"].ToString(),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        TypeName = reader["TypeName"].ToString(),
                        PriceMultiplier = Convert.ToDecimal(reader["PriceMultiplier"])
                    };
                }
            }
            return seat;
        }
    }
}