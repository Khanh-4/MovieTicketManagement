using System;

namespace MovieTicket.DTO
{
    /// <summary>
    /// Class lưu thông tin đồ ăn đã chọn trong giỏ hàng
    /// </summary>
    public class SelectedFoodItem
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        // Hiển thị trong DataGridView
        public string DisplayTotal => string.Format("{0:N0} đ", TotalPrice);
        public string DisplayUnitPrice => string.Format("{0:N0} đ", UnitPrice);
    }
}