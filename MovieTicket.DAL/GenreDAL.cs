using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class GenreDAL
    {
        // Lấy tất cả thể loại
        public List<GenreDTO> GetAll()
        {
            List<GenreDTO> genres = new List<GenreDTO>();
            string query = "SELECT * FROM GENRES ORDER BY GenreName";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    genres.Add(new GenreDTO
                    {
                        GenreID = Convert.ToInt32(reader["GenreID"]),
                        GenreName = reader["GenreName"].ToString(),
                        Description = reader["Description"]?.ToString()
                    });
                }
            }
            return genres;
        }

        // Lấy thể loại của một phim
        public List<GenreDTO> GetByMovieId(int movieId)
        {
            List<GenreDTO> genres = new List<GenreDTO>();
            string query = @"SELECT g.* FROM GENRES g
                            INNER JOIN MOVIE_GENRES mg ON g.GenreID = mg.GenreID
                            WHERE mg.MovieID = @MovieID
                            ORDER BY g.GenreName";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieID", movieId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    genres.Add(new GenreDTO
                    {
                        GenreID = Convert.ToInt32(reader["GenreID"]),
                        GenreName = reader["GenreName"].ToString(),
                        Description = reader["Description"]?.ToString()
                    });
                }
            }
            return genres;
        }

        // Cập nhật thể loại cho phim
        public bool UpdateMovieGenres(int movieId, List<int> genreIds)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa các thể loại cũ
                    string deleteQuery = "DELETE FROM MOVIE_GENRES WHERE MovieID = @MovieID";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction);
                    deleteCmd.Parameters.AddWithValue("@MovieID", movieId);
                    deleteCmd.ExecuteNonQuery();

                    // Thêm các thể loại mới
                    foreach (int genreId in genreIds)
                    {
                        string insertQuery = "INSERT INTO MOVIE_GENRES (MovieID, GenreID) VALUES (@MovieID, @GenreID)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction);
                        insertCmd.Parameters.AddWithValue("@MovieID", movieId);
                        insertCmd.Parameters.AddWithValue("@GenreID", genreId);
                        insertCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}