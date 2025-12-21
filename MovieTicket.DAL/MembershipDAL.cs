using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class MembershipDAL
    {
        // Lấy membership theo UserID
        public MembershipDTO GetByUserId(int userId)
        {
            MembershipDTO membership = null;
            string query = @"SELECT m.*, mt.TypeName, mt.DiscountPercent, mt.PointsRequired, mt.Benefits,
                            u.FullName as CustomerName
                            FROM MEMBERSHIPS m
                            INNER JOIN MEMBERSHIP_TYPES mt ON m.MembershipTypeID = mt.MembershipTypeID
                            INNER JOIN USERS u ON m.UserID = u.UserID
                            WHERE m.UserID = @UserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    membership = MapToDTO(reader);
                }
            }
            return membership;
        }

        // Tạo membership mới cho user
        public int Insert(int userId)
        {
            string query = @"INSERT INTO MEMBERSHIPS (UserID, MembershipTypeID, Points, JoinDate, IsActive)
                            VALUES (@UserID, 1, 0, GETDATE(), 1);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Cộng điểm
        public bool AddPoints(int membershipId, int points, string description)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Cập nhật điểm trong MEMBERSHIPS
                    string updateQuery = "UPDATE MEMBERSHIPS SET Points = Points + @Points WHERE MembershipID = @MembershipID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@Points", points);
                    updateCmd.Parameters.AddWithValue("@MembershipID", membershipId);
                    updateCmd.ExecuteNonQuery();

                    // Thêm lịch sử giao dịch
                    string insertQuery = @"INSERT INTO POINT_TRANSACTIONS (MembershipID, Points, TransactionType, Description)
                                          VALUES (@MembershipID, @Points, 'Earn', @Description)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction);
                    insertCmd.Parameters.AddWithValue("@MembershipID", membershipId);
                    insertCmd.Parameters.AddWithValue("@Points", points);
                    insertCmd.Parameters.AddWithValue("@Description", description);
                    insertCmd.ExecuteNonQuery();

                    // Kiểm tra và nâng cấp hạng
                    CheckAndUpgradeMembership(membershipId, conn, transaction);

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

        // Kiểm tra và nâng cấp hạng hội viên
        private void CheckAndUpgradeMembership(int membershipId, SqlConnection conn, SqlTransaction transaction)
        {
            // Lấy điểm hiện tại
            string getPointsQuery = "SELECT Points FROM MEMBERSHIPS WHERE MembershipID = @MembershipID";
            SqlCommand getCmd = new SqlCommand(getPointsQuery, conn, transaction);
            getCmd.Parameters.AddWithValue("@MembershipID", membershipId);
            int currentPoints = Convert.ToInt32(getCmd.ExecuteScalar());

            // Tìm hạng phù hợp
            string findTypeQuery = @"SELECT TOP 1 MembershipTypeID FROM MEMBERSHIP_TYPES 
                                    WHERE PointsRequired <= @Points 
                                    ORDER BY PointsRequired DESC";
            SqlCommand findCmd = new SqlCommand(findTypeQuery, conn, transaction);
            findCmd.Parameters.AddWithValue("@Points", currentPoints);
            int newTypeId = Convert.ToInt32(findCmd.ExecuteScalar());

            // Cập nhật hạng
            string updateTypeQuery = "UPDATE MEMBERSHIPS SET MembershipTypeID = @TypeID WHERE MembershipID = @MembershipID";
            SqlCommand updateCmd = new SqlCommand(updateTypeQuery, conn, transaction);
            updateCmd.Parameters.AddWithValue("@TypeID", newTypeId);
            updateCmd.Parameters.AddWithValue("@MembershipID", membershipId);
            updateCmd.ExecuteNonQuery();
        }

        // Lấy lịch sử giao dịch điểm
        public List<PointTransactionDTO> GetPointHistory(int membershipId)
        {
            List<PointTransactionDTO> transactions = new List<PointTransactionDTO>();
            string query = @"SELECT * FROM POINT_TRANSACTIONS 
                            WHERE MembershipID = @MembershipID 
                            ORDER BY TransactionDate DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MembershipID", membershipId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    transactions.Add(new PointTransactionDTO
                    {
                        TransactionID = Convert.ToInt32(reader["TransactionID"]),
                        MembershipID = Convert.ToInt32(reader["MembershipID"]),
                        Points = Convert.ToInt32(reader["Points"]),
                        TransactionType = reader["TransactionType"].ToString(),
                        Description = reader["Description"]?.ToString(),
                        TransactionDate = Convert.ToDateTime(reader["TransactionDate"])
                    });
                }
            }
            return transactions;
        }

        // Lấy tất cả loại hội viên
        public List<MembershipTypeDTO> GetAllTypes()
        {
            List<MembershipTypeDTO> types = new List<MembershipTypeDTO>();
            string query = "SELECT * FROM MEMBERSHIP_TYPES ORDER BY PointsRequired";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    types.Add(new MembershipTypeDTO
                    {
                        MembershipTypeID = Convert.ToInt32(reader["MembershipTypeID"]),
                        TypeName = reader["TypeName"].ToString(),
                        DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"]),
                        PointsRequired = Convert.ToInt32(reader["PointsRequired"]),
                        Benefits = reader["Benefits"]?.ToString()
                    });
                }
            }
            return types;
        }

        private MembershipDTO MapToDTO(SqlDataReader reader)
        {
            return new MembershipDTO
            {
                MembershipID = Convert.ToInt32(reader["MembershipID"]),
                UserID = Convert.ToInt32(reader["UserID"]),
                MembershipTypeID = Convert.ToInt32(reader["MembershipTypeID"]),
                Points = Convert.ToInt32(reader["Points"]),
                JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                ExpiryDate = reader["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(reader["ExpiryDate"]) : (DateTime?)null,
                IsActive = Convert.ToBoolean(reader["IsActive"]),
                TypeName = reader["TypeName"].ToString(),
                DiscountPercent = Convert.ToDecimal(reader["DiscountPercent"]),
                PointsRequired = Convert.ToInt32(reader["PointsRequired"]),
                Benefits = reader["Benefits"]?.ToString(),
                CustomerName = reader["CustomerName"]?.ToString()
            };
        }
    }
}