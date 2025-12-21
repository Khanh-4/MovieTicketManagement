using MovieTicket.DAL;
using MovieTicket.DTO;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace MovieTicket.BLL
{
    public class MovieBLL
    {
        private readonly MovieDAL movieDAL = new MovieDAL();
        private readonly GenreDAL genreDAL = new GenreDAL();

        // Lấy tất cả phim
        public List<MovieDTO> GetAll()
        {
            return movieDAL.GetAll();
        }

        // Lấy phim theo ID
        public MovieDTO GetById(int movieId)
        {
            return movieDAL.GetById(movieId);
        }

        // Lấy phim đang chiếu
        public List<MovieDTO> GetNowShowing()
        {
            return movieDAL.GetNowShowing();
        }

        // Tìm kiếm phim
        public List<MovieDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return movieDAL.GetAll();

            return movieDAL.Search(keyword);
        }

        // Thêm phim mới
        public (bool success, string message, int movieId) AddMovie(MovieDTO movie, List<int> genreIds)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(movie.Title))
                return (false, "Tên phim không được để trống!", 0);

            if (movie.Duration <= 0)
                return (false, "Thời lượng phải lớn hơn 0!", 0);

            // Thêm phim
            int movieId = movieDAL.Insert(movie);

            if (movieId > 0)
            {
                // Thêm thể loại cho phim
                if (genreIds != null && genreIds.Count > 0)
                {
                    genreDAL.UpdateMovieGenres(movieId, genreIds);
                }

                return (true, "Thêm phim thành công!", movieId);
            }

            return (false, "Thêm phim thất bại!", 0);
        }

        // Cập nhật phim
        public (bool success, string message) UpdateMovie(MovieDTO movie, List<int> genreIds)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(movie.Title))
                return (false, "Tên phim không được để trống!");

            if (movie.Duration <= 0)
                return (false, "Thời lượng phải lớn hơn 0!");

            // Cập nhật phim
            bool result = movieDAL.Update(movie);

            if (result)
            {
                // Cập nhật thể loại
                if (genreIds != null)
                {
                    genreDAL.UpdateMovieGenres(movie.MovieID, genreIds);
                }

                return (true, "Cập nhật phim thành công!");
            }

            return (false, "Cập nhật phim thất bại!");
        }

        // Xóa phim
        public (bool success, string message) DeleteMovie(int movieId)
        {
            bool result = movieDAL.Delete(movieId);

            if (result)
                return (true, "Xóa phim thành công!");

            return (false, "Xóa phim thất bại!");
        }

        // Lấy tất cả thể loại
        public List<GenreDTO> GetAllGenres()
        {
            return genreDAL.GetAll();
        }

        // Lấy thể loại của phim
        public List<GenreDTO> GetMovieGenres(int movieId)
        {
            return genreDAL.GetByMovieId(movieId);
        }
    }
}
