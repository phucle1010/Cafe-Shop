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
    /// Interaction logic for AdminProfileView.xaml
    /// </summary>
    public partial class AdminProfileView : Page
    {
        AdminProfileViewModel adminProfile = new AdminProfileViewModel();
        string username = Properties.Settings.Default ["user"].ToString();

        public AdminProfileView()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            txt_Name.Text = adminProfile.GetName(username);
            txt_Email.Text = adminProfile.GetEmail(username);
            txt_Phone.Text = adminProfile.GetPhone(username);
            date_picker.SelectedDate = DateTime.Parse(adminProfile.GetBeignDate(username));
            txt_Position.Text = adminProfile.GetPosition(username);
        }

        private void btn_SaveChange_Click( object sender, RoutedEventArgs e )
        {
            string name = txt_Name.Text;
            string email = txt_Email.Text;
            DateTime date = date_picker.SelectedDate.Value;
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
                adminProfile.UpdateProfile(name, email, date, phone);

            }
        }

    }
}
