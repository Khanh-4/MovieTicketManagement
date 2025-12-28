using System;
using System.Collections.Generic;

namespace MovieTicket.DTO
{
    public class TicketDTO
    {
        public int BookingID { get; set; }
        public string BookingCode { get; set; }
        public string MovieTitle { get; set; }
        public string RoomName { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan ShowTime { get; set; }
        public string SeatInfo { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }

        // === MỚI: Thông tin đồ ăn ===
        public decimal TicketAmount { get; set; }        // Tiền vé
        public decimal FoodAmount { get; set; }          // Tiền đồ ăn
        public List<TicketFoodItem> FoodItems { get; set; } = new List<TicketFoodItem>();  // Danh sách đồ ăn

        // Hiển thị đồ ăn dạng text
        public string FoodInfo
        {
            get
            {
                if (FoodItems == null || FoodItems.Count == 0)
                    return "(Không có)";

                var items = new List<string>();
                foreach (var food in FoodItems)
                {
                    items.Add($"{food.FoodName} x{food.Quantity}");
                }
                return string.Join(", ", items);
            }
        }
    }

    // Class lưu thông tin đồ ăn trong vé
    public class TicketFoodItem
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}