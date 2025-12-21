using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class PointTransactionDTO
    {
        public int TransactionID { get; set; }
        public int MembershipID { get; set; }
        public int Points { get; set; }
        public string TransactionType { get; set; } // "Earn", "Redeem", "Expire", "Adjust"
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
