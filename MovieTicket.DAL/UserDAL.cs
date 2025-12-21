using Microsoft.Data.SqlClient;
using MovieTicket.DTO;
using System;
using System.Collections.Generic;

namespace MovieTicket.DAL
{
    public class UserDAL
    {
        // Lấy user theo Username
        public UserDTO GetByUsername(string username)
        {
            UserDTO user = null;
            string query = @"SELECT u.*, r.RoleName 
                            FROM USERS u 
                            INNER JOIN ROLES r ON u.RoleID = r.RoleID 
                            WHERE u.Username = @Username";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = MapToDTO(reader);
                }
            }
            return user;
        }

        // Lấy user theo Email
        public UserDTO GetByEmail(string email)
        {
            UserDTO user = null;
            string query = @"SELECT u.*, r.RoleName 
                            FROM USERS u 
                            INNER JOIN ROLES r ON u.RoleID = r.RoleID 
                            WHERE u.Email = @Email";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = MapToDTO(reader);
                }
            }
            return user;
        }

        // Lấy user theo ID
        public UserDTO GetById(int userId)
        {
            UserDTO user = null;
            string query = @"SELECT u.*, r.RoleName 
                            FROM USERS u 
                            INNER JOIN ROLES r ON u.RoleID = r.RoleID 
                            WHERE u.UserID = @UserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = MapToDTO(reader);
                }
            }
            return user;
        }

        // Lấy tất cả users
        public List<UserDTO> GetAll()
        {
            List<UserDTO> users = new List<UserDTO>();
            string query = @"SELECT u.*, r.RoleName 
                            FROM USERS u 
                            INNER JOIN ROLES r ON u.RoleID = r.RoleID 
                            ORDER BY u.UserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(MapToDTO(reader));
                }
            }
            return users;
        }

        // Lấy users theo Role
        public List<UserDTO> GetByRole(int roleId)
        {
            List<UserDTO> users = new List<UserDTO>();
            string query = @"SELECT u.*, r.RoleName 
                            FROM USERS u 
                            INNER JOIN ROLES r ON u.RoleID = r.RoleID 
                            WHERE u.RoleID = @RoleID
                            ORDER BY u.FullName";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoleID", roleId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(MapToDTO(reader));
                }
            }
            return users;
        }

        // Thêm user mới
        public int Insert(UserDTO user)
        {
            string query = @"INSERT INTO USERS (Username, PasswordHash, Salt, FullName, Email, Phone, RoleID, IsActive)
                            VALUES (@Username, @PasswordHash, @Salt, @FullName, @Email, @Phone, @RoleID, @IsActive);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@Salt", user.PasswordSalt ?? user.Salt);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object)user.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RoleID", user.RoleID);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Cập nhật thông tin user (không đổi mật khẩu)
        public bool Update(UserDTO user)
        {
            string query = @"UPDATE USERS 
                            SET FullName = @FullName, 
                                Email = @Email, 
                                Phone = @Phone, 
                                IsActive = @IsActive
                            WHERE UserID = @UserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object)user.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật mật khẩu
        public bool UpdatePassword(int userId, string newHash, string newSalt)
        {
            string query = @"UPDATE USERS 
                            SET PasswordHash = @PasswordHash, Salt = @Salt
                            WHERE UserID = @UserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@PasswordHash", newHash);
                cmd.Parameters.AddWithValue("@Salt", newSalt);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Reset mật khẩu (alias cho UpdatePassword)
        public bool ResetPassword(int userId, string newPasswordHash, string newSalt)
        {
            return UpdatePassword(userId, newPasswordHash, newSalt);
        }

        // Xóa user
        public bool Delete(int userId)
        {
            string query = "DELETE FROM USERS WHERE UserID = @UserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra username đã tồn tại chưa
        public bool IsUsernameExists(string username, int excludeUserId = 0)
        {
            string query = "SELECT COUNT(*) FROM USERS WHERE Username = @Username AND UserID != @ExcludeUserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@ExcludeUserID", excludeUserId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Kiểm tra email đã tồn tại chưa
        public bool IsEmailExists(string email, int excludeUserId = 0)
        {
            if (string.IsNullOrEmpty(email)) return false;

            string query = "SELECT COUNT(*) FROM USERS WHERE Email = @Email AND UserID != @ExcludeUserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@ExcludeUserID", excludeUserId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Kiểm tra user có booking không
        public bool HasBookings(int userId)
        {
            string query = "SELECT COUNT(*) FROM BOOKINGS WHERE UserID = @UserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Map từ SqlDataReader sang UserDTO
        private UserDTO MapToDTO(SqlDataReader reader)
        {
            return new UserDTO
            {
                UserID = Convert.ToInt32(reader["UserID"]),
                Username = reader["Username"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                PasswordSalt = reader["Salt"].ToString(),
                Salt = reader["Salt"].ToString(),
                FullName = reader["FullName"].ToString(),
                Email = reader["Email"]?.ToString(),
                Phone = reader["Phone"]?.ToString(),
                RoleID = Convert.ToInt32(reader["RoleID"]),
                RoleName = reader["RoleName"].ToString(),
                IsActive = Convert.ToBoolean(reader["IsActive"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
            };
        }
    }
}