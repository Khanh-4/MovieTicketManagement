using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MovieTicket.BLL
{
    public class EmailService
    {
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string smtpEmail;
        private readonly string smtpPassword;
        private readonly string displayName;

        public EmailService()
        {
            smtpHost = ConfigurationManager.AppSettings["SmtpHost"] ?? "smtp.gmail.com";
            smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
            smtpEmail = ConfigurationManager.AppSettings["SmtpEmail"] ?? "";
            smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"] ?? "";
            displayName = ConfigurationManager.AppSettings["SmtpDisplayName"] ?? "Movie Ticket System";
        }

        // Gửi email
        public bool SendEmail(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                if (string.IsNullOrEmpty(toEmail) || string.IsNullOrEmpty(smtpEmail))
                    return false;

                using (var client = new SmtpClient(smtpHost, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(smtpEmail, smtpPassword);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(smtpEmail, displayName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };
                    mailMessage.To.Add(toEmail);

                    client.Send(mailMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email error: {ex.Message}");
                return false;
            }
        }

        // Gửi email bất đồng bộ (không block UI)
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                if (string.IsNullOrEmpty(toEmail) || string.IsNullOrEmpty(smtpEmail))
                    return false;

                using (var client = new SmtpClient(smtpHost, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(smtpEmail, smtpPassword);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(smtpEmail, displayName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };
                    mailMessage.To.Add(toEmail);

                    await client.SendMailAsync(mailMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email error: {ex.Message}");
                return false;
            }
        }

        // ============================================
        // EMAIL TEMPLATES CHO PASS VÉ
        // ============================================

        // Email thông báo pass vé thành công (cho người bán)
        public string GetPassTicketSuccessTemplate(string customerName, string movieTitle,
            string showTime, string seatInfo, decimal refundAmount, string refundMethod)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 20px; text-align: center; border-radius: 10px 10px 0 0; }}
        .content {{ background: #f9f9f9; padding: 20px; border: 1px solid #ddd; }}
        .ticket-info {{ background: white; padding: 15px; border-radius: 8px; margin: 15px 0; border-left: 4px solid #667eea; }}
        .amount {{ font-size: 24px; color: #28a745; font-weight: bold; }}
        .footer {{ background: #333; color: white; padding: 15px; text-align: center; border-radius: 0 0 10px 10px; font-size: 12px; }}
        .highlight {{ color: #667eea; font-weight: bold; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎫 PASS VÉ THÀNH CÔNG</h1>
        </div>
        <div class='content'>
            <p>Xin chào <strong>{customerName}</strong>,</p>
            <p>Bạn đã pass vé thành công! Dưới đây là thông tin chi tiết:</p>
            
            <div class='ticket-info'>
                <p><strong>🎬 Phim:</strong> {movieTitle}</p>
                <p><strong>📅 Suất chiếu:</strong> {showTime}</p>
                <p><strong>💺 Ghế:</strong> {seatInfo}</p>
            </div>
            
            <div class='ticket-info'>
                <p><strong>💰 Số tiền hoàn:</strong></p>
                <p class='amount'>+{refundAmount:N0} đ</p>
                <p><strong>📥 Hoàn vào:</strong> {refundMethod}</p>
            </div>
            
            <p>Vé của bạn đã được đăng bán. Khi có người mua, bạn sẽ nhận được thông báo.</p>
            <p>Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!</p>
        </div>
        <div class='footer'>
            <p>© 2025 Movie Ticket System - Hệ thống đặt vé xem phim</p>
            <p>Email này được gửi tự động, vui lòng không trả lời.</p>
        </div>
    </div>
</body>
</html>";
        }

        // Email thông báo vé đã được bán (cho người bán)
        public string GetTicketSoldTemplate(string sellerName, string buyerName, string movieTitle,
            string showTime, string seatInfo, decimal resalePrice)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background: linear-gradient(135deg, #28a745 0%, #20c997 100%); color: white; padding: 20px; text-align: center; border-radius: 10px 10px 0 0; }}
        .content {{ background: #f9f9f9; padding: 20px; border: 1px solid #ddd; }}
        .ticket-info {{ background: white; padding: 15px; border-radius: 8px; margin: 15px 0; border-left: 4px solid #28a745; }}
        .footer {{ background: #333; color: white; padding: 15px; text-align: center; border-radius: 0 0 10px 10px; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎉 VÉ CỦA BẠN ĐÃ ĐƯỢC BÁN!</h1>
        </div>
        <div class='content'>
            <p>Xin chào <strong>{sellerName}</strong>,</p>
            <p>Tin vui! Vé pass của bạn đã được <strong>{buyerName}</strong> mua thành công!</p>
            
            <div class='ticket-info'>
                <p><strong>🎬 Phim:</strong> {movieTitle}</p>
                <p><strong>📅 Suất chiếu:</strong> {showTime}</p>
                <p><strong>💺 Ghế:</strong> {seatInfo}</p>
                <p><strong>💰 Giá bán:</strong> {resalePrice:N0} đ</p>
            </div>
            
            <p>Cảm ơn bạn đã sử dụng dịch vụ Pass Vé!</p>
        </div>
        <div class='footer'>
            <p>© 2025 Movie Ticket System - Hệ thống đặt vé xem phim</p>
        </div>
    </div>
</body>
</html>";
        }

        // Email xác nhận mua vé pass (cho người mua)
        public string GetBuyResaleTicketTemplate(string buyerName, string movieTitle,
            string showTime, string roomName, string seatInfo, decimal originalPrice,
            decimal resalePrice, string bookingCode)
        {
            decimal savings = originalPrice - resalePrice;
            return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background: linear-gradient(135deg, #007bff 0%, #0056b3 100%); color: white; padding: 20px; text-align: center; border-radius: 10px 10px 0 0; }}
        .content {{ background: #f9f9f9; padding: 20px; border: 1px solid #ddd; }}
        .ticket-info {{ background: white; padding: 15px; border-radius: 8px; margin: 15px 0; border-left: 4px solid #007bff; }}
        .booking-code {{ font-size: 28px; color: #007bff; font-weight: bold; text-align: center; padding: 15px; background: #e7f1ff; border-radius: 8px; }}
        .savings {{ color: #28a745; font-weight: bold; }}
        .footer {{ background: #333; color: white; padding: 15px; text-align: center; border-radius: 0 0 10px 10px; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🎟️ MUA VÉ PASS THÀNH CÔNG!</h1>
        </div>
        <div class='content'>
            <p>Xin chào <strong>{buyerName}</strong>,</p>
            <p>Chúc mừng! Bạn đã mua vé pass thành công với giá ưu đãi!</p>
            
            <p><strong>Mã vé của bạn:</strong></p>
            <div class='booking-code'>{bookingCode}</div>
            
            <div class='ticket-info'>
                <p><strong>🎬 Phim:</strong> {movieTitle}</p>
                <p><strong>📅 Suất chiếu:</strong> {showTime}</p>
                <p><strong>🏠 Phòng:</strong> {roomName}</p>
                <p><strong>💺 Ghế:</strong> {seatInfo}</p>
            </div>
            
            <div class='ticket-info'>
                <p><strong>💰 Giá gốc:</strong> <s>{originalPrice:N0} đ</s></p>
                <p><strong>🏷️ Giá mua:</strong> {resalePrice:N0} đ</p>
                <p class='savings'>🎉 Bạn tiết kiệm: {savings:N0} đ!</p>
            </div>
            
            <p><strong>⚠️ Lưu ý:</strong> Vui lòng đến rạp trước giờ chiếu 15 phút và xuất trình mã vé để nhận vé.</p>
            <p>Chúc bạn xem phim vui vẻ!</p>
        </div>
        <div class='footer'>
            <p>© 2025 Movie Ticket System - Hệ thống đặt vé xem phim</p>
        </div>
    </div>
</body>
</html>";
        }
    }
}