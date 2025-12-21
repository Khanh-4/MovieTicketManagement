using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class PromotionDAL
    {
        // Lấy tất cả khuyến mãi
        public List<PromotionDTO> GetAll()
        {
            List<PromotionDTO> promotions = new List<PromotionDTO>();
            string query = "SELECT * FROM PROMOTIONS ORDER BY EndDate DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    promotions.Add(MapToDTO(reader));
                }
            }
            return promotions;
        }

        // Lấy khuyến mãi theo ID
        public PromotionDTO GetById(int promotionId)
        {
            PromotionDTO promotion = null;
            string query = "SELECT * FROM PROMOTIONS WHERE PromotionID = @PromotionID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotionId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    promotion = MapToDTO(reader);
                }
            }
            return promotion;
        }

        // Thêm khuyến mãi mới
        public int Insert(PromotionDTO promotion)
        {
            string query = @"INSERT INTO PROMOTIONS (PromotionCode, PromotionName, DiscountType, DiscountValue, 
                            MinOrderAmount, MaxDiscountAmount, StartDate, EndDate, Quantity, UsedCount, IsActive)
                            VALUES (@PromotionCode, @PromotionName, @DiscountType, @DiscountValue, 
                            @MinOrderAmount, @MaxDiscountAmount, @StartDate, @EndDate, @Quantity, 0, @IsActive);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionCode", promotion.PromotionCode);
                cmd.Parameters.AddWithValue("@PromotionName", promotion.PromotionName);
                cmd.Parameters.AddWithValue("@DiscountType", promotion.DiscountType);
                cmd.Parameters.AddWithValue("@DiscountValue", promotion.DiscountValue);
                cmd.Parameters.AddWithValue("@MinOrderAmount", promotion.MinOrderAmount);
                cmd.Parameters.AddWithValue("@MaxDiscountAmount", (object)promotion.MaxDiscountAmount ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StartDate", promotion.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", promotion.EndDate);
                cmd.Parameters.AddWithValue("@Quantity", promotion.Quantity);
                cmd.Parameters.AddWithValue("@IsActive", promotion.IsActive);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Cập nhật khuyến mãi
        public bool Update(PromotionDTO promotion)
        {
            string query = @"UPDATE PROMOTIONS 
                            SET PromotionCode = @PromotionCode,
                                PromotionName = @PromotionName,
                                DiscountType = @DiscountType,
                                DiscountValue = @DiscountValue,
                                MinOrderAmount = @MinOrderAmount,
                                MaxDiscountAmount = @MaxDiscountAmount,
                                StartDate = @StartDate,
                                EndDate = @EndDate,
                                Quantity = @Quantity,
                                IsActive = @IsActive
                            WHERE PromotionID = @PromotionID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
                cmd.Parameters.AddWithValue("@PromotionCode", promotion.PromotionCode);
                cmd.Parameters.AddWithValue("@PromotionName", promotion.PromotionName);
                cmd.Parameters.AddWithValue("@DiscountType", promotion.DiscountType);
                cmd.Parameters.AddWithValue("@DiscountValue", promotion.DiscountValue);
                cmd.Parameters.AddWithValue("@MinOrderAmount", promotion.MinOrderAmount);
                cmd.Parameters.AddWithValue("@MaxDiscountAmount", (object)promotion.MaxDiscountAmount ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StartDate", promotion.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", promotion.EndDate);
                cmd.Parameters.AddWithValue("@Quantity", promotion.Quantity);
                cmd.Parameters.AddWithValue("@IsActive", promotion.IsActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa khuyến mãi
        public bool Delete(int promotionId)
        {
            string query = "DELETE FROM PROMOTIONS WHERE PromotionID = @PromotionID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotionId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra mã khuyến mãi đã tồn tại chưa
        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string query = "SELECT COUNT(*) FROM PROMOTIONS WHERE PromotionCode = @Code AND PromotionID != @ExcludeID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@ExcludeID", excludeId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // Kiểm tra khuyến mãi đã được sử dụng chưa
        public bool HasBeenUsed(int promotionId)
        {
            string query = "SELECT UsedCount FROM PROMOTIONS WHERE PromotionID = @PromotionID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromotionID", promotionId);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null && Convert.ToInt32(result) > 0;
            }
        }

        // Map từ SqlDataReader sang PromotionDTO
        private PromotionDTO MapToDTO(SqlDataReader reader)
        {
            return new PromotionDTO
            {
                PromotionID = Convert.ToInt32(reader["PromotionID"]),
                PromotionCode = reader["PromotionCode"].ToString(),
                PromotionName = reader["PromotionName"].ToString(),
                DiscountType = reader["DiscountType"].ToString(),
                DiscountValue = Convert.ToDecimal(reader["DiscountValue"]),
                MinOrderAmount = Convert.ToDecimal(reader["MinOrderAmount"]),
                MaxDiscountAmount = reader["MaxDiscountAmount"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["MaxDiscountAmount"]),
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                EndDate = Convert.ToDateTime(reader["EndDate"]),
                Quantity = Convert.ToInt32(reader["Quantity"]),
                UsedCount = Convert.ToInt32(reader["UsedCount"]),
                IsActive = Convert.ToBoolean(reader["IsActive"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
            };
        }
    }
}