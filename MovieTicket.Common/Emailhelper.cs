using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MovieTicket.Common
{
    public static class EmailHelper
    {
        // Đọc cấu hình từ App.config
        private static readonly string SmtpHost = ConfigurationManager.AppSettings["SmtpHost"] ?? "smtp.gmail.com";
        private static readonly int SmtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
        private static readonly string SmtpEmail = ConfigurationManager.AppSettings["SmtpEmail"] ?? "";
        private static readonly string SmtpPassword = ConfigurationManager.AppSettings["SmtpPassword"] ?? "";
        private static readonly string SmtpDisplayName = ConfigurationManager.AppSettings["SmtpDisplayName"] ?? "Movie Ticket System";

        /// <summary>
        /// Gửi email
        /// </summary>
        /// <param name="toEmail">Email người nhận</param>
        /// <param name="subject">Tiêu đề</param>
        /// <param name="body">Nội dung (có thể dùng HTML)</param>
        /// <param name="isHtml">Nội dung có phải HTML không</param>
        /// <returns>True nếu gửi thành công</returns>
        public static bool SendEmail(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                // Kiểm tra cấu hình
                if (string.IsNullOrEmpty(SmtpEmail) || string.IsNullOrEmpty(SmtpPassword))
                {
                    throw new Exception("Chưa cấu hình email trong App.config!");
                }

                // Tạo MailMessage
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(SmtpEmail, SmtpDisplayName);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isHtml;

                // Cấu hình SMTP Client
                SmtpClient smtp = new SmtpClient(SmtpHost, SmtpPort);
                smtp.Credentials = new NetworkCredential(SmtpEmail, SmtpPassword);
                smtp.EnableSsl = true; // Gmail yêu cầu SSL
                smtp.Timeout = 30000; // 30 giây timeout

                // Gửi email
                smtp.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                // Log lỗi (có thể ghi vào file log)
                System.Diagnostics.Debug.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gửi email bất đồng bộ (không block UI)
        /// </summary>
        public static async Task<bool> SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                if (string.IsNullOrEmpty(SmtpEmail) || string.IsNullOrEmpty(SmtpPassword))
                {
                    throw new Exception("Chưa cấu hình email trong App.config!");
                }

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(SmtpEmail, SmtpDisplayName);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isHtml;

                SmtpClient smtp = new SmtpClient(SmtpHost, SmtpPort);
                smtp.Credentials = new NetworkCredential(SmtpEmail, SmtpPassword);
                smtp.EnableSsl = true;
                smtp.Timeout = 30000;

                await smtp.SendMailAsync(mail);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tạo mã OTP ngẫu nhiên 6 số
        /// </summary>
        public static string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // 6 chữ số
        }

        /// <summary>
        /// Gửi email chứa mã OTP để reset mật khẩu
        /// </summary>
        /// <param name="toEmail">Email người nhận</param>
        /// <param name="otpCode">Mã OTP</param>
        /// <param name="fullName">Tên người dùng</param>
        /// <returns>True nếu gửi thành công</returns>
        public static bool SendOTPEmail(string toEmail, string otpCode, string fullName)
        {
            string subject = "🔐 Mã xác nhận đặt lại mật khẩu - Movie Ticket System";

            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
</head>
<body style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>
    <div style='background: linear-gradient(135deg, #1a1a2e 0%, #16213e 100%); padding: 30px; border-radius: 10px;'>
        <h1 style='color: #ffd700; text-align: center; margin: 0;'>🎬 Movie Ticket System</h1>
    </div>
    
    <div style='background: #f9f9f9; padding: 30px; border-radius: 0 0 10px 10px;'>
        <h2 style='color: #333;'>Xin chào {fullName},</h2>
        
        <p style='color: #555; font-size: 16px;'>
            Bạn đã yêu cầu đặt lại mật khẩu cho tài khoản của mình.
        </p>
        
        <p style='color: #555; font-size: 16px;'>
            Mã xác nhận của bạn là:
        </p>
        
        <div style='background: #1a1a2e; padding: 20px; border-radius: 10px; text-align: center; margin: 20px 0;'>
            <span style='font-size: 36px; font-weight: bold; color: #ffd700; letter-spacing: 8px;'>{otpCode}</span>
        </div>
        
        <p style='color: #e74c3c; font-size: 14px;'>
            ⚠️ <strong>Lưu ý:</strong> Mã này có hiệu lực trong <strong>5 phút</strong>.
        </p>
        
        <p style='color: #555; font-size: 14px;'>
            Nếu bạn không yêu cầu đặt lại mật khẩu, vui lòng bỏ qua email này.
        </p>
        
        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;'>
        
        <p style='color: #999; font-size: 12px; text-align: center;'>
            Email này được gửi tự động từ Movie Ticket System.<br>
            Vui lòng không trả lời email này.
        </p>
    </div>
</body>
</html>";

            return SendEmail(toEmail, subject, body, true);
        }

        /// <summary>
        /// Gửi email thông báo mật khẩu đã được thay đổi
        /// </summary>
        public static bool SendPasswordChangedNotification(string toEmail, string fullName)
        {
            string subject = "✅ Mật khẩu đã được thay đổi - Movie Ticket System";

            string body = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
</head>
<body style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>
    <div style='background: linear-gradient(135deg, #1a1a2e 0%, #16213e 100%); padding: 30px; border-radius: 10px;'>
        <h1 style='color: #ffd700; text-align: center; margin: 0;'>🎬 Movie Ticket System</h1>
    </div>
    
    <div style='background: #f9f9f9; padding: 30px; border-radius: 0 0 10px 10px;'>
        <h2 style='color: #333;'>Xin chào {fullName},</h2>
        
        <div style='background: #d4edda; border: 1px solid #c3e6cb; padding: 15px; border-radius: 5px; margin: 20px 0;'>
            <p style='color: #155724; margin: 0; font-size: 16px;'>
                ✅ Mật khẩu của bạn đã được thay đổi thành công!
            </p>
        </div>
        
        <p style='color: #555; font-size: 14px;'>
            Thời gian thay đổi: <strong>{DateTime.Now:dd/MM/yyyy HH:mm:ss}</strong>
        </p>
        
        <p style='color: #e74c3c; font-size: 14px;'>
            ⚠️ Nếu bạn không thực hiện thay đổi này, vui lòng liên hệ ngay với chúng tôi!
        </p>
        
        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;'>
        
        <p style='color: #999; font-size: 12px; text-align: center;'>
            Email này được gửi tự động từ Movie Ticket System.<br>
            Vui lòng không trả lời email này.
        </p>
    </div>
</body>
</html>";

            return SendEmail(toEmail, subject, body, true);
        }
    }
}