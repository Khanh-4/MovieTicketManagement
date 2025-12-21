using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Common
{
    public static class Constants
    {
        // Vai trò người dùng
        public static class Roles
        {
            public const int Admin = 1;
            public const int Staff = 2;
            public const int Customer = 3;
        }

        // Trạng thái đặt vé
        public static class BookingStatus
        {
            public const string Pending = "Pending";
            public const string Confirmed = "Confirmed";
            public const string Cancelled = "Cancelled";
            public const string Completed = "Completed";
        }

        // Trạng thái thanh toán
        public static class PaymentStatus
        {
            public const string Pending = "Pending";
            public const string Paid = "Paid";
            public const string Refunded = "Refunded";
            public const string Cancelled = "Cancelled";
        }

        // Phương thức thanh toán
        public static class PaymentMethod
        {
            public const string Cash = "Tiền mặt";
            public const string BankCard = "Thẻ ngân hàng";
            public const string MoMo = "MoMo";
            public const string ZaloPay = "ZaloPay";
            public const string VNPay = "VNPay";
        }

        // Loại giảm giá
        public static class DiscountType
        {
            public const string Percent = "Percent";
            public const string Amount = "Amount";
        }

        // Loại giao dịch điểm
        public static class PointTransactionType
        {
            public const string Earn = "Earn";
            public const string Redeem = "Redeem";
            public const string Expire = "Expire";
            public const string Adjust = "Adjust";
        }
    }
}
