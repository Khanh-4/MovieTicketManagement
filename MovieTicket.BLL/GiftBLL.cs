using MovieTicket.DAL;
using MovieTicket.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Timers;

namespace MovieTicket.BLL
{
    /// <summary>
    /// Business Logic Layer cho tính năng Quà tặng giới hạn
    /// </summary>
    public class GiftBLL
    {
        private readonly GiftDAL giftDAL;
        private static System.Timers.Timer expiredReservationTimer;
        private static bool isTimerRunning = false;

        public GiftBLL()
        {
            giftDAL = new GiftDAL();
        }

        #region Campaign Methods

        /// <summary>
        /// Lấy tất cả chiến dịch
        /// </summary>
        public List<GiftCampaignDTO> GetAllCampaigns()
        {
            return giftDAL.GetAllCampaigns();
        }

        /// <summary>
        /// Lấy chiến dịch đang hoạt động
        /// </summary>
        /// <param name="movieId">Lọc theo phim (null = tất cả)</param>
        public List<GiftCampaignDTO> GetActiveCampaigns(int? movieId = null)
        {
            return giftDAL.GetActiveCampaigns(movieId);
        }

        /// <summary>
        /// Lấy chiến dịch theo ID
        /// </summary>
        public GiftCampaignDTO GetCampaignById(int campaignId)
        {
            return giftDAL.GetCampaignById(campaignId);
        }

        /// <summary>
        /// Thêm chiến dịch mới
        /// </summary>
        public (bool success, string message, int campaignId) AddCampaign(GiftCampaignDTO campaign)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(campaign.CampaignName))
                    return (false, "Tên chiến dịch không được để trống!", 0);

                if (string.IsNullOrWhiteSpace(campaign.GiftName))
                    return (false, "Tên quà tặng không được để trống!", 0);

                if (campaign.TotalGifts <= 0)
                    return (false, "Số lượng quà phải lớn hơn 0!", 0);

                if (campaign.MaxPerUser <= 0)
                    return (false, "Số quà tối đa mỗi người phải lớn hơn 0!", 0);

                if (campaign.HoldTimeoutMinutes <= 0)
                    return (false, "Thời gian giữ chỗ phải lớn hơn 0!", 0);

                if (campaign.EndDate <= campaign.StartDate)
                    return (false, "Ngày kết thúc phải sau ngày bắt đầu!", 0);

