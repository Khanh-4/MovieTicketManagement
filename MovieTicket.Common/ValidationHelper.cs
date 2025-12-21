using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieTicket.Common
{
    public static class ValidationHelper
    {
        // Kiểm tra email hợp lệ
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Kiểm tra số điện thoại Việt Nam
        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Số điện thoại VN: 10 số, bắt đầu bằng 0
            string pattern = @"^0\d{9}$";
            return Regex.IsMatch(phone, pattern);
        }

        // Kiểm tra username hợp lệ (chỉ chữ, số, gạch dưới, 4-20 ký tự)
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            string pattern = @"^[a-zA-Z0-9_]{4,20}$";
            return Regex.IsMatch(username, pattern);
        }

        // Kiểm tra password đủ mạnh (ít nhất 6 ký tự)
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return password.Length >= 6;
        }

        // Kiểm tra chuỗi không rỗng
        public static bool IsNotEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        // Kiểm tra tuổi (phải >= minAge)
        public static bool IsValidAge(DateTime? dateOfBirth, int minAge = 0)
        {
            if (!dateOfBirth.HasValue)
                return true; // Cho phép không nhập ngày sinh

            int age = DateTime.Today.Year - dateOfBirth.Value.Year;
            if (dateOfBirth.Value.Date > DateTime.Today.AddYears(-age))
                age--;

            return age >= minAge;
        }
    }
}
