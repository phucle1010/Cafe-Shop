using QL_QuanCafe.LocalStore;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for ForgotPasswordView.xaml
    /// </summary>
    public partial class ForgotPasswordView : Window
    {
        public ForgotPasswordView()
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

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            string email = txt_Email.Text.ToString();
            if ( string.IsNullOrEmpty(email) )
            {
                MessageBox.Show("Vui lòng nhập Email tài khoản của bạn", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ForgotPasswordViewModel forgotPass = new ForgotPasswordViewModel();
                if ( forgotPass.IsExistedAccount(email) )
                {
                    EmailResetPassword.Instance.SetEmail(email);
                    OTPCode.Instance.SetOTP(InitOTPCode(100000, 999999).ToString());
                    string subject = "Khôi phục tài khoản";
                    string content = "Xin chào bạn, bạn vừa thực hiện khôi phục tài khoản. Mã xác thực của bạn là: " + OTPCode.Instance.GetOTP()
                                        + ". Vui lòng xác nhận mã để thực hiện cài đặt lại mật khẩu.";
                    SendOTP("DreamCoffeeHCM@gmail.com", "123!@#123!@#", email, subject, content);
                    MessageBox.Show("Xác thực Email thành công. Vui lòng kiểm tra Email của bạn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    OTPView enterotpLayout = new OTPView();
                    this.Visibility = Visibility.Hidden;
                    enterotpLayout.Show();
                }
                else
                {
                    MessageBox.Show("Email nhập không chính xác!!!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnCancel_Click( object sender, RoutedEventArgs e )
        {
            Application.Current.Shutdown();
        }

        private int InitOTPCode( int begin, int end )
        {
            Random rd = new Random();
            return rd.Next(begin, end);
        }
        private void SendOTP( string mailfrom, string pass, string mailto, string subject, string content )
        {

            MailMessage mail = new MailMessage(mailfrom, mailto, subject, content);
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("DreamCoffeeHCM@gmail.com", "deuallbrhtbiydsm");
            client.EnableSsl = true;
            client.Send(mail);
        }

       
    }
}
