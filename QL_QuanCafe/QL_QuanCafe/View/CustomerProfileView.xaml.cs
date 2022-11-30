using QL_QuanCafe.ViewModel;
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

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for CustomerProfileView.xaml
    /// </summary>
    public partial class CustomerProfileView : Page
    {
        CustomerProfileViewModel customerProfile = new CustomerProfileViewModel();
        string username = Properties.Settings.Default ["user"].ToString();
        public CustomerProfileView()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            txt_Name.Text = customerProfile.GetName(username);
            txt_Email.Text = customerProfile.GetEmail(username);
            txt_Phone.Text = customerProfile.GetPhone(username);
            txt_Address.Text = customerProfile.GetAddress(username);
            txt_AccumPoint.Text = customerProfile.GetAccumlatorPoint(username);
            txt_CustomerType.Text = customerProfile.GetCustomerType(username);
        }

        private void btn_SaveChange_Click( object sender, RoutedEventArgs e )
        {
            string name = txt_Name.Text;
            string email = txt_Email.Text;
            string address = txt_Address.Text;
            string phone = txt_Phone.Text;
            if ( string.IsNullOrEmpty(name) )
            {
                MessageBox.Show("Bạn chưa nhập họ tên!", "Thông báo");
            }
            else if ( string.IsNullOrEmpty(email) )
            {
                MessageBox.Show("Bạn chưa nhập email!", "Thông báo");
            }
            else if ( string.IsNullOrEmpty(phone) )
            {
                MessageBox.Show("Bạn chưa nhập số diện thoại!", "Thông báo");
            }
            else
            {
                customerProfile.UpdateProfile(name, phone, address, email);
            }
        }
    }
}
