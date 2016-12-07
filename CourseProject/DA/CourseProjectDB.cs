using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    class CourseProjectDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CourseProjectDB.mdf";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
