using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int RoleID { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        // Thông tin bổ sung từ bảng ROLES
        public string RoleName { get; set; }

        public string PasswordSalt { get; set; }
    }
}
