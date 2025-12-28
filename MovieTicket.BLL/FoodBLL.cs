using System;
using System.Collections.Generic;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class FoodBLL
    {
        private readonly FoodDAL foodDAL = new FoodDAL();

        // Lấy tất cả đồ ăn
        public List<FoodDTO> GetAll()
        {
            return foodDAL.GetAll();
        }

        // === MỚI: Lấy tất cả đồ ăn đang bán (IsActive = 1) ===
        public List<FoodDTO> GetAllActive()
        {
            return foodDAL.GetAllActive();
        }

        // === MỚI: Lấy đồ ăn theo danh mục ===
        public List<FoodDTO> GetByCategory(int categoryId)
        {
            return foodDAL.GetByCategory(categoryId);
        }

        // Lấy đồ ăn theo ID
        public FoodDTO GetById(int foodId)
        {
            return foodDAL.GetById(foodId);
        }

        // Lấy tất cả danh mục
        public List<FoodCategoryDTO> GetAllCategories()
        {
            return foodDAL.GetAllCategories();
        }

        // Thêm đồ ăn mới
        public int Insert(FoodDTO food)
        {
            if (foodDAL.IsNameExists(food.FoodName))
            {
                throw new Exception("Tên đồ ăn đã tồn tại!");
            }
            return foodDAL.Insert(food);
        }

        // Cập nhật đồ ăn
        public bool Update(FoodDTO food)
        {
            if (foodDAL.IsNameExists(food.FoodName, food.FoodID))
            {
                throw new Exception("Tên đồ ăn đã tồn tại!");
            }
            return foodDAL.Update(food);
        }

        // Xóa đồ ăn
        public bool Delete(int foodId)
        {
            if (foodDAL.HasOrders(foodId))
            {
                throw new Exception("Không thể xóa đồ ăn đã có đơn hàng!");
            }
            return foodDAL.Delete(foodId);
        }
    }
}