using QL_QuanCafe.LocalStore;
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

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for OTPView.xaml
    /// </summary>
    public partial class OTPView : Window
    {
        public OTPView()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click( object sender, RoutedEventArgs e )
        {
            WindowState = WindowState.Maximized;
        }

        private void btnClose_Click( object sender, RoutedEventArgs e )
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown( object sender, MouseButtonEventArgs e )
        {
            if ( e.LeftButton == MouseButtonState.Pressed )
                DragMove();
        }

        private void btnCancel_Click( object sender, RoutedEventArgs e )
        {
            Application.Current.Shutdown();
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            string otp = txt_OTP.Text.ToString();
            if ( otp == OTPCode.Instance.GetOTP() )
            {
                MessageBox.Show("Xác thực mã thành công!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                CreateNewPasswordView newpass = new CreateNewPasswordView();
                this.Visibility = Visibility.Hidden;
                newpass.Show();
            }
            else
            {
                MessageBox.Show("Mã OTP không chính xác. Vui lòng kiểm tra lại!!", "Thông báo");
            }
        }
    }
}
