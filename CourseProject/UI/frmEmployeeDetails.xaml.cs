using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for frmEmployeeDetails.xaml
    /// </summary>
    public partial class frmEmployeeDetails : Window
    {
        public frmEmployeeDetails()
        {
            InitializeComponent();
        }

        private Employee selectedEmployee;

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            //check to see if employee is admin
            //if employee is admin open up admin form
            //if employee is not admin then check employee id to employee id in database
            if(Validator.IsPresent(txtEmployeeID) && Validator.IsInt32(txtEmployeeID))
            {
                int employeeID = Convert.ToInt32(txtEmployeeID.Text);
                this.GetEmployee(employeeID);
                if(selectedEmployee == null)
                {
                    MessageBox.Show("No employee found with this ID. " + "Please Try again.");                  
                }
                else
                {
                    this.DisplayEmployee();
                }
            }
           
        }//end btnLoad_Click

        private void GetEmployee(int EmployeeID)
        {
            try
            {
                selectedEmployee = EmployeeData.GetEmployee(EmployeeID);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
           
        }//end of get employee

        
        private void DisplayEmployee()
        {
            txtfName.Text = selectedEmployee.FirstName;
            txtlName.Text = selectedEmployee.LastName;
            txtStreet.Text = selectedEmployee.Address;
            txtCity.Text = selectedEmployee.City;
            txtState.Text = selectedEmployee.State;
            txtZip.Text = selectedEmployee.ZipCode;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(IsValidData())
            {
                Employee updatedEmployee = new Employee();
                updatedEmployee.EmployeeID = selectedEmployee.EmployeeID;
                this.PutEmployeeData(updatedEmployee);
                try
                {
                    if(!EmployeeData.UpdateEmployee(selectedEmployee, updatedEmployee))
                    {
                        MessageBox.Show("Another user has updated or deleted this employee.");                       
                    }
                    else
                    {
                        selectedEmployee = updatedEmployee;
                        MessageBox.Show("Update Successful");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }//end btnSave_Click

        private bool IsValidData()
        {
            return
                Validator.IsPresent(txtfName) &&
                Validator.IsPresent(txtlName) &&
                Validator.IsPresent(txtStreet) &&
                Validator.IsPresent(txtCity) &&
                Validator.IsPresent(txtState) &&
                Validator.IsPresent(txtZip);
        }//end is valid data

        private void PutEmployeeData(Employee selectedEmployee)
        {
            selectedEmployee.FirstName = txtfName.Text;
            selectedEmployee.LastName = txtlName.Text; 
            selectedEmployee.Address = txtStreet.Text;
            selectedEmployee.City = txtCity.Text;
            selectedEmployee.State = txtState.Text;
            selectedEmployee.ZipCode = txtZip.Text;
        }

        
    }
}
