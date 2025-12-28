using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class WalletDAL
    {
        // Lấy ví theo UserID
        public WalletDTO GetByUserId(int userId)
        {
            WalletDTO wallet = null;
            string query = "SELECT * FROM USER_WALLET WHERE UserID = @UserID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    wallet = new WalletDTO
                    {
                        WalletID = Convert.ToInt32(reader["WalletID"]),
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Balance = Convert.ToDecimal(reader["Balance"]),
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                        UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                    };
                }
            }
            return wallet;
        }

        // Tạo ví mới cho user
        public int CreateWallet(int userId)
        {
            string query = @"INSERT INTO USER_WALLET (UserID, Balance) 
                            VALUES (@UserID, 0);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Cập nhật số dư ví
        public bool UpdateBalance(int walletId, decimal amount, string transactionType, string description, int? referenceId = null)
        {
            string query = @"
                BEGIN TRANSACTION;
                
                UPDATE USER_WALLET 
                SET Balance = Balance + @Amount, UpdatedAt = GETDATE()
                WHERE WalletID = @WalletID;
                
                INSERT INTO WALLET_TRANSACTIONS (WalletID, Amount, TransactionType, Description, ReferenceID)
                VALUES (@WalletID, @Amount, @TransactionType, @Description, @ReferenceID);
                
                COMMIT;
                SELECT 1;";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@WalletID", walletId);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@TransactionType", transactionType);
                cmd.Parameters.AddWithValue("@Description", description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ReferenceID", referenceId.HasValue ? (object)referenceId.Value : DBNull.Value);
                conn.Open();

                return cmd.ExecuteScalar() != null;
            }
        }

        // Lấy lịch sử giao dịch
        public List<WalletTransactionDTO> GetTransactionHistory(int walletId, int top = 50)
        {
            List<WalletTransactionDTO> transactions = new List<WalletTransactionDTO>();
            string query = $@"SELECT TOP {top} * FROM WALLET_TRANSACTIONS 
                             WHERE WalletID = @WalletID 
                             ORDER BY CreatedAt DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@WalletID", walletId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    transactions.Add(new WalletTransactionDTO
                    {
                        TransactionID = Convert.ToInt32(reader["TransactionID"]),
                        WalletID = Convert.ToInt32(reader["WalletID"]),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        TransactionType = reader["TransactionType"].ToString(),
                        Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                        ReferenceID = reader["ReferenceID"] != DBNull.Value ? Convert.ToInt32(reader["ReferenceID"]) : (int?)null,
                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                    });
                }
            }
            return transactions;
        }

        // Nạp tiền vào ví
        public bool Deposit(int userId, decimal amount, string description)
        {
            var wallet = GetByUserId(userId);
            if (wallet == null)
            {
                CreateWallet(userId);
                wallet = GetByUserId(userId);
            }

            return UpdateBalance(wallet.WalletID, amount, "Deposit", description);
        }

        // Thanh toán từ ví
        public bool Payment(int userId, decimal amount, string description, int? referenceId = null)
        {
            var wallet = GetByUserId(userId);
            if (wallet == null || wallet.Balance < amount)
                return false;

            return UpdateBalance(wallet.WalletID, -amount, "Payment", description, referenceId);
        }
    }
}