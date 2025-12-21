using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Common
{
    public static class FormatHelper
    {
        // Format tiền VNĐ
        public static string FormatCurrency(decimal amount)
        {
            return string.Format("{0:N0} đ", amount);
        }

        // Format ngày giờ
        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm");
        }

        // Format ngày
        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        // Format thời gian
        public static string FormatTime(DateTime time)
        {
            return time.ToString("HH:mm");
        }

        // Format thời lượng phim (phút -> giờ:phút)
        public static string FormatDuration(int minutes)
        {
            int hours = minutes / 60;
            int mins = minutes % 60;
            return $"{hours}h {mins}m";
        }

        // Format số điện thoại (0901234567 -> 0901 234 567)
        public static string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone) || phone.Length != 10)
                return phone;

            return $"{phone.Substring(0, 4)} {phone.Substring(4, 3)} {phone.Substring(7, 3)}";
        }
    }
}
