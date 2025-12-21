using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class ShowtimeDAL
    {
        // Lấy tất cả suất chiếu
        public List<ShowtimeDTO> GetAll()
        {
            List<ShowtimeDTO> showtimes = new List<ShowtimeDTO>();
            string query = @"SELECT s.*, m.Title as MovieTitle, r.RoomName 
                            FROM SHOWTIMES s
                            INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                            INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                            ORDER BY s.StartTime DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    showtimes.Add(MapToDTO(reader));
                }
            }
            return showtimes;
        }

        // Lấy suất chiếu theo phim
        public List<ShowtimeDTO> GetByMovieId(int movieId)
        {
            List<ShowtimeDTO> showtimes = new List<ShowtimeDTO>();
            string query = @"SELECT s.*, m.Title as MovieTitle, r.RoomName 
                            FROM SHOWTIMES s
                            INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                            INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                            WHERE s.MovieID = @MovieID 
                            AND s.StartTime >= GETDATE()
                            AND s.IsActive = 1
                            ORDER BY s.StartTime";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieID", movieId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    showtimes.Add(MapToDTO(reader));
                }
            }
            return showtimes;
        }

        // Lấy suất chiếu theo ID
        public ShowtimeDTO GetById(int showtimeId)
        {
            ShowtimeDTO showtime = null;
            string query = @"SELECT s.*, m.Title as MovieTitle, r.RoomName 
                            FROM SHOWTIMES s
                            INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                            INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                            WHERE s.ShowtimeID = @ShowtimeID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShowtimeID", showtimeId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    showtime = MapToDTO(reader);
                }
            }
            return showtime;
        }


        // Lấy suất chiếu theo ngày
        public List<ShowtimeDTO> GetByDate(DateTime date)
        {
            List<ShowtimeDTO> showtimes = new List<ShowtimeDTO>();
            string query = @"SELECT s.*, m.Title as MovieTitle, r.RoomName 
                    FROM SHOWTIMES s
                    INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                    INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                    WHERE CAST(s.StartTime AS DATE) = @Date
                    AND s.IsActive = 1
                    ORDER BY s.StartTime";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", date.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    showtimes.Add(MapToDTO(reader));
                }
            }
            return showtimes;
        }

        // Thêm suất chiếu mới
        public int Insert(ShowtimeDTO showtime)
        {
            string query = @"INSERT INTO SHOWTIMES (MovieID, RoomID, StartTime, EndTime, BasePrice, IsActive)
                            VALUES (@MovieID, @RoomID, @StartTime, @EndTime, @BasePrice, @IsActive);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieID", showtime.MovieID);
                cmd.Parameters.AddWithValue("@RoomID", showtime.RoomID);
                cmd.Parameters.AddWithValue("@StartTime", showtime.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", showtime.EndTime);
                cmd.Parameters.AddWithValue("@BasePrice", showtime.BasePrice);
                cmd.Parameters.AddWithValue("@IsActive", showtime.IsActive);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Cập nhật suất chiếu
        public bool Update(ShowtimeDTO showtime)
        {
            string query = @"UPDATE SHOWTIMES SET 
                            MovieID = @MovieID,
                            RoomID = @RoomID,
                            StartTime = @StartTime,
                            EndTime = @EndTime,
                            BasePrice = @BasePrice,
                            IsActive = @IsActive
                            WHERE ShowtimeID = @ShowtimeID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShowtimeID", showtime.ShowtimeID);
                cmd.Parameters.AddWithValue("@MovieID", showtime.MovieID);
                cmd.Parameters.AddWithValue("@RoomID", showtime.RoomID);
                cmd.Parameters.AddWithValue("@StartTime", showtime.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", showtime.EndTime);
                cmd.Parameters.AddWithValue("@BasePrice", showtime.BasePrice);
                cmd.Parameters.AddWithValue("@IsActive", showtime.IsActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa suất chiếu (soft delete)
        public bool Delete(int showtimeId)
        {
            string query = "UPDATE SHOWTIMES SET IsActive = 0 WHERE ShowtimeID = @ShowtimeID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ShowtimeID", showtimeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra trùng lịch chiếu
        public bool CheckConflict(int roomId, DateTime startTime, DateTime endTime, int excludeShowtimeId = 0)
        {
            string query = @"SELECT COUNT(*) FROM SHOWTIMES 
                            WHERE RoomID = @RoomID 
                            AND IsActive = 1
                            AND ShowtimeID != @ExcludeID
                            AND ((StartTime <= @StartTime AND EndTime > @StartTime)
                                OR (StartTime < @EndTime AND EndTime >= @EndTime)
                                OR (StartTime >= @StartTime AND EndTime <= @EndTime))";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@EndTime", endTime);
                cmd.Parameters.AddWithValue("@ExcludeID", excludeShowtimeId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private ShowtimeDTO MapToDTO(SqlDataReader reader)
        {
            return new ShowtimeDTO
            {
                ShowtimeID = Convert.ToInt32(reader["ShowtimeID"]),
                MovieID = Convert.ToInt32(reader["MovieID"]),
                RoomID = Convert.ToInt32(reader["RoomID"]),
                StartTime = Convert.ToDateTime(reader["StartTime"]),
                EndTime = Convert.ToDateTime(reader["EndTime"]),
                BasePrice = Convert.ToDecimal(reader["BasePrice"]),
                IsActive = Convert.ToBoolean(reader["IsActive"]),
                MovieTitle = reader["MovieTitle"]?.ToString(),
                RoomName = reader["RoomName"]?.ToString()
            };
        }
    }
}