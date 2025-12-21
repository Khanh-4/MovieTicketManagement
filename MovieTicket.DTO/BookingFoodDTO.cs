using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class BookingFoodDTO
    {
        public int BookingFoodID { get; set; }
        public int BookingID { get; set; }
        public int FoodID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Thông tin bổ sung
        public string FoodName { get; set; }
    }
}
