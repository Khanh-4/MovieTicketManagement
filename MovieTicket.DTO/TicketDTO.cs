using System;

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
    }
}