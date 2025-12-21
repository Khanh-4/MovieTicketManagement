using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MovieTicket.DTO;

namespace MovieTicket.DAL
{
    public class ReportDAL
    {
        // Lấy thống kê tổng quan
        public RevenueSummaryDTO GetSummary(DateTime fromDate, DateTime toDate)
        {
            RevenueSummaryDTO summary = new RevenueSummaryDTO();

            string query = @"
                SELECT 
                    ISNULL(SUM(b.FinalAmount), 0) AS TotalRevenue,
                    COUNT(DISTINCT b.BookingID) AS TotalBookings,
                    COUNT(bd.BookingDetailID) AS TotalTickets,
                    COUNT(DISTINCT b.UserID) AS TotalCustomers
                FROM BOOKINGS b
                LEFT JOIN BOOKING_DETAILS bd ON b.BookingID = bd.BookingID
                WHERE b.BookingStatus != 'Cancelled'
                AND CAST(b.BookingTime AS DATE) BETWEEN @FromDate AND @ToDate";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    summary.TotalRevenue = reader["TotalRevenue"] != DBNull.Value
                        ? Convert.ToDecimal(reader["TotalRevenue"]) : 0;
                    summary.TotalBookings = Convert.ToInt32(reader["TotalBookings"]);
                    summary.TotalTickets = Convert.ToInt32(reader["TotalTickets"]);
                    summary.TotalCustomers = Convert.ToInt32(reader["TotalCustomers"]);
                }
                reader.Close();

                // Lấy phim bán chạy nhất
                string movieQuery = @"
                    SELECT TOP 1 m.Title
                    FROM BOOKINGS b
                    INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                    INNER JOIN MOVIES m ON s.MovieID = m.MovieID
                    WHERE b.BookingStatus != 'Cancelled'
                    AND CAST(b.BookingTime AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY m.MovieID, m.Title
                    ORDER BY COUNT(*) DESC";

                cmd = new SqlCommand(movieQuery, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                object result = cmd.ExecuteScalar();
                summary.BestSellingMovie = result?.ToString() ?? "Chưa có dữ liệu";

                // Lấy phòng được sử dụng nhiều nhất
                string roomQuery = @"
                    SELECT TOP 1 r.RoomName
                    FROM BOOKINGS b
                    INNER JOIN SHOWTIMES s ON b.ShowtimeID = s.ShowtimeID
                    INNER JOIN ROOMS r ON s.RoomID = r.RoomID
                    WHERE b.BookingStatus != 'Cancelled'
                    AND CAST(b.BookingTime AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY r.RoomID, r.RoomName
                    ORDER BY COUNT(*) DESC";

                cmd = new SqlCommand(roomQuery, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                result = cmd.ExecuteScalar();
                summary.MostUsedRoom = result?.ToString() ?? "Chưa có dữ liệu";
            }

            return summary;
        }

        // Lấy doanh thu theo ngày
        public List<DailyRevenueDTO> GetDailyRevenue(DateTime fromDate, DateTime toDate)
        {
            List<DailyRevenueDTO> list = new List<DailyRevenueDTO>();

            string query = @"
                SELECT 
                    CAST(b.BookingTime AS DATE) AS BookingDate,
                    COUNT(DISTINCT b.BookingID) AS TotalBookings,
                    COUNT(bd.BookingDetailID) AS TotalTickets,
                    ISNULL(SUM(b.FinalAmount), 0) AS TotalRevenue
                FROM BOOKINGS b
                LEFT JOIN BOOKING_DETAILS bd ON b.BookingID = bd.BookingID
                WHERE b.BookingStatus != 'Cancelled'
                AND CAST(b.BookingTime AS DATE) BETWEEN @FromDate AND @ToDate
                GROUP BY CAST(b.BookingTime AS DATE)
                ORDER BY BookingDate";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new DailyRevenueDTO
                    {
                        Date = Convert.ToDateTime(reader["BookingDate"]),
                        TotalBookings = Convert.ToInt32(reader["TotalBookings"]),
                        TotalTickets = Convert.ToInt32(reader["TotalTickets"]),
                        TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                    });
                }
            }

            return list;
        }

        // Lấy doanh thu theo phim
        public List<MovieRevenueDTO> GetMovieRevenue(DateTime fromDate, DateTime toDate)
        {
            List<MovieRevenueDTO> list = new List<MovieRevenueDTO>();

            string query = @"
                SELECT 
                    m.MovieID,
                    m.Title AS MovieTitle,
                    COUNT(DISTINCT b.BookingID) AS TotalBookings,
                    COUNT(bd.BookingDetailID) AS TotalTickets,
                    ISNULL(SUM(b.FinalAmount), 0) AS TotalRevenue
                FROM MOVIES m
                INNER JOIN SHOWTIMES s ON m.MovieID = s.MovieID
                INNER JOIN BOOKINGS b ON s.ShowtimeID = b.ShowtimeID
                LEFT JOIN BOOKING_DETAILS bd ON b.BookingID = bd.BookingID
                WHERE b.BookingStatus != 'Cancelled'
                AND CAST(b.BookingTime AS DATE) BETWEEN @FromDate AND @ToDate
                GROUP BY m.MovieID, m.Title
                ORDER BY TotalRevenue DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new MovieRevenueDTO
                    {
                        MovieID = Convert.ToInt32(reader["MovieID"]),
                        MovieTitle = reader["MovieTitle"].ToString(),
                        TotalBookings = Convert.ToInt32(reader["TotalBookings"]),
                        TotalTickets = Convert.ToInt32(reader["TotalTickets"]),
                        TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                    });
                }
            }

            return list;
        }

        // Lấy doanh thu theo phòng
        public List<RoomRevenueDTO> GetRoomRevenue(DateTime fromDate, DateTime toDate)
        {
            List<RoomRevenueDTO> list = new List<RoomRevenueDTO>();

            string query = @"
                SELECT 
                    r.RoomID,
                    r.RoomName,
                    COUNT(DISTINCT s.ShowtimeID) AS TotalShowtimes,
                    COUNT(bd.BookingDetailID) AS TotalTickets,
                    ISNULL(SUM(b.FinalAmount), 0) AS TotalRevenue
                FROM ROOMS r
                INNER JOIN SHOWTIMES s ON r.RoomID = s.RoomID
                INNER JOIN BOOKINGS b ON s.ShowtimeID = b.ShowtimeID
                LEFT JOIN BOOKING_DETAILS bd ON b.BookingID = bd.BookingID
                WHERE b.BookingStatus != 'Cancelled'
                AND CAST(b.BookingTime AS DATE) BETWEEN @FromDate AND @ToDate
                GROUP BY r.RoomID, r.RoomName
                ORDER BY TotalRevenue DESC";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new RoomRevenueDTO
                    {
                        RoomID = Convert.ToInt32(reader["RoomID"]),
                        RoomName = reader["RoomName"].ToString(),
                        TotalShowtimes = Convert.ToInt32(reader["TotalShowtimes"]),
                        TotalTickets = Convert.ToInt32(reader["TotalTickets"]),
                        TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                    });
                }
            }

            return list;
        }
    }
}