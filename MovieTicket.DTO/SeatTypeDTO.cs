using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class SeatTypeDTO
    {
        public int SeatTypeID { get; set; }
        public string TypeName { get; set; }
        public decimal PriceMultiplier { get; set; }
        public string Description { get; set; }
    }
}
