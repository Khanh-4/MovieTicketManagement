using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class MembershipTypeDTO
    {
        public int MembershipTypeID { get; set; }
        public string TypeName { get; set; }
        public decimal DiscountPercent { get; set; }
        public int PointsRequired { get; set; }
        public string Benefits { get; set; }
    }
}
