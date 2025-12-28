using System;
using System.Collections.Generic;

namespace MovieTicket.DTO
{
    // ============================================
    // DTO CHO VÍ TIỀN
    // ============================================
    public class WalletDTO
    {
        public int WalletID { get; set; }
        public int UserID { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Hiển thị số dư
        public string DisplayBalance => $"{Balance:N0} đ";
    }

    // ============================================
    // DTO CHO GIAO DỊCH VÍ
    // ============================================
    public class WalletTransactionDTO
    {
        public int TransactionID { get; set; }
        public int WalletID { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public int? ReferenceID { get; set; }
        public DateTime CreatedAt { get; set; }

        // Hiển thị số tiền (có dấu + hoặc -)
        public string DisplayAmount
        {
            get
            {
                if (Amount >= 0)
                    return $"+{Amount:N0} đ";
                else
                    return $"{Amount:N0} đ";
            }
        }

        // Hiển thị loại giao dịch tiếng Việt
        public string DisplayType
        {
            get
            {
                switch (TransactionType)
                {
                    case "Deposit": return "Nạp tiền";
                    case "Withdraw": return "Rút tiền";
                    case "Payment": return "Thanh toán";
                    case "ResaleRefund": return "Hoàn tiền pass vé";
                    case "PointsConvert": return "Đổi điểm";
                    case "Refund": return "Hoàn tiền";
                    default: return TransactionType;
                }
            }
        }

        // Icon theo loại
        public string TypeIcon
        {
            get
            {
                if (Amount >= 0)
                    return "🟢";
                else
                    return "🔴";
            }
        }
    }

    // ============================================
    // DTO CHO VÉ PASS
    // ============================================
    public class TicketResaleDTO
    {
        public int ResaleID { get; set; }
        public int BookingID { get; set; }
        public int SellerUserID { get; set; }

        // Thông tin giá
        public decimal OriginalPrice { get; set; }
        public decimal RefundPercent { get; set; }
        public decimal RefundAmount { get; set; }
        public decimal ResalePrice { get; set; }

        // Phương thức hoàn tiền
        public string RefundMethod { get; set; }

        // Trạng thái
        public string Status { get; set; }

        // Thời gian
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }

        // Khi có người mua
        public int? BuyerUserID { get; set; }
        public int? NewBookingID { get; set; }
        public DateTime? SoldAt { get; set; }

        public string Notes { get; set; }

        // ===== Thông tin bổ sung từ JOIN =====
        public string MovieTitle { get; set; }
        public string RoomName { get; set; }
        public DateTime ShowTime { get; set; }
        public string SeatInfo { get; set; }
        public string SellerName { get; set; }
        public string BuyerName { get; set; }
        public string BookingCode { get; set; }

        // ===== Thuộc tính hiển thị =====
        public string DisplayOriginalPrice => $"{OriginalPrice:N0} đ";
        public string DisplayResalePrice => $"{ResalePrice:N0} đ";
        public string DisplayRefundAmount => $"{RefundAmount:N0} đ";
        public string DisplayRefundPercent => $"{RefundPercent}%";

        public string DisplayShowTime => ShowTime.ToString("dd/MM/yyyy HH:mm");

        public string DisplayStatus
        {
            get
            {
                switch (Status)
                {
                    case "Available": return "Đang bán";
                    case "Sold": return "Đã bán";
                    case "Expired": return "Hết hạn";
                    case "Cancelled": return "Đã hủy";
                    default: return Status;
                }
            }
        }

        public string StatusColor
        {
            get
            {
                switch (Status)
                {
                    case "Available": return "Green";
                    case "Sold": return "Blue";
                    case "Expired": return "Gray";
                    case "Cancelled": return "Red";
                    default: return "Black";
                }
            }
        }

        // Tính thời gian còn lại
        public TimeSpan TimeRemaining => ExpiredAt - DateTime.Now;

        public string DisplayTimeRemaining
        {
            get
            {
                var remaining = TimeRemaining;
                if (remaining.TotalSeconds <= 0)
                    return "Đã hết hạn";
                if (remaining.TotalDays >= 1)
                    return $"{(int)remaining.TotalDays} ngày {remaining.Hours} giờ";
                if (remaining.TotalHours >= 1)
                    return $"{(int)remaining.TotalHours} giờ {remaining.Minutes} phút";
                return $"{remaining.Minutes} phút";
            }
        }

        // Tính % giảm giá
        public decimal DiscountPercent => OriginalPrice > 0
            ? Math.Round((OriginalPrice - ResalePrice) / OriginalPrice * 100, 0)
            : 0;

        public string DisplayDiscount => $"-{DiscountPercent}%";
    }

    // ============================================
    // DTO CHO TÍNH TOÁN HOÀN TIỀN
    // ============================================
    public class RefundCalculationDTO
    {
        public int BookingID { get; set; }
        public decimal OriginalPrice { get; set; }
        public int DaysRemaining { get; set; }
        public decimal RefundPercent { get; set; }
        public decimal RefundAmount { get; set; }
        public decimal ResalePrice { get; set; }
        public bool CanResale { get; set; }
        public string Message { get; set; }

        // Thông tin booking
        public string MovieTitle { get; set; }
        public string RoomName { get; set; }
        public DateTime ShowTime { get; set; }
        public string SeatInfo { get; set; }
        public string BookingCode { get; set; }

        // Hiển thị
        public string DisplayOriginalPrice => $"{OriginalPrice:N0} đ";
        public string DisplayRefundAmount => $"{RefundAmount:N0} đ";
        public string DisplayRefundPercent => $"{RefundPercent}%";
        public string DisplayDaysRemaining => DaysRemaining >= 0
            ? $"{DaysRemaining} ngày"
            : "Đã qua";
    }
}