using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelBookingManagement
{
    class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection()
        {
            connectionString = @"Data Source=LAPTOP-NH0TVHME\SQLEXPRESSG2DEC;Initial Catalog=SEMD022 G2;User ID=sa;Password=041206";
        }

        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int ExecuteNonTableQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return 1;
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex);
                return 0;
            }
        }

        public DataTable ExecuteTableQuery(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                dt.Load(command.ExecuteReader());
                command.Dispose();
                connection.Close();
                return dt;
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
