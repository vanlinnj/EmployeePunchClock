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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseProject
{
    //USE TAB CONTROL

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee currentLogIn;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            int employeeID = Convert.ToInt32(txtBoxEmployeeID.Text);
            currentLogIn = EmployeeData.GetEmployee(employeeID);
            if(currentLogIn != null)
            {
                if(currentLogIn.IsAdmin)
                {
                   
                    frmAddModifyEmployee addModifyEmployee = new frmAddModifyEmployee();
                    addModifyEmployee.Show();
                }
                else
                {
                    frmEmployeeDetails employeeDetails = new frmEmployeeDetails();
                    employeeDetails.Show();
                }
            }
            else
            {
                MessageBox.Show("There was no employee found for that Employee ID.\nPlease enter in Employee ID again.");
            }           
        }

        
        private void btnPunch_Click(object sender, RoutedEventArgs e)
        {
            List<Punch> punched;
            bool newPunchType;
            Punch insertingPunch = new Punch();

            Employee employeeThatIsPunching;

            int employeeID = Convert.ToInt32(txtBoxEmployeeID.Text);

            employeeThatIsPunching = EmployeeData.GetEmployee(employeeID);
            if (employeeThatIsPunching != null)
            {

                punched = PunchData.ReadPunchEmployeeID(employeeID);

                //if no punches you are punched in
                if (punched.Count == 0)
                {
                    newPunchType = true;
                }
                //if latest punch in list is punched in then you will be punched out
                else if (punched[0].PunchType == true)
                {
                    newPunchType = false;
                }
                //if latest punch in list is NOT PUNCHED IN, you are punched in
                else
                {
                    newPunchType = true;
                }

                insertingPunch.DateTime = DateTime.Now;
                insertingPunch.EmployeeID = employeeID;
                insertingPunch.PunchType = newPunchType;
                PunchData.InsertPunch(insertingPunch);

                MessageBox.Show("Punch " + insertingPunch.getPunchType() + " successful");
            }
            else
            {
                MessageBox.Show("No employee found.");
            }
            List<Punch> currentPunchData = PunchData.ReadPunchEmployeeID(employeeID);
            PayrollData.write(currentPunchData, "report.xml");
        }

        private void btnListEmployees_Click(object sender, RoutedEventArgs e)
        {
            frmListAllEmployees listAllEmployees = new frmListAllEmployees();
            listAllEmployees.Show();
        }
    }
}
