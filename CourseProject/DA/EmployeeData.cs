using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    public static class EmployeeData
    {

        //Reads Employee Data from DB
        public static Employee GetEmployee(int employeeID)
        {
            SqlConnection conn = CourseProjectDB.GetConnection();

            string selectStatement
                    = "SELECT EmployeeID, FirstName, LastName, SSN, Address, City, State, ZipCode, PayRate, Overtime, IsAdmin "
                    + "FROM Tb_Employee "
                    + "WHERE EmployeeID = @EmployeeID";
            SqlCommand selectCmd = new SqlCommand(selectStatement, conn);

            selectCmd.Parameters.AddWithValue("@EmployeeID", employeeID);

            try
            {
                conn.Open();
                SqlDataReader employeeReader = selectCmd.ExecuteReader(CommandBehavior.SingleRow);
                if(employeeReader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = (int)employeeReader["EmployeeID"];
                    employee.FirstName = employeeReader["FirstName"].ToString();
                    employee.LastName = employeeReader["LastName"].ToString();
                    employee.Address = employeeReader["Address"].ToString();
                    employee.City = employeeReader["City"].ToString();
                    employee.State = employeeReader["State"].ToString();
                    employee.ZipCode = employeeReader["ZipCode"].ToString();
                    //employee.PayRate = (float)employeeReader["PayRate"];
                    //employee.Overtime = (float)employeeReader["Overtime"];
                    employee.IsAdmin = (bool)employeeReader["IsAdmin"];
                    return employee;
                }
                else
                {
                    return null; 
                }
            } 
            catch(SqlException ex)
            {
                conn.Close();
                throw ex;
            }
            
        }//end of GetEmployee

        //Update Employee info in DB
        public static bool UpdateEmployee(Employee oldEmployee, Employee newEmployee)
        {
            SqlConnection conn = CourseProjectDB.GetConnection();

            string updateStatement =
                "UPDATE Tb_Employee SET " +
                "FirstName = @NewFirstName, " +
                "LastName = @NewLastName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE EmployeeID = @OldEmployeeID " +
                "AND FirstName = @OldFirstName " +
                "AND LastName = @OldLastName " +
                "AND Address = @OldAddress " +
                "AND City = @OldCity " +
                "AND State = @OldState " +
                "AND ZipCode = @OldZipCode";
            SqlCommand updateCommand = new SqlCommand(updateStatement, conn);
            updateCommand.Parameters.AddWithValue("@NewFirstName", newEmployee.FirstName);
            updateCommand.Parameters.AddWithValue("@NewLastName", newEmployee.LastName);
            updateCommand.Parameters.AddWithValue("@NewAddress", newEmployee.Address);
            updateCommand.Parameters.AddWithValue("@NewCity", newEmployee.City);
            updateCommand.Parameters.AddWithValue("@NewState", newEmployee.State);
            updateCommand.Parameters.AddWithValue("@NewZipCode", newEmployee.ZipCode);

            updateCommand.Parameters.AddWithValue("@OldEmployeeID", oldEmployee.EmployeeID);
            updateCommand.Parameters.AddWithValue("@OldFirstName", oldEmployee.FirstName);
            updateCommand.Parameters.AddWithValue("@OldLastName", oldEmployee.LastName);
            updateCommand.Parameters.AddWithValue("@OldAddress", oldEmployee.Address);
            updateCommand.Parameters.AddWithValue("@OldCity", oldEmployee.City);
            updateCommand.Parameters.AddWithValue("@OldState", oldEmployee.State);
            updateCommand.Parameters.AddWithValue("@OldZipCode", oldEmployee.ZipCode);
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
           
        }//end UpdateEmployee method

        //Create new employee in DB
        public static int AddEmployee(Employee employee)
        {
            SqlConnection conn = CourseProjectDB.GetConnection();

            string insertStatement =
                "INSERT INTO Tb_Employee " +
                "(FirstName, LastName, SSN, Address, City, State, ZipCode, PayRate, Overtime, IsAdmin) " +
                "VALUES (@FirstName, @LastName, @SSN, @Address, @City, @State, @ZipCode, @PayRate, @Overtime, @IsAdmin)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, conn);
            insertCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
            insertCommand.Parameters.AddWithValue("@LastName", employee.LastName);
            insertCommand.Parameters.AddWithValue("@SSN", employee.SSN);
            insertCommand.Parameters.AddWithValue("@Address", employee.Address);
            insertCommand.Parameters.AddWithValue("@City", employee.City);
            insertCommand.Parameters.AddWithValue("@State", employee.State);
            insertCommand.Parameters.AddWithValue("@ZipCode", employee.ZipCode);
            insertCommand.Parameters.AddWithValue("@PayRate", employee.PayRate);
            insertCommand.Parameters.AddWithValue("@Overtime", employee.Overtime);
            insertCommand.Parameters.AddWithValue("@IsAdmin", employee.IsAdmin);

            try
            {
                conn.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement = "SELECT IDENT_CURRENT('Tb_Employee') FROM Tb_Employee";
                SqlCommand selectCommand = new SqlCommand(selectStatement, conn);
                int employeeID = Convert.ToInt32(selectCommand.ExecuteScalar());
                conn.Close();
                return employeeID;
            }
            catch(SqlException ex)
            {
                conn.Close();
                throw ex;
            }
            
        }//end AddEmployee

        //Delete employee from DB
        public static bool DeleteEmployee(Employee employee)
        {
            SqlConnection conn = CourseProjectDB.GetConnection();

            string deleteStatement =
                "DELETE FROM Tb_Employee " +
                "WHERE EmployeeID = @EmployeeID";
                
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn);

            deleteCommand.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

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
            
        }//end DeleteEmployee
    }
}
