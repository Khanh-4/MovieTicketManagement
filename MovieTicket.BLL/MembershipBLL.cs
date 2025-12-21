using System.Collections.Generic;
using MovieTicket.DAL;
using MovieTicket.DTO;

namespace MovieTicket.BLL
{
    public class MembershipBLL
    {
        private readonly MembershipDAL membershipDAL = new MembershipDAL();

        // Lấy membership theo UserID
        public MembershipDTO GetByUserId(int userId)
        {
            return membershipDAL.GetByUserId(userId);
        }

        // Tạo membership cho user mới
        public int CreateMembership(int userId)
        {
            return membershipDAL.Insert(userId);
        }

        // Cộng điểm
        public bool AddPoints(int membershipId, int points, string description)
        {
            return membershipDAL.AddPoints(membershipId, points, description);
        }

        // Lấy lịch sử điểm
        public List<PointTransactionDTO> GetPointHistory(int membershipId)
        {
            return membershipDAL.GetPointHistory(membershipId);
        }

        // Lấy tất cả loại hội viên
        public List<MembershipTypeDTO> GetAllTypes()
        {
            return membershipDAL.GetAllTypes();
        }
    }
}