using System;
using System.Collections.Generic;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class BookingBLL
    {
        private readonly BookingDAL bookingDAL = new BookingDAL();
        private readonly ShowtimeDAL showtimeDAL = new ShowtimeDAL();
        private readonly SeatDAL seatDAL = new SeatDAL();

        // Lấy suất chiếu theo phim
        public List<ShowtimeDTO> GetShowtimesByMovie(int movieId)
        {
            return showtimeDAL.GetByMovieId(movieId);
        }

        // Lấy suất chiếu theo ngày
        public List<ShowtimeDTO> GetShowtimesByDate(DateTime date)
        {
            return showtimeDAL.GetByDate(date);
        }

        // Lấy suất chiếu theo ID
        public ShowtimeDTO GetShowtimeById(int showtimeId)
        {
            return showtimeDAL.GetById(showtimeId);
        }

        // Lấy danh sách ghế của phòng
        public List<SeatDTO> GetSeatsByRoom(int roomId)
        {
            return seatDAL.GetByRoomId(roomId);
        }

        // Lấy danh sách ghế đã đặt
        public List<int> GetBookedSeatIds(int showtimeId)
        {
            return seatDAL.GetBookedSeatIds(showtimeId);
        }

        // Đặt vé
        public (bool success, string message, int bookingId) CreateBooking(int userId, int showtimeId,
            List<int> seatIds, decimal totalAmount)
        {
            // Validate
            if (seatIds == null || seatIds.Count == 0)
                return (false, "Vui lòng chọn ít nhất một ghế!", 0);

            // Kiểm tra ghế còn trống không
            List<int> bookedSeats = seatDAL.GetBookedSeatIds(showtimeId);
            foreach (int seatId in seatIds)
            {
                if (bookedSeats.Contains(seatId))
                    return (false, "Một số ghế đã được đặt. Vui lòng chọn ghế khác!", 0);
            }

            // Tạo booking
            BookingDTO booking = new BookingDTO
            {
                BookingCode = bookingDAL.GenerateBookingCode(),
                UserID = userId,
                ShowtimeID = showtimeId,
                TotalAmount = totalAmount,
                BookingStatus = "Confirmed",  // ✅ Đúng theo CHECK constraint
                PaymentStatus = "Đã thanh toán",
                PaymentMethod = "Tiền mặt",
                BookingTime = DateTime.Now
            };

            int bookingId = bookingDAL.Insert(booking);

            if (bookingId > 0)
            {
                // Lấy thông tin suất chiếu để tính giá
                ShowtimeDTO showtime = showtimeDAL.GetById(showtimeId);

                // Thêm chi tiết booking (các ghế)
                foreach (int seatId in seatIds)
                {
                    SeatDTO seat = seatDAL.GetById(seatId);
                    decimal seatPrice = showtime.BasePrice * seat.PriceMultiplier;
                    bookingDAL.InsertBookingDetail(bookingId, seatId, seatPrice);
                }

                return (true, $"Đặt vé thành công! Mã đặt vé: {booking.BookingCode}", bookingId);
            }

            return (false, "Đặt vé thất bại!", 0);
        }

        // Lấy lịch sử đặt vé của user
        public List<BookingDTO> GetBookingHistory(int userId)
        {
            return bookingDAL.GetByUserId(userId);
        }

        // Lấy booking theo ID
        public BookingDTO GetBookingById(int bookingId)
        {
            return bookingDAL.GetById(bookingId);
        }

        // Lấy chi tiết ghế của booking
        public List<BookingDetailDTO> GetBookingDetails(int bookingId)
        {
            return bookingDAL.GetBookingDetails(bookingId);
        }

        // Tính tổng tiền
        public decimal CalculateTotalAmount(int showtimeId, List<int> seatIds)
        {
            ShowtimeDTO showtime = showtimeDAL.GetById(showtimeId);
            decimal total = 0;

            foreach (int seatId in seatIds)
            {
                SeatDTO seat = seatDAL.GetById(seatId);
                total += showtime.BasePrice * seat.PriceMultiplier;
            }

            return total;
        }

        public bool CancelBooking(int bookingId)
        {
            return bookingDAL.CancelBooking(bookingId);
        }

        public bool CanCancelBooking(int bookingId)
        {
            return bookingDAL.CanCancelBooking(bookingId);
        }

        // Lấy thông tin vé để in
        public TicketDTO GetTicketInfo(int bookingId)
        {
            return bookingDAL.GetTicketInfo(bookingId);
        }

        // Lấy booking theo mã vé
        public BookingDTO GetByBookingCode(string bookingCode)
        {
            return bookingDAL.GetByBookingCode(bookingCode);
        }

        // Đánh dấu vé đã sử dụng
        public bool MarkAsUsed(int bookingId)
        {
            return bookingDAL.MarkAsUsed(bookingId);
        }

    }
}