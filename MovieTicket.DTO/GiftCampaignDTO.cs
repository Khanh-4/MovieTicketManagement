using System;

namespace MovieTicket.DTO
{
    /// <summary>
    /// DTO cho chiến dịch quà tặng giới hạn
    /// </summary>
    public class GiftCampaignDTO
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string Description { get; set; }
        public string GiftName { get; set; }
        public int? MovieID { get; set; }
        public int TotalGifts { get; set; }
        public int RemainingGifts { get; set; }
        public int HoldingGifts { get; set; }
        public int MaxPerUser { get; set; }
        public int HoldTimeoutMinutes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        // === Các thuộc tính bổ sung (từ JOIN) ===
        public string MovieTitle { get; set; }

        // === Các thuộc tính tính toán ===

        /// <summary>
        /// Số quà thực sự còn có thể lấy (chưa ai confirm)
        /// </summary>
        public int AvailableGifts => RemainingGifts;

        /// <summary>
        /// Số quà đã được xác nhận (đã thanh toán)
        /// </summary>
        public int ConfirmedGifts => TotalGifts - RemainingGifts - HoldingGifts;

        /// <summary>
        /// Phần trăm quà còn lại
        /// </summary>
        public double RemainingPercentage => TotalGifts > 0 ? (double)RemainingGifts / TotalGifts * 100 : 0;

        /// <summary>
        /// Trạng thái chiến dịch dạng text
        /// </summary>
        public string StatusText
        {
            get
            {
                if (!IsActive) return "Tạm dừng";
                if (DateTime.Now < StartDate) return "Chưa bắt đầu";
                if (DateTime.Now > EndDate) return "Đã kết thúc";
                if (RemainingGifts <= 0) return "Hết quà";
                return "Đang diễn ra";
            }
        }

        /// <summary>
        /// Kiểm tra chiến dịch có đang hoạt động không
        /// </summary>
        public bool IsRunning => IsActive
            && DateTime.Now >= StartDate
            && DateTime.Now <= EndDate
            && RemainingGifts > 0;

        /// <summary>
        /// Hiển thị thời gian còn lại
        /// </summary>
        public string TimeRemainingText
        {
            get
            {
                if (DateTime.Now > EndDate) return "Đã kết thúc";
                if (DateTime.Now < StartDate)
                {
                    var diff = StartDate - DateTime.Now;
                    return $"Còn {diff.Days} ngày {diff.Hours} giờ nữa bắt đầu";
                }

                var remaining = EndDate - DateTime.Now;
                if (remaining.TotalDays >= 1)
                    return $"Còn {(int)remaining.TotalDays} ngày {remaining.Hours} giờ";
                if (remaining.TotalHours >= 1)
                    return $"Còn {(int)remaining.TotalHours} giờ {remaining.Minutes} phút";
                return $"Còn {(int)remaining.TotalMinutes} phút";
            }
        }

        /// <summary>
        /// Hiển thị số quà còn lại
        /// </summary>
        public string GiftStatusText => $"Còn {RemainingGifts}/{TotalGifts} quà";

        /// <summary>
        /// Hiển thị cho ComboBox/ListBox
        /// </summary>
        public string DisplayText => $"{CampaignName} - {GiftName} ({GiftStatusText})";

        /// <summary>
        /// Áp dụng cho phim nào
        /// </summary>
        public string ApplyToText => MovieID.HasValue ? MovieTitle : "Tất cả phim";
    }
}