using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class BookingDetailDTO
    {
        public int BookingDetailID { get; set; }
        public int BookingID { get; set; }
        public int SeatID { get; set; }
        public decimal Price { get; set; }

        // Thông tin bổ sung
        public string SeatCode { get; set; }
        public string SeatTypeName { get; set; }


    }
}
