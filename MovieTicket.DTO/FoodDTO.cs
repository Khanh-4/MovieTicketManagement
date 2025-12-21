using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class FoodDTO
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }

        // Thông tin bổ sung
        public string CategoryName { get; set; }
    }
}
