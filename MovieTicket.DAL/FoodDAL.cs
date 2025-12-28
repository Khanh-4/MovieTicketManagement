using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class FoodDAL
    {
        // Lấy tất cả đồ ăn
        public List<FoodDTO> GetAll()
        {
            List<FoodDTO> foods = new List<FoodDTO>();
            string query = @"SELECT f.*, c.CategoryName 
                            FROM FOODS f
                            INNER JOIN FOOD_CATEGORIES c ON f.CategoryID = c.CategoryID
                            ORDER BY c.CategoryName, f.FoodName";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foods.Add(MapToDTO(reader));
                }
            }
            return foods;
        }

        // === MỚI: Lấy tất cả đồ ăn đang bán (IsActive = 1) ===
        public List<FoodDTO> GetAllActive()
        {
            List<FoodDTO> foods = new List<FoodDTO>();
            string query = @"SELECT f.*, c.CategoryName 
                            FROM FOODS f
                            INNER JOIN FOOD_CATEGORIES c ON f.CategoryID = c.CategoryID
                            WHERE f.IsActive = 1
                            ORDER BY c.CategoryName, f.FoodName";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foods.Add(MapToDTO(reader));
                }
            }
            return foods;
        }

        // === MỚI: Lấy đồ ăn theo danh mục (chỉ lấy đang bán) ===
        public List<FoodDTO> GetByCategory(int categoryId)
        {
            List<FoodDTO> foods = new List<FoodDTO>();
            string query = @"SELECT f.*, c.CategoryName 
                            FROM FOODS f
                            INNER JOIN FOOD_CATEGORIES c ON f.CategoryID = c.CategoryID
                            WHERE f.CategoryID = @CategoryID AND f.IsActive = 1
                            ORDER BY f.FoodName";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    foods.Add(MapToDTO(reader));
                }
            }
            return foods;
        }

        // Lấy đồ ăn theo ID
        public FoodDTO GetById(int foodId)
        {
            FoodDTO food = null;
            string query = @"SELECT f.*, c.CategoryName 
                            FROM FOODS f
                            INNER JOIN FOOD_CATEGORIES c ON f.CategoryID = c.CategoryID
                            WHERE f.FoodID = @FoodID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FoodID", foodId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    food = MapToDTO(reader);
                }
            }
            return food;
        }

        // Thêm đồ ăn mới
        public int Insert(FoodDTO food)
        {
            string query = @"INSERT INTO FOODS (FoodName, CategoryID, Price, ImageURL, Description, StockQuantity, IsActive)
                            VALUES (@FoodName, @CategoryID, @Price, @ImageURL, @Description, @StockQuantity, @IsActive);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FoodName", food.FoodName);
                cmd.Parameters.AddWithValue("@CategoryID", food.CategoryID);
                cmd.Parameters.AddWithValue("@Price", food.Price);
                cmd.Parameters.AddWithValue("@ImageURL", (object)food.ImageURL ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)food.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StockQuantity", food.StockQuantity);
                cmd.Parameters.AddWithValue("@IsActive", food.IsActive);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Cập nhật đồ ăn
        public bool Update(FoodDTO food)
        {
            string query = @"UPDATE FOODS SET 
                            FoodName = @FoodName,
                            CategoryID = @CategoryID,
                            Price = @Price,
                            ImageURL = @ImageURL,
                            Description = @Description,
                            StockQuantity = @StockQuantity,
                            IsActive = @IsActive
                            WHERE FoodID = @FoodID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FoodID", food.FoodID);
                cmd.Parameters.AddWithValue("@FoodName", food.FoodName);
                cmd.Parameters.AddWithValue("@CategoryID", food.CategoryID);
                cmd.Parameters.AddWithValue("@Price", food.Price);
                cmd.Parameters.AddWithValue("@ImageURL", (object)food.ImageURL ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)food.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StockQuantity", food.StockQuantity);
                cmd.Parameters.AddWithValue("@IsActive", food.IsActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa đồ ăn
        public bool Delete(int foodId)
        {
            string query = "DELETE FROM FOODS WHERE FoodID = @FoodID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FoodID", foodId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra tên đồ ăn đã tồn tại
        public bool IsNameExists(string foodName, int excludeId = 0)
        {
            string query = "SELECT COUNT(*) FROM FOODS WHERE FoodName = @FoodName AND FoodID != @ExcludeID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FoodName", foodName);
                cmd.Parameters.AddWithValue("@ExcludeID", excludeId);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Kiểm tra đồ ăn đã được đặt chưa
        public bool HasOrders(int foodId)
        {
            string query = "SELECT COUNT(*) FROM BOOKING_FOODS WHERE FoodID = @FoodID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FoodID", foodId);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Lấy tất cả danh mục
        public List<FoodCategoryDTO> GetAllCategories()
        {
            List<FoodCategoryDTO> categories = new List<FoodCategoryDTO>();
            string query = "SELECT * FROM FOOD_CATEGORIES ORDER BY CategoryName";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new FoodCategoryDTO
                    {
                        CategoryID = Convert.ToInt32(reader["CategoryID"]),
                        CategoryName = reader["CategoryName"].ToString(),
                        Description = reader["Description"]?.ToString()
                    });
                }
            }
            return categories;
        }

        private FoodDTO MapToDTO(SqlDataReader reader)
        {
            return new FoodDTO
            {
                FoodID = Convert.ToInt32(reader["FoodID"]),
                FoodName = reader["FoodName"].ToString(),
                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                CategoryName = reader["CategoryName"].ToString(),
                Price = Convert.ToDecimal(reader["Price"]),
                ImageURL = reader["ImageURL"]?.ToString(),
                Description = reader["Description"]?.ToString(),
                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                IsActive = Convert.ToBoolean(reader["IsActive"])
            };
        }
    }
}