                int campaignId = giftDAL.AddCampaign(campaign);
                return (true, "Thêm chiến dịch thành công!", campaignId);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", 0);
            }
        }

        /// <summary>
        /// Cập nhật chiến dịch
        /// </summary>
        public (bool success, string message) UpdateCampaign(GiftCampaignDTO campaign)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(campaign.CampaignName))
                    return (false, "Tên chiến dịch không được để trống!");

                if (string.IsNullOrWhiteSpace(campaign.GiftName))
                    return (false, "Tên quà tặng không được để trống!");

                if (campaign.TotalGifts <= 0)
                    return (false, "Số lượng quà phải lớn hơn 0!");

                if (campaign.EndDate <= campaign.StartDate)
                    return (false, "Ngày kết thúc phải sau ngày bắt đầu!");

                bool result = giftDAL.UpdateCampaign(campaign);
                return result
                    ? (true, "Cập nhật chiến dịch thành công!")
                    : (false, "Không thể cập nhật chiến dịch!");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Kích hoạt/Tạm dừng chiến dịch
        /// </summary>
        public (bool success, string message) SetCampaignActive(int campaignId, bool isActive)
        {
            try
            {
                bool result = giftDAL.SetCampaignActive(campaignId, isActive);
                string action = isActive ? "kích hoạt" : "tạm dừng";
                return result
                    ? (true, $"Đã {action} chiến dịch thành công!")
                    : (false, $"Không thể {action} chiến dịch!");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        #endregion

        #region Reservation Methods

        /// <summary>
        /// Giữ chỗ quà khi khách bắt đầu đặt vé
        /// </summary>
        /// <param name="campaignId">ID chiến dịch</param>
        /// <param name="userId">ID người dùng</param>
        public GiftReservationResult ReserveGift(int campaignId, int userId)
        {
            try
            {
                // Kiểm tra xem user đã có reservation đang holding chưa
                var existingHolding = giftDAL.GetUserHoldingReservation(userId, campaignId);
                if (existingHolding != null)
                {
                    return new GiftReservationResult
                    {
                        Success = true,
                        Message = "Bạn đã giữ chỗ quà này rồi!",
                        ReservationID = existingHolding.ReservationID,
                        HoldUntil = existingHolding.HoldUntil
                    };
                }

                return giftDAL.ReserveGift(campaignId, userId);
            }
            catch (Exception ex)
            {
                return new GiftReservationResult
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}",
                    ReservationID = 0
                };
            }
        }

        /// <summary>
        /// Xác nhận quà sau khi thanh toán thành công
        /// </summary>
        public (bool success, string message) ConfirmGift(int reservationId, int bookingId)
        {
            try
            {
                return giftDAL.ConfirmGift(reservationId, bookingId);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Hủy giữ chỗ quà
        /// </summary>
        /// <param name="reservationId">ID reservation</param>
        /// <param name="cancelReason">Lý do hủy</param>
        /// <param name="returnToStock">Có trả quà về kho không</param>
        public (bool success, string message) CancelGiftReservation(int reservationId, string cancelReason, bool returnToStock = true)
        {
            try
            {
                return giftDAL.CancelGiftReservation(reservationId, cancelReason, returnToStock);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Phát quà tại rạp (Staff scan vé)
        /// </summary>
        public (bool success, string message, string giftName) ReceiveGift(int bookingId, int staffId)
        {
            try
            {
                return giftDAL.ReceiveGift(bookingId, staffId);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", "");
            }
        }

        /// <summary>
        /// Kiểm tra user đủ điều kiện nhận quà không
        /// </summary>
        public (bool isEligible, string message, int remainingGifts) CheckUserGiftEligibility(int campaignId, int userId)
        {
            try
            {
                return giftDAL.CheckUserGiftEligibility(campaignId, userId);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", 0);
            }
        }

        /// <summary>
        /// Lấy thông tin reservation theo ID
        /// </summary>
        public GiftReservationDTO GetReservationById(int reservationId)
        {
            return giftDAL.GetReservationById(reservationId);
        }

        /// <summary>
        /// Lấy thông tin quà của booking
        /// </summary>
        public BookingGiftInfoDTO GetBookingGiftInfo(int bookingId)
        {
            return giftDAL.GetBookingGiftInfo(bookingId);
        }

        /// <summary>
        /// Lấy danh sách reservation của user
        /// </summary>
        public List<GiftReservationDTO> GetUserReservations(int userId)
        {
            return giftDAL.GetUserReservations(userId);
        }

        /// <summary>
        /// Lấy reservation đang Holding của user cho campaign
        /// </summary>
        public GiftReservationDTO GetUserHoldingReservation(int userId, int campaignId)
        {
            return giftDAL.GetUserHoldingReservation(userId, campaignId);
        }

        #endregion

        #region Timer for Expired Reservations

        /// <summary>
        /// Giải phóng các reservation hết hạn (chạy thủ công)
        /// </summary>
        public int ReleaseExpiredReservations()
        {
            try
            {
                return giftDAL.ReleaseExpiredReservations();
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Bắt đầu timer tự động giải phóng reservation hết hạn
        /// Chạy mỗi 1 phút
        /// </summary>
        public static void StartExpiredReservationTimer()
        {
            if (isTimerRunning) return;

            expiredReservationTimer = new System.Timers.Timer(60000); // 1 phút = 60000ms
            expiredReservationTimer.Elapsed += (sender, e) =>
            {
                try
                {
                    var giftBLL = new GiftBLL();
                    int released = giftBLL.ReleaseExpiredReservations();
                    if (released > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[GiftBLL] Đã giải phóng {released} reservation hết hạn.");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[GiftBLL] Lỗi khi giải phóng reservation: {ex.Message}");
                }
            };
            expiredReservationTimer.AutoReset = true;
            expiredReservationTimer.Start();
            isTimerRunning = true;

            System.Diagnostics.Debug.WriteLine("[GiftBLL] Đã bắt đầu timer giải phóng reservation hết hạn (mỗi 1 phút).");
        }

        /// <summary>
        /// Dừng timer
        /// </summary>
        public static void StopExpiredReservationTimer()
        {
            if (expiredReservationTimer != null)
            {
                expiredReservationTimer.Stop();
                expiredReservationTimer.Dispose();
                expiredReservationTimer = null;
                isTimerRunning = false;

                System.Diagnostics.Debug.WriteLine("[GiftBLL] Đã dừng timer giải phóng reservation.");
            }
        }

        #endregion

        #region Statistics Methods

        /// <summary>
        /// Lấy thống kê chiến dịch
        /// </summary>
        public DataTable GetCampaignStatistics()
        {
            return giftDAL.GetCampaignStatistics();
        }

        #endregion

        #region Helper Methods for Booking Integration

        /// <summary>
        /// Tích hợp với quy trình đặt vé:
        /// Kiểm tra và giữ chỗ quà khi khách chọn suất chiếu
        /// </summary>
        /// <param name="movieId">ID phim</param>
        /// <param name="userId">ID người dùng</param>
        /// <returns>Danh sách chiến dịch có thể tham gia + kết quả giữ chỗ</returns>
        public List<(GiftCampaignDTO campaign, GiftReservationResult reservation)> ProcessGiftForBooking(int movieId, int userId)
        {
            var results = new List<(GiftCampaignDTO, GiftReservationResult)>();

            try
            {
                // Lấy các chiến dịch áp dụng cho phim này
                var campaigns = GetActiveCampaigns(movieId);

                foreach (var campaign in campaigns)
                {
                    // Kiểm tra đủ điều kiện
                    var (isEligible, message, remaining) = CheckUserGiftEligibility(campaign.CampaignID, userId);

                    if (isEligible)
                    {
                        // Tự động giữ chỗ
                        var reservation = ReserveGift(campaign.CampaignID, userId);
                        results.Add((campaign, reservation));
                    }
                    else
                    {
                        // Thêm vào list với thông báo không đủ điều kiện
                        results.Add((campaign, new GiftReservationResult
                        {
                            Success = false,
                            Message = message,
                            ReservationID = 0
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GiftBLL] Lỗi ProcessGiftForBooking: {ex.Message}");
            }

            return results;
        }

        /// <summary>
        /// Hoàn tất quà sau khi booking thành công
        /// </summary>
        /// <param name="bookingId">ID booking</param>
        /// <param name="reservationIds">Danh sách reservation ID cần confirm</param>
        public List<(int reservationId, bool success, string message)> FinalizeGiftsForBooking(int bookingId, List<int> reservationIds)
        {
            var results = new List<(int, bool, string)>();

            foreach (var reservationId in reservationIds)
            {
                var (success, message) = ConfirmGift(reservationId, bookingId);
                results.Add((reservationId, success, message));
            }

            return results;
        }

        /// <summary>
        /// Hủy tất cả reservation khi user hủy đặt vé (trước khi thanh toán)
        /// </summary>
        public void CancelAllHoldingReservations(int userId, string reason = "Người dùng hủy đặt vé")
        {
            try
            {
                var reservations = GetUserReservations(userId);
                foreach (var res in reservations)
                {
                    if (res.Status == "Holding")
                    {
                        CancelGiftReservation(res.ReservationID, reason, true);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[GiftBLL] Lỗi CancelAllHoldingReservations: {ex.Message}");
            }
        }

        #endregion
    }
}