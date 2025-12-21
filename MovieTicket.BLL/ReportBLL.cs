using System;
using System.Collections.Generic;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class ReportBLL
    {
        private ReportDAL reportDAL = new ReportDAL();

        public RevenueSummaryDTO GetSummary(DateTime fromDate, DateTime toDate)
        {
            return reportDAL.GetSummary(fromDate, toDate);
        }

        public List<DailyRevenueDTO> GetDailyRevenue(DateTime fromDate, DateTime toDate)
        {
            return reportDAL.GetDailyRevenue(fromDate, toDate);
        }

        public List<MovieRevenueDTO> GetMovieRevenue(DateTime fromDate, DateTime toDate)
        {
            return reportDAL.GetMovieRevenue(fromDate, toDate);
        }

        public List<RoomRevenueDTO> GetRoomRevenue(DateTime fromDate, DateTime toDate)
        {
            return reportDAL.GetRoomRevenue(fromDate, toDate);
        }
    }
}