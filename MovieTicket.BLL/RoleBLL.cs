using MovieTicket.BLL;
using MovieTicket.DAL;
using MovieTicket.DTO;
using System.Collections.Generic;

namespace MovieTicket.BLL
{
    public class RoleBLL
    {
        private readonly RoleDAL roleDAL = new RoleDAL();

        // Lấy tất cả roles
        public List<RoleDTO> GetAll()
        {
            return roleDAL.GetAll();
        }

        // Lấy role theo ID
        public RoleDTO GetById(int roleId)
        {
            return roleDAL.GetById(roleId);
        }
    }
}
