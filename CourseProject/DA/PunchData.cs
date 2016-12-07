using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public class PunchData
    {
        //Creates new punch
        public static void InsertPunch(Punch data)
        { 

            List<string> myList = new List<string>();

            SqlConnection conn = CourseProjectDB.GetConnection();

            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Tb_Punch (employeeID, dateTime, punchType) VALUES (@EmployeeID, @DateTime, @PunchType);", conn);
            cmd.Parameters.AddWithValue("@EmployeeID", data.EmployeeID);
            cmd.Parameters.AddWithValue("@DateTime", data.DateTime);
            cmd.Parameters.AddWithValue("@PunchType", data.PunchType);

            cmd.ExecuteNonQuery();
            
            conn.Close();

        }//end insertPunch

        //Reads latest punch by Employee ID
        public static List<Punch> ReadPunchEmployeeID(int employeeID)
        {
            
            List<Punch> punchList = new List<Punch>();

            SqlConnection conn = CourseProjectDB.GetConnection();
            //conn.Open();

            string selectStatement
                = "SELECT PunchID, EmployeeID, DateTime, PunchType "
                + "FROM Tb_Punch "
                + "WHERE EmployeeID = @EmployeeID " 
                + "Order by DateTime desc";
            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);
            selectCommand.Parameters.AddWithValue("@EmployeeID", employeeID);

            try
            {
                conn.Open();
                SqlDataReader punchReader = selectCommand.ExecuteReader();
                while(punchReader.Read())
                {
                    Punch punch = new Punch();
                    punch.EmployeeID = (int)punchReader["EmployeeID"];
                    punch.PunchID = (int)punchReader["PunchID"];
                    punch.PunchType = (bool)punchReader["PunchType"];
                    punch.DateTime = (DateTime.Parse(punchReader["DateTime"].ToString()));
                    punchList.Add(punch);
                }
                
            }
            catch(SqlException ex)
            {
                conn.Close();
                throw ex;
            }
            conn.Close();
            return punchList;
        }//end of read punch

        //Reads punches through date range. Used in Payroll sheet
        public static List<Punch> ReadPunchDateRange(DateTime startDate, DateTime endDate)
        {
            List<Punch> punchList = new List<Punch>();

            SqlConnection conn = CourseProjectDB.GetConnection();

            string selectStatement
                = "SELECT PunchID, EmployeeID, DateTime, PunchType "
                + "FROM Tb_Punch "
                + "WHERE DateTime >= @startDate AND DateTime <= @endDate";
            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);
            selectCommand.Parameters.AddWithValue("@startDate", startDate);
            selectCommand.Parameters.AddWithValue("@endDate", endDate);

            try
            {
                conn.Open();
                SqlDataReader punchReader = selectCommand.ExecuteReader();
                while (punchReader.Read())
                {
                    Punch punch = new Punch();
                    punch.EmployeeID = (int)punchReader["EmployeeID"];
                    punch.PunchID = (int)punchReader["PunchID"];
                    punch.PunchType = (bool)punchReader["PunchType"];
                    punch.DateTime = (DateTime.Parse(punchReader["DateTime"].ToString()));
                    punchList.Add(punch);
                }

            }
            catch (SqlException ex)
            {
                conn.Close();
                throw ex;
            }
            conn.Close();
            return punchList;
        }

        //Update a punch in the system
        public static bool UpdatePunch(Punch punch)
        {
            SqlConnection conn = CourseProjectDB.GetConnection();

            string updateStatement =
                "UPDATE Tb_Punch SET " +
                "EmployeeID = @EmployeeID, " +
                "PunchType = @PunchType, " +
                "DateTime = @DateTime " +
                "WHERE PunchID = @PunchID";

            SqlCommand updateCommand = new SqlCommand(updateStatement, conn);
            updateCommand.Parameters.AddWithValue("@EmployeeID", punch.EmployeeID);
            updateCommand.Parameters.AddWithValue("@PunchType", punch.PunchType);
            updateCommand.Parameters.AddWithValue("@DateTime", punch.DateTime);

            try
            {
                conn.Open();
                int count = updateCommand.ExecuteNonQuery();
                conn.Close();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                conn.Close();
                throw ex;
            }

            
        }//end UpdatePunch

        //Delete punch in system
        public static bool DeletePunch(Punch punch)
        {
            SqlConnection conn = CourseProjectDB.GetConnection();

            string deleteStatement =
                "DELETE FROM Tb_Punch " +
                "WHERE PunchID = @PunchID";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn);

            deleteCommand.Parameters.AddWithValue("@PunchID", punch.PunchID);

            try
            {
                conn.Open();
                int count = deleteCommand.ExecuteNonQuery();
                conn.Close();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(SqlException ex)
            {
                conn.Close();
                throw ex;
            }
           
        }//end DeletePunch

        public static bool DeleteAllPunchesForEmployee(int employeeID)
        {

            SqlConnection conn = CourseProjectDB.GetConnection();

            string deleteStatement =
                "DELETE FROM Tb_Punch " +
                "WHERE EmployeeID = @EmployeeID";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn);

            deleteCommand.Parameters.AddWithValue("@EmployeeID", employeeID);

            try
            {
                conn.Open();
                int count = deleteCommand.ExecuteNonQuery();
                conn.Close();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                conn.Close();
                throw ex;
            }
        }//end DeleteAllPunches
        
    }//end class PunchData
}//end namespace CourseProject
