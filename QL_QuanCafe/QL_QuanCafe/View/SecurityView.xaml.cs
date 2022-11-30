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
    /// Interaction logic for SecurityView.xaml
    /// </summary>
    public partial class SecurityView : Page
    {
        string username = Properties.Settings.Default ["user"].ToString();
        string role = Properties.Settings.Default ["role"].ToString();
        public SecurityView()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            if (role == "1")
            {
                AdminViewModel admin = new AdminViewModel();
                tbUserName.Text = admin.getAdminName(this.username);

            } else if (role == "0")
            {
                CustomerViewModel admin = new CustomerViewModel();
                tbUserName.Text = admin.getCustomerName(this.username);
            }
        }

        private void btnReset_Click( object sender, RoutedEventArgs e )
        {
            string pass = txtpass.Password.ToString();
            string newpass = txtnewpass.Password.ToString();
            string renewpass = txtrenewpass.Password.ToString();
            SecurityViewModel resetPasssword = new SecurityViewModel();
            string passwordhash = resetPasssword.ComputeSha256Hash(pass).ToUpper();
            if ( IsNullData(pass, newpass, renewpass) )
            {
                MessageBox.Show("Nhập không đủ thông tin. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                MessageBox.Show($"Pass before hash: {pass}");
                if ( !resetPasssword.IsCorrectCurrentPassword(role, username, passwordhash) )
                {
                    MessageBox.Show("Mật khẩu hiện tại không chính xác. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if ( !IsCorrectSubmitPass(newpass, renewpass) )
                    {
                        MessageBox.Show("Mật khẩu xác nhận không chính xác. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        resetPasssword.UpdatePassword(role, username, newpass);
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtpass.Clear();
                        txtnewpass.Clear();
                        txtrenewpass.Clear();
                    }
                }
            }
        }

        public bool IsNullData( string pass, string newpass, string renewpass )
        {
            if ( string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(newpass) || string.IsNullOrEmpty(renewpass) )
                return true;
            return false;
        }

        public bool IsCorrectSubmitPass( string pass, string repass )
        {
            return repass == pass;
        }
    }
}
