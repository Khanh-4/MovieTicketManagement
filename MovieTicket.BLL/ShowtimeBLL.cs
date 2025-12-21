using System;
using System.Collections.Generic;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class ShowtimeBLL
    {
        private readonly ShowtimeDAL showtimeDAL = new ShowtimeDAL();
        private readonly MovieDAL movieDAL = new MovieDAL();
        private readonly RoomDAL roomDAL = new RoomDAL();

        // Lấy tất cả suất chiếu
        public List<ShowtimeDTO> GetAll()
        {
            return showtimeDAL.GetAll();
        }

        // Lấy suất chiếu theo phim
        public List<ShowtimeDTO> GetByMovieId(int movieId)
        {
            return showtimeDAL.GetByMovieId(movieId);
        }

        // Lấy suất chiếu theo ID
        public ShowtimeDTO GetById(int showtimeId)
        {
            return showtimeDAL.GetById(showtimeId);
        }

        // Lấy tất cả phim
        public List<MovieDTO> GetAllMovies()
        {
            return movieDAL.GetAll();
        }

        // Lấy tất cả phòng
        public List<RoomDTO> GetAllRooms()
        {
            return roomDAL.GetAll();
        }

        // Thêm suất chiếu mới
        public (bool success, string message) AddShowtime(ShowtimeDTO showtime)
        {
            // Validate
            if (showtime.MovieID <= 0)
                return (false, "Vui lòng chọn phim!");

            if (showtime.RoomID <= 0)
                return (false, "Vui lòng chọn phòng chiếu!");

            if (showtime.StartTime <= DateTime.Now)
                return (false, "Thời gian bắt đầu phải sau thời điểm hiện tại!");

            if (showtime.EndTime <= showtime.StartTime)
                return (false, "Thời gian kết thúc phải sau thời gian bắt đầu!");

            if (showtime.BasePrice <= 0)
                return (false, "Giá vé phải lớn hơn 0!");

            // Kiểm tra trùng lịch
            if (showtimeDAL.CheckConflict(showtime.RoomID, showtime.StartTime, showtime.EndTime))
                return (false, "Phòng chiếu đã có suất chiếu trong khoảng thời gian này!");

            // Thêm suất chiếu
            int id = showtimeDAL.Insert(showtime);
            if (id > 0)
                return (true, "Thêm suất chiếu thành công!");

            return (false, "Thêm suất chiếu thất bại!");
        }

        // Cập nhật suất chiếu
        public (bool success, string message) UpdateShowtime(ShowtimeDTO showtime)
        {
            // Validate
            if (showtime.MovieID <= 0)
                return (false, "Vui lòng chọn phim!");

            if (showtime.RoomID <= 0)
                return (false, "Vui lòng chọn phòng chiếu!");

            if (showtime.EndTime <= showtime.StartTime)
                return (false, "Thời gian kết thúc phải sau thời gian bắt đầu!");

            if (showtime.BasePrice <= 0)
                return (false, "Giá vé phải lớn hơn 0!");

            // Kiểm tra trùng lịch (loại trừ chính nó)
            if (showtimeDAL.CheckConflict(showtime.RoomID, showtime.StartTime, showtime.EndTime, showtime.ShowtimeID))
                return (false, "Phòng chiếu đã có suất chiếu trong khoảng thời gian này!");

            // Cập nhật
            if (showtimeDAL.Update(showtime))
                return (true, "Cập nhật suất chiếu thành công!");

            return (false, "Cập nhật suất chiếu thất bại!");
        }

        // Xóa suất chiếu
        public (bool success, string message) DeleteShowtime(int showtimeId)
        {
            if (showtimeDAL.Delete(showtimeId))
                return (true, "Xóa suất chiếu thành công!");

            return (false, "Xóa suất chiếu thất bại!");
        }
    }
}