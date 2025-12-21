using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public string InvoiceCode { get; set; }
        public int BookingID { get; set; }
        public decimal TicketAmount { get; set; }
        public decimal FoodAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public int? StaffID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }

        // Thông tin bổ sung
        public string BookingCode { get; set; }
        public string CustomerName { get; set; }
        public string StaffName { get; set; }
    }
}
