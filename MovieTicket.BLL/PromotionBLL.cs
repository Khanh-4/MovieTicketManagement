using System;
using System.Collections.Generic;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class PromotionBLL
    {
        private PromotionDAL promotionDAL = new PromotionDAL();

        public List<PromotionDTO> GetAll()
        {
            return promotionDAL.GetAll();
        }

        public PromotionDTO GetById(int promotionId)
        {
            return promotionDAL.GetById(promotionId);
        }

        public int Insert(PromotionDTO promotion)
        {
            if (promotionDAL.IsCodeExists(promotion.PromotionCode))
            {
                throw new Exception("Mã khuyến mãi đã tồn tại!");
            }

            return promotionDAL.Insert(promotion);
        }

        public bool Update(PromotionDTO promotion)
        {
            if (promotionDAL.IsCodeExists(promotion.PromotionCode, promotion.PromotionID))
            {
                throw new Exception("Mã khuyến mãi đã tồn tại!");
            }

            return promotionDAL.Update(promotion);
        }

        public bool Delete(int promotionId)
        {
            if (promotionDAL.HasBeenUsed(promotionId))
            {
                throw new Exception("Không thể xóa khuyến mãi đã được sử dụng!");
            }

            return promotionDAL.Delete(promotionId);
        }
    }
}