using System;
using System.Collections.Generic;
using System.Linq;
using MovieTicket.Common;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class UserBLL
    {
        private readonly UserDAL userDAL = new UserDAL();

        // ============================================
        // LƯU TRỮ OTP TẠM THỜI
        // Key: email (lowercase), Value: (otp, expiry, userId)
        // ============================================
        private static Dictionary<string, (string otp, DateTime expiry, int userId)> _otpStorage
            = new Dictionary<string, (string, DateTime, int)>();

        #region Đăng nhập / Đăng ký

        // Đăng nhập
        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            UserDTO user = userDAL.GetByUsername(username);

            if (user == null || !user.IsActive)
                return null;

            string salt = user.PasswordSalt ?? user.Salt;
            bool isValidPassword = PasswordHelper.VerifyPassword(password, user.PasswordHash, salt);

            if (isValidPassword)
                return user;

            return null;
        }

        // Đăng ký tài khoản mới (Customer)
        public (bool success, string message) Register(string username, string password, string fullName,
            string email, string phone)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 4)
                return (false, "Username phải có ít nhất 4 ký tự!");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                return (false, "Mật khẩu phải có ít nhất 6 ký tự!");

            if (string.IsNullOrWhiteSpace(fullName))
                return (false, "Họ tên không được để trống!");

            if (userDAL.IsUsernameExists(username))
                return (false, "Username đã tồn tại!");

            if (!string.IsNullOrEmpty(email) && userDAL.IsEmailExists(email))
                return (false, "Email đã được sử dụng!");

            string salt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.HashPassword(password, salt);

            UserDTO newUser = new UserDTO
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = salt,
                Salt = salt,
                FullName = fullName,
                Email = email,
                Phone = phone,
                RoleID = 3, // Customer
                IsActive = true
            };

            int userId = userDAL.Insert(newUser);

            if (userId > 0)
                return (true, "Đăng ký thành công!");
            else
                return (false, "Đăng ký thất bại! Vui lòng thử lại.");
        }

        #endregion

        #region Quản lý User

        // Lấy user theo ID
        public UserDTO GetById(int userId)
        {
            return userDAL.GetById(userId);
        }

        // Lấy tất cả users
        public List<UserDTO> GetAll()
        {
            return userDAL.GetAll();
        }

        // Lấy users theo role
        public List<UserDTO> GetByRole(int roleId)
        {
            return userDAL.GetByRole(roleId);
        }

        // Lấy danh sách Staff (RoleID = 2)
        public List<UserDTO> GetAllStaff()
        {
            return userDAL.GetByRole(2);
        }

        // Lấy danh sách Customer (RoleID = 3)
        public List<UserDTO> GetAllCustomers()
        {
            return userDAL.GetByRole(3);
        }

        #endregion

        #region Quản lý Staff

        // Thêm Staff mới
        public int InsertStaff(UserDTO user, string password)
        {
            if (userDAL.IsUsernameExists(user.Username))
            {
                throw new Exception("Tên đăng nhập đã tồn tại!");
            }

            if (!string.IsNullOrEmpty(user.Email) && userDAL.IsEmailExists(user.Email))
            {
                throw new Exception("Email đã được sử dụng!");
            }

            string salt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.HashPassword(password, salt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = salt;
            user.Salt = salt;
            user.RoleID = 2; // Staff

            return userDAL.Insert(user);
        }

        // Cập nhật Staff
        public bool UpdateStaff(UserDTO user)
        {
            if (!string.IsNullOrEmpty(user.Email) && userDAL.IsEmailExists(user.Email, user.UserID))
            {
                throw new Exception("Email đã được sử dụng!");
            }

            return userDAL.Update(user);
        }

        // Xóa Staff
        public bool DeleteStaff(int userId)
        {
            if (userDAL.HasBookings(userId))
            {
                throw new Exception("Không thể xóa nhân viên đã có giao dịch!");
            }

            return userDAL.Delete(userId);
        }

        #endregion

        #region Đổi mật khẩu

        // Reset mật khẩu (Admin reset cho user khác)
        public bool ResetPassword(int userId, string newPassword)
        {
            string salt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.HashPassword(newPassword, salt);

            return userDAL.ResetPassword(userId, passwordHash, salt);
        }

        // Đổi mật khẩu (User tự đổi)
        public (bool success, string message) ChangePassword(int userId, string oldPassword, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                return (false, "Mật khẩu mới phải có ít nhất 6 ký tự!");

            UserDTO user = userDAL.GetById(userId);
            if (user == null)
                return (false, "Không tìm thấy người dùng!");

            string salt = user.PasswordSalt ?? user.Salt;
            if (!PasswordHelper.VerifyPassword(oldPassword, user.PasswordHash, salt))
                return (false, "Mật khẩu cũ không đúng!");

            string newSalt = PasswordHelper.GenerateSalt();
            string newHash = PasswordHelper.HashPassword(newPassword, newSalt);

            bool result = userDAL.UpdatePassword(userId, newHash, newSalt);

            if (result)
                return (true, "Đổi mật khẩu thành công!");
            else
                return (false, "Đổi mật khẩu thất bại!");
        }

        #endregion

        #region Quên mật khẩu - OTP qua Email

        /// <summary>
        /// Gửi mã OTP để reset mật khẩu
        /// </summary>
        /// <param name="email">Email đã đăng ký</param>
        /// <returns>(success, message)</returns>
        public (bool success, string message) SendResetPasswordOTP(string email)
        {
            // Validate email
            if (string.IsNullOrWhiteSpace(email))
                return (false, "Vui lòng nhập email!");

            // Chuẩn hóa email
            email = email.Trim().ToLower();

            // Kiểm tra email có tồn tại trong hệ thống không
            UserDTO user = userDAL.GetByEmail(email);
            if (user == null)
                return (false, "Email không tồn tại trong hệ thống!");

            // Kiểm tra tài khoản có đang active không
            if (!user.IsActive)
                return (false, "Tài khoản đã bị khóa!");

            // Tạo mã OTP 6 số
            string otpCode = EmailHelper.GenerateOTP();

            // Thời gian hết hạn (5 phút)
            int expiryMinutes = 5;
            DateTime expiryTime = DateTime.Now.AddMinutes(expiryMinutes);

            // Lưu OTP vào bộ nhớ tạm
            _otpStorage[email] = (otpCode, expiryTime, user.UserID);

            // Gửi email
            bool emailSent = EmailHelper.SendOTPEmail(user.Email, otpCode, user.FullName);

            if (emailSent)
            {
                // Ẩn một phần email để hiển thị
                string maskedEmail = MaskEmail(user.Email);
                return (true, $"Mã xác nhận đã được gửi đến email {maskedEmail}");
            }
            else
            {
                // Xóa OTP nếu gửi email thất bại
                _otpStorage.Remove(email);
                return (false, "Không thể gửi email. Vui lòng thử lại sau!");
            }
        }

        /// <summary>
        /// Xác thực mã OTP
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="otpCode">Mã OTP người dùng nhập</param>
        /// <returns>(success, message, userId)</returns>
        public (bool success, string message, int userId) VerifyOTP(string email, string otpCode)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(otpCode))
                return (false, "Vui lòng nhập đầy đủ thông tin!", 0);

            // Chuẩn hóa
            email = email.Trim().ToLower();
            otpCode = otpCode.Trim();

            // Kiểm tra có OTP cho email này không
            if (!_otpStorage.ContainsKey(email))
                return (false, "Mã xác nhận không hợp lệ hoặc đã hết hạn!", 0);

            var (storedOtp, expiry, userId) = _otpStorage[email];

            // Kiểm tra hết hạn
            if (DateTime.Now > expiry)
            {
                _otpStorage.Remove(email); // Xóa OTP hết hạn
                return (false, "Mã xác nhận đã hết hạn. Vui lòng yêu cầu mã mới!", 0);
            }

            // Kiểm tra mã OTP (không phân biệt hoa thường)
            if (!storedOtp.Equals(otpCode, StringComparison.OrdinalIgnoreCase))
                return (false, "Mã xác nhận không đúng!", 0);

            // OTP đúng - giữ lại để dùng cho bước đổi mật khẩu
            return (true, "Xác thực thành công!", userId);
        }

        /// <summary>
        /// Đặt mật khẩu mới (sau khi xác thực OTP)
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="newPassword">Mật khẩu mới</param>
        /// <param name="confirmPassword">Xác nhận mật khẩu mới</param>
        /// <returns>(success, message)</returns>
        public (bool success, string message) ResetPasswordWithOTP(string email, string newPassword, string confirmPassword)
        {
            // Validate mật khẩu mới
            if (string.IsNullOrWhiteSpace(newPassword))
                return (false, "Vui lòng nhập mật khẩu mới!");

            if (newPassword.Length < 6)
                return (false, "Mật khẩu phải có ít nhất 6 ký tự!");

            if (newPassword != confirmPassword)
                return (false, "Mật khẩu xác nhận không khớp!");

            // Chuẩn hóa email
            email = email.Trim().ToLower();

            // Kiểm tra OTP đã được xác thực chưa
            if (!_otpStorage.ContainsKey(email))
                return (false, "Phiên làm việc đã hết hạn. Vui lòng thử lại!");

            var (_, expiry, userId) = _otpStorage[email];

            // Kiểm tra hết hạn
            if (DateTime.Now > expiry)
            {
                _otpStorage.Remove(email);
                return (false, "Phiên làm việc đã hết hạn. Vui lòng thử lại!");
            }

            // Tạo Salt và Hash mới
            string newSalt = PasswordHelper.GenerateSalt();
            string newHash = PasswordHelper.HashPassword(newPassword, newSalt);

            // Cập nhật mật khẩu trong database
            bool result = userDAL.UpdatePassword(userId, newHash, newSalt);

            if (result)
            {
                // Xóa OTP đã sử dụng
                _otpStorage.Remove(email);

                // Gửi email thông báo (không bắt buộc thành công)
                try
                {
                    UserDTO user = userDAL.GetById(userId);
                    if (user != null)
                    {
                        EmailHelper.SendPasswordChangedNotification(user.Email, user.FullName);
                    }
                }
                catch
                {
                    // Bỏ qua lỗi gửi email thông báo
                }

                return (true, "Đặt lại mật khẩu thành công! Vui lòng đăng nhập với mật khẩu mới.");
            }

            return (false, "Đặt lại mật khẩu thất bại. Vui lòng thử lại!");
        }

        /// <summary>
        /// Xóa các OTP đã hết hạn (gọi định kỳ nếu cần)
        /// </summary>
        public void CleanupExpiredOTPs()
        {
            var expiredKeys = _otpStorage
                .Where(x => DateTime.Now > x.Value.expiry)
                .Select(x => x.Key)
                .ToList();

            foreach (var key in expiredKeys)
            {
                _otpStorage.Remove(key);
            }
        }

        /// <summary>
        /// Ẩn một phần email để bảo mật
        /// Ví dụ: example@gmail.com -> exa***@gmail.com
        /// </summary>
        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                return email;

            var parts = email.Split('@');
            string name = parts[0];
            string domain = parts[1];

            if (name.Length <= 3)
                return name[0] + "***@" + domain;

            return name.Substring(0, 3) + "***@" + domain;
        }

        #endregion
    }
}