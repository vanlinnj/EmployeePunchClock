using System;
using System.Collections.Generic;
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
    /// Interaction logic for frmAddModifyEmployee.xaml
    /// </summary>
    public partial class frmAddModifyEmployee : Window
    {
        public frmAddModifyEmployee()
        {
            InitializeComponent();
        }

        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidData())
            {
                Employee employee = new Employee();

                txtfName.Text = employee.FirstName;
                txtlName.Text = employee.LastName;
                txtSSN.Text = employee.SSN;
                txtAddress.Text = employee.Address;
                txtCity.Text = employee.City;
                txtState.Text = employee.State;
                txtZip.Text = employee.ZipCode;
                txtPay.Text = Convert.ToString(employee.PayRate);
                txtOvertime.Text = Convert.ToString(employee.Overtime);

                if (radioBtnYes.IsChecked == true)
                {
                    employee.IsAdmin = true;
                }
                else if (radioBtnNo.IsChecked == true)
                {
                    employee.IsAdmin = false;
                }
                else
                {
                    MessageBox.Show("You must select Yes or No for Administrator");
                }

                EmployeeData.AddEmployee(employee);
                MessageBox.Show(employee.FirstName + " has been added to the database");

            }
            else
            {
                MessageBox.Show("Check entered fields for correct data");
            }
        }//end add button click method

        private bool IsValidData()
        {
            return
                Validator.IsPresent(txtfName) &&
                Validator.IsPresent(txtlName) &&
                Validator.IsPresent(txtSSN) &&
                Validator.IsPresent(txtAddress) &&
                Validator.IsPresent(txtCity) &&
                Validator.IsPresent(txtState) &&
                Validator.IsPresent(txtZip) &&
                Validator.IsDouble(txtPay) &&
                Validator.IsDouble(txtOvertime);
                
        }//end is valid data

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
