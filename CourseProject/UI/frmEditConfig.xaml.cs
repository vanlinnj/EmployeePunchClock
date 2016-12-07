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

namespace program9
{
    /// <summary>
    /// Interaction logic for frmEditConfig.xaml
    /// </summary>
    public partial class frmEditConfig : Window
    {
        public frmEditConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Config currentData = new Config();
            currentData.Name = txtName.Text;
            currentData.Address = txtAddress.Text;
            currentData.City = txtCity.Text;
            currentData.State = txtState.Text;
            currentData.Zip = txtZip.Text;
            currentData.Phone = txtPhone.Text;

            ConfigData.write(currentData);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void grdEditConfig_Loaded(object sender, RoutedEventArgs e)
        {
            Config currentData = ConfigData.read();
            txtName.Text = currentData.Name;
            txtAddress.Text = currentData.Address;
            txtCity.Text = currentData.City;
            txtState.Text = currentData.State;
            txtZip.Text = currentData.Zip;
            txtPhone.Text = currentData.Phone;
        }

        
    }
}
