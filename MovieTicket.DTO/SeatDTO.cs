using System;

namespace MovieTicket.DTO
{
    public class SeatDTO
    {
        public int SeatID { get; set; }
        public int RoomID { get; set; }
        public int SeatTypeID { get; set; }
        public string? RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public string? SeatCode { get; set; }
        public bool IsActive { get; set; }

        // Thông tin bổ sung
        public string? TypeName { get; set; }
        public decimal PriceMultiplier { get; set; }

        // Tạo SeatCode nếu chưa có
        public string DisplaySeatCode => SeatCode ?? $"{RowNumber}{SeatNumber}";
    }
}