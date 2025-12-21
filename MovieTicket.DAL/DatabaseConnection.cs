using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MovieTicket.DAL
{
    public class DatabaseConnection
    {
        // Lấy connection string từ App.config
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["MovieTicketDB"].ConnectionString;

        // Lấy connection string
        public static string GetConnectionString()
        {
            return connectionString;
        }

        // Tạo và mở kết nối mới
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        // Test kết nối
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
