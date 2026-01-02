using System;

namespace MovieTicket.DTO
{
    /// <summary>
    /// DTO cho việc giữ chỗ/phát quà
    /// </summary>
    public class GiftReservationDTO
    {
        public int ReservationID { get; set; }
        public int CampaignID { get; set; }
        public int UserID { get; set; }
        public int? BookingID { get; set; }
        public string Status { get; set; }  // Holding, Confirmed, Received, Expired, Cancelled
        public DateTime? HoldUntil { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public int? ReceivedByStaffID { get; set; }
        public DateTime? CancelledAt { get; set; }
        public string CancelReason { get; set; }

        // === Các thuộc tính bổ sung (từ JOIN) ===
        public string CampaignName { get; set; }
        public string GiftName { get; set; }
        public string GiftDescription { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string BookingCode { get; set; }
        public string StaffName { get; set; }

        // === Các thuộc tính tính toán ===

        /// <summary>
        /// Trạng thái dạng tiếng Việt
        /// </summary>
        public string StatusText
        {
            get
            {
                return Status switch
                {
                    "Holding" => "Đang giữ chỗ",
                    "Confirmed" => "Đã xác nhận - Chờ nhận",
                    "Received" => "Đã nhận quà",
                    "Expired" => "Hết hạn",
                    "Cancelled" => "Đã hủy",
                    _ => "Không xác định"
                };
            }
        }

        /// <summary>
        /// Màu hiển thị theo trạng thái
        /// </summary>
        public string StatusColor
        {
            get
            {
                return Status switch
                {
                    "Holding" => "#FFA500",    // Orange
                    "Confirmed" => "#007BFF",  // Blue
                    "Received" => "#28A745",   // Green
                    "Expired" => "#6C757D",    // Gray
                    "Cancelled" => "#DC3545",  // Red
                    _ => "#000000"
                };
            }
        }

        /// <summary>
        /// Kiểm tra còn trong thời gian giữ chỗ không
        /// </summary>
        public bool IsHoldingValid => Status == "Holding" && HoldUntil.HasValue && DateTime.Now <= HoldUntil.Value;

        /// <summary>
        /// Thời gian còn lại để thanh toán (nếu đang Holding)
        /// </summary>
        public string HoldingTimeRemaining
        {
            get
            {
                if (Status != "Holding" || !HoldUntil.HasValue)
                    return "";

                var remaining = HoldUntil.Value - DateTime.Now;
                if (remaining.TotalSeconds <= 0)
                    return "Đã hết hạn";

                if (remaining.TotalMinutes >= 1)
                    return $"Còn {(int)remaining.TotalMinutes} phút {remaining.Seconds} giây";

                return $"Còn {(int)remaining.TotalSeconds} giây";
            }
        }

        /// <summary>
        /// Có thể nhận quà không (cho Staff kiểm tra)
        /// </summary>
        public bool CanReceiveGift => Status == "Confirmed";

        /// <summary>
        /// Đã nhận quà chưa
        /// </summary>
        public bool IsReceived => Status == "Received";

        /// <summary>
        /// Hiển thị thông tin quà
        /// </summary>
        public string DisplayGiftInfo => $"{GiftName} - {CampaignName}";

        /// <summary>
        /// Hiển thị thời điểm nhận quà
        /// </summary>
        public string ReceivedAtText => ReceivedAt.HasValue
            ? ReceivedAt.Value.ToString("dd/MM/yyyy HH:mm")
            : "";
    }

    /// <summary>
    /// DTO cho kết quả giữ chỗ quà
    /// </summary>
    public class GiftReservationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ReservationID { get; set; }
        public DateTime? HoldUntil { get; set; }

        /// <summary>
        /// Thời gian còn lại (phút)
        /// </summary>
        public int MinutesRemaining
        {
            get
            {
                if (!HoldUntil.HasValue) return 0;
                var remaining = HoldUntil.Value - DateTime.Now;
                return remaining.TotalMinutes > 0 ? (int)remaining.TotalMinutes : 0;
            }
        }
    }

    /// <summary>
    /// DTO cho thông tin quà của booking
    /// </summary>
    public class BookingGiftInfoDTO
    {
        public int BookingID { get; set; }
        public string BookingCode { get; set; }
        public bool HasGift { get; set; }
        public int? ReservationID { get; set; }
        public string GiftStatus { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? ReceivedAt { get; set; }
        public int? CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string GiftName { get; set; }
        public string GiftDescription { get; set; }
        public string GiftStatusText { get; set; }

        /// <summary>
        /// Có quà và chưa nhận
        /// </summary>
        public bool CanReceive => HasGift && GiftStatus == "Confirmed";

        /// <summary>
        /// Hiển thị trên vé
        /// </summary>
        public string TicketGiftText
        {
            get
            {
                if (!HasGift) return "";
                return GiftStatus switch
                {
                    "Confirmed" => $"🎁 QUÀ TẶNG: {GiftName} (Chờ nhận tại quầy)",
                    "Received" => $"🎁 QUÀ TẶNG: {GiftName} (Đã nhận)",
                    _ => ""
                };
            }
        }
    }
}