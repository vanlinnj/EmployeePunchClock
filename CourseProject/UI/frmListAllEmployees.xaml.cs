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
    /// Interaction logic for frmListAllEmployees.xaml
    /// </summary>
    public partial class frmListAllEmployees : Window
    {
        public CourseProject.CourseProjectDBDataSet courseProjectDBDataSet; 
        public CourseProject.CourseProjectDBDataSetTableAdapters.Tb_EmployeeTableAdapter courseProjectDBDataSetTb_EmployeeTableAdapter;
        public System.Windows.Data.CollectionViewSource tb_EmployeeViewSource;

        public frmListAllEmployees()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            courseProjectDBDataSet = ((CourseProject.CourseProjectDBDataSet)(this.FindResource("courseProjectDBDataSet")));
            // Load data into the table Tb_Employee. You can modify this code as needed.
            courseProjectDBDataSetTb_EmployeeTableAdapter = new CourseProject.CourseProjectDBDataSetTableAdapters.Tb_EmployeeTableAdapter();
            courseProjectDBDataSetTb_EmployeeTableAdapter.Fill(courseProjectDBDataSet.Tb_Employee);
            tb_EmployeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tb_EmployeeViewSource")));
            tb_EmployeeViewSource.View.MoveCurrentToFirst();
        }

       
    }
}
