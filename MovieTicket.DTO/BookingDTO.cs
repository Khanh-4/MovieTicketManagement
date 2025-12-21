using System;

namespace MovieTicket.DTO
{
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public string? BookingCode { get; set; }
        public int UserID { get; set; }
        public int ShowtimeID { get; set; }
        public int? PromotionID { get; set; }
        public DateTime BookingTime { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public string? BookingStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public string? QRCode { get; set; }
        public DateTime CreatedAt { get; set; }

        // Thông tin bổ sung
        public string? CustomerName { get; set; }
        public string? MovieTitle { get; set; }
        public string? RoomName { get; set; }
        public DateTime ShowTime { get; set; }
        public string? Seats { get; set; }

        public bool IsUsed { get; set; }
        public DateTime? UsedAt { get; set; }
    }
}