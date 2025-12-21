using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class MovieDAL
    {
        // Lấy tất cả phim
        public List<MovieDTO> GetAll()
        {
            List<MovieDTO> movies = new List<MovieDTO>();
            string query = @"SELECT m.*, 
                            (SELECT STRING_AGG(g.GenreName, ', ') 
                             FROM MOVIE_GENRES mg 
                             JOIN GENRES g ON mg.GenreID = g.GenreID 
                             WHERE mg.MovieID = m.MovieID) AS Genres
                            FROM MOVIES m
                            ORDER BY m.MovieID DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(MapToDTO(reader));
                }
            }
            return movies;
        }

        // Lấy phim theo ID
        public MovieDTO GetById(int movieId)
        {
            MovieDTO movie = null;
            string query = @"SELECT m.*, 
                            (SELECT STRING_AGG(g.GenreName, ', ') 
                             FROM MOVIE_GENRES mg 
                             JOIN GENRES g ON mg.GenreID = g.GenreID 
                             WHERE mg.MovieID = m.MovieID) AS Genres
                            FROM MOVIES m
                            WHERE m.MovieID = @MovieID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieID", movieId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    movie = MapToDTO(reader);
                }
            }
            return movie;
        }

        // Lấy phim đang chiếu
        public List<MovieDTO> GetNowShowing()
        {
            List<MovieDTO> movies = new List<MovieDTO>();
            string query = @"SELECT DISTINCT m.*, 
                            (SELECT STRING_AGG(g.GenreName, ', ') 
                             FROM MOVIE_GENRES mg 
                             JOIN GENRES g ON mg.GenreID = g.GenreID 
                             WHERE mg.MovieID = m.MovieID) AS Genres
                            FROM MOVIES m
                            INNER JOIN SHOWTIMES s ON m.MovieID = s.MovieID
                            WHERE s.StartTime >= GETDATE() AND s.IsActive = 1 AND m.IsActive = 1
                            ORDER BY m.IsTrending DESC, m.Title";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(MapToDTO(reader));
                }
            }
            return movies;
        }

        // Tìm kiếm phim
        public List<MovieDTO> Search(string keyword)
        {
            List<MovieDTO> movies = new List<MovieDTO>();
            string query = @"SELECT m.*, 
                            (SELECT STRING_AGG(g.GenreName, ', ') 
                             FROM MOVIE_GENRES mg 
                             JOIN GENRES g ON mg.GenreID = g.GenreID 
                             WHERE mg.MovieID = m.MovieID) AS Genres
                            FROM MOVIES m
                            WHERE m.Title LIKE @Keyword 
                               OR m.Director LIKE @Keyword 
                               OR m.Actors LIKE @Keyword
                            ORDER BY m.MovieID DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    movies.Add(MapToDTO(reader));
                }
            }
            return movies;
        }

        // Thêm phim mới
        public int Insert(MovieDTO movie)
        {
            string query = @"INSERT INTO MOVIES (Title, Description, Duration, Director, Actors, 
                            ReleaseDate, PosterURL, TrailerURL, Country, AgeRating, IsActive, IsTrending)
                            VALUES (@Title, @Description, @Duration, @Director, @Actors,
                            @ReleaseDate, @PosterURL, @TrailerURL, @Country, @AgeRating, @IsActive, @IsTrending);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Description", (object)movie.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                cmd.Parameters.AddWithValue("@Director", (object)movie.Director ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Actors", (object)movie.Actors ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReleaseDate", (object)movie.ReleaseDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PosterURL", (object)movie.PosterURL ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrailerURL", (object)movie.TrailerURL ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Country", (object)movie.Country ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AgeRating", movie.AgeRating);
                cmd.Parameters.AddWithValue("@IsActive", movie.IsActive);
                cmd.Parameters.AddWithValue("@IsTrending", movie.IsTrending);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Cập nhật phim
        public bool Update(MovieDTO movie)
        {
            string query = @"UPDATE MOVIES SET 
                            Title = @Title,
                            Description = @Description,
                            Duration = @Duration,
                            Director = @Director,
                            Actors = @Actors,
                            ReleaseDate = @ReleaseDate,
                            PosterURL = @PosterURL,
                            TrailerURL = @TrailerURL,
                            Country = @Country,
                            AgeRating = @AgeRating,
                            IsActive = @IsActive,
                            IsTrending = @IsTrending
                            WHERE MovieID = @MovieID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieID", movie.MovieID);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Description", (object)movie.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                cmd.Parameters.AddWithValue("@Director", (object)movie.Director ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Actors", (object)movie.Actors ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ReleaseDate", (object)movie.ReleaseDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PosterURL", (object)movie.PosterURL ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrailerURL", (object)movie.TrailerURL ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Country", (object)movie.Country ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AgeRating", movie.AgeRating);
                cmd.Parameters.AddWithValue("@IsActive", movie.IsActive);
                cmd.Parameters.AddWithValue("@IsTrending", movie.IsTrending);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Xóa phim (soft delete)
        public bool Delete(int movieId)
        {
            string query = "UPDATE MOVIES SET IsActive = 0 WHERE MovieID = @MovieID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieID", movieId);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Map từ DataReader sang DTO
        private MovieDTO MapToDTO(SqlDataReader reader)
        {
            return new MovieDTO
            {
                MovieID = Convert.ToInt32(reader["MovieID"]),
                Title = reader["Title"].ToString(),
                Description = reader["Description"]?.ToString(),
                Duration = Convert.ToInt32(reader["Duration"]),
                Director = reader["Director"]?.ToString(),
                Actors = reader["Actors"]?.ToString(),
                ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? null : (DateTime?)reader["ReleaseDate"],
                PosterURL = reader["PosterURL"]?.ToString(),
                TrailerURL = reader["TrailerURL"]?.ToString(),
                Country = reader["Country"]?.ToString(),
                AgeRating = Convert.ToInt32(reader["AgeRating"]),
                IsActive = Convert.ToBoolean(reader["IsActive"]),
                IsTrending = Convert.ToBoolean(reader["IsTrending"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                Genres = reader["Genres"]?.ToString()
            };
        }
    }
}