using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Common
{
    public static class QRCodeHelper
    {
        // Tạo nội dung QR Code cho vé
        public static string GenerateTicketQRContent(string bookingCode, int bookingId, DateTime showtime)
        {
            // Format: BOOKING_CODE|BOOKING_ID|SHOWTIME
            return $"{bookingCode}|{bookingId}|{showtime:yyyyMMddHHmm}";
        }

        // Giải mã nội dung QR Code
        public static (string bookingCode, int bookingId, DateTime showtime) ParseTicketQRContent(string qrContent)
        {
            try
            {
                string[] parts = qrContent.Split('|');
                if (parts.Length == 3)
                {
                    string bookingCode = parts[0];
                    int bookingId = int.Parse(parts[1]);
                    DateTime showtime = DateTime.ParseExact(parts[2], "yyyyMMddHHmm", null);
                    return (bookingCode, bookingId, showtime);
                }
            }
            catch
            {
                // Lỗi parse
            }
            return (null, 0, DateTime.MinValue);
        }
    }
}
