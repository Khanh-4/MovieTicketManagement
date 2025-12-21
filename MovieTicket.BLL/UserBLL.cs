using System;
using System.Collections.Generic;
using MovieTicket.Common;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class UserBLL
    {
        private readonly UserDAL userDAL = new UserDAL();

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

        // Reset mật khẩu
        public bool ResetPassword(int userId, string newPassword)
        {
            string salt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.HashPassword(newPassword, salt);

            return userDAL.ResetPassword(userId, passwordHash, salt);
        }

        // Đổi mật khẩu
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
    }
}