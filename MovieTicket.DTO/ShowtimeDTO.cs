using System;

namespace MovieTicket.DTO
{
    public class ShowtimeDTO
    {
        public int ShowtimeID { get; set; }
        public int MovieID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsActive { get; set; }

        // Thông tin bổ sung
        public string? MovieTitle { get; set; }
        public string? RoomName { get; set; }
        public int Duration { get; set; }

        // Hiển thị thời gian
        public string DisplayTime => StartTime.ToString("dd/MM/yyyy HH:mm") + " - " + RoomName;
    }
}