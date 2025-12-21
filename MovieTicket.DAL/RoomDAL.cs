using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class RoomDAL
    {
        // Lấy tất cả phòng
        public List<RoomDTO> GetAll()
        {
            List<RoomDTO> rooms = new List<RoomDTO>();
            string query = "SELECT * FROM ROOMS ORDER BY RoomName";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rooms.Add(new RoomDTO
                    {
                        RoomID = Convert.ToInt32(reader["RoomID"]),
                        RoomName = reader["RoomName"].ToString(),
                        TotalSeats = Convert.ToInt32(reader["TotalSeats"]),
                        RoomType = reader["RoomType"]?.ToString(),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    });
                }
            }
            return rooms;
        }

        // Lấy phòng theo ID
        public RoomDTO GetById(int roomId)
        {
            RoomDTO room = null;
            string query = "SELECT * FROM ROOMS WHERE RoomID = @RoomID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    room = new RoomDTO
                    {
                        RoomID = Convert.ToInt32(reader["RoomID"]),
                        RoomName = reader["RoomName"].ToString(),
                        TotalSeats = Convert.ToInt32(reader["TotalSeats"]),
                        RoomType = reader["RoomType"]?.ToString(),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    };
                }
            }
            return room;
        }

        // Thêm phòng mới
        public int Insert(RoomDTO room)
        {
            string query = @"INSERT INTO ROOMS (RoomName, TotalSeats, RoomType, IsActive)
                            VALUES (@RoomName, @TotalSeats, @RoomType, @IsActive);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                cmd.Parameters.AddWithValue("@TotalSeats", room.TotalSeats);
                cmd.Parameters.AddWithValue("@RoomType", room.RoomType ?? "Standard");
                cmd.Parameters.AddWithValue("@IsActive", room.IsActive);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Cập nhật phòng
        public bool Update(RoomDTO room)
        {
            string query = @"UPDATE ROOMS 
                            SET RoomName = @RoomName, 
                                TotalSeats = @TotalSeats, 
                                RoomType = @RoomType, 
                                IsActive = @IsActive
                            WHERE RoomID = @RoomID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
                cmd.Parameters.AddWithValue("@RoomName", room.RoomName);
                cmd.Parameters.AddWithValue("@TotalSeats", room.TotalSeats);
                cmd.Parameters.AddWithValue("@RoomType", room.RoomType ?? "Standard");
                cmd.Parameters.AddWithValue("@IsActive", room.IsActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa phòng
        public bool Delete(int roomId)
        {
            string query = "DELETE FROM ROOMS WHERE RoomID = @RoomID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra phòng có lịch chiếu không
        public bool HasShowtimes(int roomId)
        {
            string query = "SELECT COUNT(*) FROM SHOWTIMES WHERE RoomID = @RoomID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Kiểm tra tên phòng đã tồn tại chưa
        public bool IsRoomNameExists(string roomName, int excludeRoomId = 0)
        {
            string query = "SELECT COUNT(*) FROM ROOMS WHERE RoomName = @RoomName AND RoomID != @ExcludeRoomID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomName", roomName);
                cmd.Parameters.AddWithValue("@ExcludeRoomID", excludeRoomId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Tạo ghế tự động cho phòng
        public bool GenerateSeats(int roomId, int rows, int seatsPerRow, int vipRowStart = 0)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Xóa ghế cũ của phòng (nếu có)
                    string deleteQuery = "DELETE FROM SEATS WHERE RoomID = @RoomID";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@RoomID", roomId);
                    deleteCmd.ExecuteNonQuery();

                    // Tạo ghế mới
                    string insertQuery = @"INSERT INTO SEATS (RoomID, RowLabel, SeatNumber, SeatTypeID, IsActive)
                                          VALUES (@RoomID, @RowLabel, @SeatNumber, @SeatTypeID, 1)";

                    for (int row = 0; row < rows; row++)
                    {
                        string rowLabel = ((char)('A' + row)).ToString(); // A, B, C, ...
                        int seatTypeId = (vipRowStart > 0 && row >= vipRowStart - 1) ? 2 : 1; // 1 = Thường, 2 = VIP

                        for (int seat = 1; seat <= seatsPerRow; seat++)
                        {
                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@RoomID", roomId);
                            insertCmd.Parameters.AddWithValue("@RowLabel", rowLabel);
                            insertCmd.Parameters.AddWithValue("@SeatNumber", seat);
                            insertCmd.Parameters.AddWithValue("@SeatTypeID", seatTypeId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    // Cập nhật tổng số ghế
                    string updateQuery = "UPDATE ROOMS SET TotalSeats = @TotalSeats WHERE RoomID = @RoomID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@TotalSeats", rows * seatsPerRow);
                    updateCmd.Parameters.AddWithValue("@RoomID", roomId);
                    updateCmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Lấy thông tin ghế của phòng (để hiển thị)
        public (int Rows, int SeatsPerRow, int VipRowStart) GetRoomSeatInfo(int roomId)
        {
            int rows = 0, seatsPerRow = 0, vipRowStart = 0;

            string query = @"SELECT 
                                COUNT(DISTINCT RowLabel) AS TotalRows,
                                MAX(SeatNumber) AS SeatsPerRow,
                                MIN(CASE WHEN SeatTypeID = 2 THEN ASCII(RowLabel) - 64 ELSE NULL END) AS VipRowStart
                            FROM SEATS 
                            WHERE RoomID = @RoomID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    rows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : 0;
                    seatsPerRow = reader["SeatsPerRow"] != DBNull.Value ? Convert.ToInt32(reader["SeatsPerRow"]) : 0;
                    vipRowStart = reader["VipRowStart"] != DBNull.Value ? Convert.ToInt32(reader["VipRowStart"]) : 0;
                }
            }

            return (rows, seatsPerRow, vipRowStart);
        }
    }
}