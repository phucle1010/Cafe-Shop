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
using QL_QuanCafe.Model;
using System.Net.Mail;
using System.Net;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for ForgotPasswork.xaml
    /// </summary>
    public partial class ForgotPasswork : Window
    {
        public ForgotPasswork()
        {
            InitializeComponent();
        }

        private void btn_TimKiem_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_Email.Text.ToString();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email tài khoản của bạn", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else 
            {
                EnterOTP enterotp = new EnterOTP();
                if (SearchAccountinDB(email))
                {
                    this.Hide();
                    EmailResetPass.Instance.SetEmail(email);
                    OTPCode.Instance.SetOTP(InitOTPCode(100000, 999999).ToString());
                    string subject = "Bảo mật";
                    string content = "Xin chào bạn, bạn vừa thực hiện khôi phục tài khoản. Mã xác thực của bạn là: " + OTPCode.Instance.GetOTP()
                                        + ". Vui lòng xác nhận mã để thực hiện cài đặt lại mật khẩu.";
                    SendOTP("DreamCoffeeHCM@gmail.com", "123!@#123!@#", email, subject, content);
                    enterotp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Email ban nhap khong chinh xac!!!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private bool SearchAccountinDB(string _email)
        {
            int successDataRows = 0;
            try
            {
                successDataRows = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE email = '{_email}'").Count();
                successDataRows += DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM  WHERE NhanVien email = '{_email}'").Count();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return successDataRows > 0;
        }

        private void btn_Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private int InitOTPCode(int begin, int end)
        {
            Random rd = new Random();
            return rd.Next(begin, end);
        }
        private void SendOTP(string mailfrom, string pass, string mailto, string subject, string content)
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
