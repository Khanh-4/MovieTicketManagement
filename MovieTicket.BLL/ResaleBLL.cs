using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class ResaleBLL
    {
        private readonly ResaleDAL resaleDAL = new ResaleDAL();
        private readonly WalletDAL walletDAL = new WalletDAL();
        private readonly UserDAL userDAL = new UserDAL();
        private readonly EmailService emailService = new EmailService();

        // Tính toán hoàn tiền cho booking
        public RefundCalculationDTO CalculateRefund(int bookingId)
        {
            return resaleDAL.CalculateRefund(bookingId);
        }

        // Pass vé
        public (bool success, string message, int resaleId) PassTicket(int bookingId, string refundMethod, string notes = null)
        {
            // Validate
            var calculation = CalculateRefund(bookingId);
            if (calculation == null || !calculation.CanResale)
            {
                return (false, calculation?.Message ?? "Không thể pass vé!", 0);
            }

            // Tạo resale
            var result = resaleDAL.CreateResale(bookingId, refundMethod, notes);

            // Gửi email thông báo (bất đồng bộ - không block UI)
            if (result.success)
            {
                Task.Run(() => SendPassTicketEmail(bookingId, calculation, refundMethod));
            }

            return result;
        }

        // Gửi email khi pass vé thành công
        private async Task SendPassTicketEmail(int bookingId, RefundCalculationDTO calculation, string refundMethod)
        {
            try
            {
                // Lấy thông tin user
                var booking = new BookingDAL().GetById(bookingId);
                if (booking == null) return;

                var user = userDAL.GetById(booking.UserID);
                if (user == null || string.IsNullOrEmpty(user.Email)) return;

                // Tạo nội dung email
                string refundMethodText = refundMethod switch
                {
                    "Wallet" => "Ví tiền",
                    "Points" => "Điểm tích lũy",
                    "Both" => "Ví tiền + Điểm",
                    _ => refundMethod
                };

                string subject = $"🎫 Pass vé thành công - {calculation.MovieTitle}";
                string body = emailService.GetPassTicketSuccessTemplate(
                    user.FullName,
                    calculation.MovieTitle,
                    calculation.ShowTime.ToString("dd/MM/yyyy HH:mm"),
                    calculation.SeatInfo,
                    calculation.RefundAmount,
                    refundMethodText
                );

                await emailService.SendEmailAsync(user.Email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Send email error: {ex.Message}");
            }
        }

        // Lấy danh sách vé pass đang bán
        public List<TicketResaleDTO> GetAvailableResales()
        {
            // Cập nhật vé hết hạn trước
            resaleDAL.UpdateExpiredResales();

            return resaleDAL.GetAvailableResales();
        }

        // Lấy vé pass theo ID
        public TicketResaleDTO GetResaleById(int resaleId)
        {
            return resaleDAL.GetById(resaleId);
        }

        // Mua vé pass
        public (bool success, string message, int newBookingId) BuyResaleTicket(int resaleId, int buyerUserId, string paymentMethod)
        {
            // Validate
            var resale = GetResaleById(resaleId);
            if (resale == null)
                return (false, "Không tìm thấy vé pass!", 0);

            if (resale.Status != "Available")
                return (false, "Vé này đã được bán hoặc hết hạn!", 0);

            if (resale.SellerUserID == buyerUserId)
                return (false, "Không thể mua vé của chính mình!", 0);

            // Kiểm tra ví nếu thanh toán bằng ví
            if (paymentMethod == "Wallet")
            {
                var wallet = walletDAL.GetByUserId(buyerUserId);
                if (wallet == null || wallet.Balance < resale.ResalePrice)
                {
                    return (false, $"Số dư ví không đủ! Cần: {resale.ResalePrice:N0}đ", 0);
                }
            }

            // Mua vé
            var result = resaleDAL.BuyResale(resaleId, buyerUserId, paymentMethod);

            // Gửi email thông báo (bất đồng bộ)
            if (result.success)
            {
                Task.Run(() => SendBuyResaleEmails(resaleId, buyerUserId, result.newBookingId));
            }

            return result;
        }

        // Gửi email khi mua vé pass thành công
        private async Task SendBuyResaleEmails(int resaleId, int buyerUserId, int newBookingId)
        {
            try
            {
                var resale = GetResaleById(resaleId);
                if (resale == null) return;

                var buyer = userDAL.GetById(buyerUserId);
                var seller = userDAL.GetById(resale.SellerUserID);
                var newBooking = new BookingDAL().GetById(newBookingId);

                // Email cho người mua
                if (buyer != null && !string.IsNullOrEmpty(buyer.Email))
                {
                    string buyerSubject = $"🎟️ Mua vé pass thành công - {resale.MovieTitle}";
                    string buyerBody = emailService.GetBuyResaleTicketTemplate(
                        buyer.FullName,
                        resale.MovieTitle,
                        resale.ShowTime.ToString("dd/MM/yyyy HH:mm"),
                        resale.RoomName,
                        resale.SeatInfo,
                        resale.OriginalPrice,
                        resale.ResalePrice,
                        newBooking?.BookingCode ?? "N/A"
                    );
                    await emailService.SendEmailAsync(buyer.Email, buyerSubject, buyerBody);
                }

                // Email cho người bán
                if (seller != null && !string.IsNullOrEmpty(seller.Email))
                {
                    string sellerSubject = $"🎉 Vé của bạn đã được bán - {resale.MovieTitle}";
                    string sellerBody = emailService.GetTicketSoldTemplate(
                        seller.FullName,
                        buyer?.FullName ?? "Khách hàng",
                        resale.MovieTitle,
                        resale.ShowTime.ToString("dd/MM/yyyy HH:mm"),
                        resale.SeatInfo,
                        resale.ResalePrice
                    );
                    await emailService.SendEmailAsync(seller.Email, sellerSubject, sellerBody);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Send email error: {ex.Message}");
            }
        }

        // Lấy danh sách vé đã pass của user
        public List<TicketResaleDTO> GetMyResales(int userId)
        {
            return resaleDAL.GetBySellerUserId(userId);
        }

        // Lấy thông tin ghế của booking
        public string GetSeatInfo(int bookingId)
        {
            return resaleDAL.GetSeatInfo(bookingId);
        }
    }
}