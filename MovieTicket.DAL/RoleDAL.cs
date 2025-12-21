using Microsoft.Data.SqlClient;
using MovieTicket.DAL;
using MovieTicket.DTO;
using System;
using System.Collections.Generic;

namespace MovieTicket.DAL
{
    public class RoleDAL
    {
        // Lấy tất cả roles
        public List<RoleDTO> GetAll()
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            string query = "SELECT * FROM ROLES ORDER BY RoleID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add(new RoleDTO
                    {
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        Description = reader["Description"]?.ToString()
                    });
                }
            }
            return roles;
        }

        // Lấy role theo ID
        public RoleDTO GetById(int roleId)
        {
            RoleDTO role = null;
            string query = "SELECT * FROM ROLES WHERE RoleID = @RoleID";

            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoleID", roleId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    role = new RoleDTO
                    {
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        Description = reader["Description"]?.ToString()
                    };
                }
            }
            return role;
        }
    }
}
