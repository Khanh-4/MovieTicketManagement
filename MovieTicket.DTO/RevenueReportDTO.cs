using System;

namespace MovieTicket.DTO
{
    // DTO cho báo cáo doanh thu theo ngày
    public class DailyRevenueDTO
    {
        public DateTime Date { get; set; }
        public int TotalBookings { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    // DTO cho báo cáo doanh thu theo phim
    public class MovieRevenueDTO
    {
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public int TotalBookings { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    // DTO cho báo cáo doanh thu theo phòng
    public class RoomRevenueDTO
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int TotalShowtimes { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    // DTO cho thống kê tổng quan
    public class RevenueSummaryDTO
    {
        public decimal TotalRevenue { get; set; }
        public int TotalBookings { get; set; }
        public int TotalTickets { get; set; }
        public int TotalCustomers { get; set; }
        public string BestSellingMovie { get; set; }
        public string MostUsedRoom { get; set; }
    }
}