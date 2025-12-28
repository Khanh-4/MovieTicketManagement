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

        // Thông tin bổ sung từ JOIN với SEAT_TYPES
        public string? TypeName { get; set; }
        public decimal PriceMultiplier { get; set; }

        // === MỚI: Cho ghế Couple ===
        public int? CoupleGroupID { get; set; }  // ID nhóm ghế couple (2 ghế cùng nhóm)

        // Tạo SeatCode nếu chưa có
        public string DisplaySeatCode => SeatCode ?? $"{RowNumber}{SeatNumber}";

        // === MỚI: Kiểm tra có phải ghế Couple không ===
        public bool IsCoupleSeat => SeatTypeID == 3 || TypeName == "Couple";
    }
}