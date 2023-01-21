using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for SecurityView.xaml
    /// </summary>
    public partial class SecurityView : Window
    {
        string username = Properties.Settings.Default ["user"].ToString();
        string role = Properties.Settings.Default ["role"].ToString();
        Frame MainContent;
        public SecurityView()
        {
            InitializeComponent();
        }

        public SecurityView(Frame MainContent)
        {
            InitializeComponent();
            this.MainContent = MainContent;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage( IntPtr hWnd, int wMsg, int wParam, int lParam );

        private void btnMinimize_Click( object sender, RoutedEventArgs e )
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click( object sender, RoutedEventArgs e )
        {
            this.Close();
        }

        private void pnlControlBar_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter( object sender, System.Windows.Input.MouseEventArgs e )
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
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
                        if (role == "0")
                        {
                            MainContent.Navigate(new HomeCustomerView());
                        }
                        else
                        {
                            MainContent.Navigate(new HomeAdminView());
                        }
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
