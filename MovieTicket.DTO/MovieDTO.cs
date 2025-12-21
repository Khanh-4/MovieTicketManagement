using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class MovieDTO
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string PosterURL { get; set; }
        public string TrailerURL { get; set; }
        public string Country { get; set; }
        public int AgeRating { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrending { get; set; }
        public DateTime CreatedAt { get; set; }

        // Thông tin bổ sung
        public string Genres { get; set; } // Danh sách thể loại (nối chuỗi)
    }
}
