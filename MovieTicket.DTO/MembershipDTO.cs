using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class MembershipDTO
    {
        public int MembershipID { get; set; }
        public int UserID { get; set; }
        public int MembershipTypeID { get; set; }
        public int Points { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; }

        // Thông tin bổ sung
        public string TypeName { get; set; }
        public decimal DiscountPercent { get; set; }
        public int PointsRequired { get; set; }
        public string Benefits { get; set; }
        public string CustomerName { get; set; }
    }
}
