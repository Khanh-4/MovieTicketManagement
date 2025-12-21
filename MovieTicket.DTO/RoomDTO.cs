using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class RoomDTO
    {
        public int RoomID { get; set; }
        public string? RoomName { get; set; }
        public int TotalSeats { get; set; }
        public string? RoomType { get; set; }
        public bool IsActive { get; set; }
    }
}
