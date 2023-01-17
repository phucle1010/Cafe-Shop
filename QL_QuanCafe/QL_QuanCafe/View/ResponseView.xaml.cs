using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for ResponseView.xaml
    /// </summary>
    public partial class ResponseView : Window
    {
        public ResponseView()
        {
            InitializeComponent();
            LoadData();
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

        void LoadData()
        {
            CustomerViewModel customer = new CustomerViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tb_fullName.Text = customer.getCustomerName(userName);
            tb_email.Text = customer.getCustomerEmail(userName);
            tb_phone.Text = customer.getCustomerSDT(userName);
        }

        private void btn_Cancel_Click( object sender, RoutedEventArgs e )
        {
            tb_subject.Text = tb_feedBackMessage.Text = "";
        }

        private void btn_SendFeedBack_Click( object sender, RoutedEventArgs e )
        {
            string fullName = tb_fullName.Text.ToString();
            string email = tb_email.Text.ToString();
            string phone = tb_phone.Text.ToString();
            string subject = tb_subject.Text.ToString();
            string message = tb_feedBackMessage.Text.ToString();
            string content = "Người gửi: " + fullName + "<br />Email: " + email + "<br />Phone: " + phone + "<br />Nội dung: " + message;
            if ( string.IsNullOrEmpty(fullName) )
            {
                MessageBox.Show("Bạn chưa nhập họ tên!", "Thông báo");
            }
            else if ( string.IsNullOrEmpty(email) )
            {
                MessageBox.Show("Bạn chưa nhập email!", "Thông báo");
            }
            else if ( string.IsNullOrEmpty(phone) )
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!", "Thông báo");
            }
            else if ( string.IsNullOrEmpty(subject) )
            {
                MessageBox.Show("Bạn chưa nhập chủ đề phản hồi!", "Thông báo");
            }
            else if ( string.IsNullOrEmpty(message) )
            {
                MessageBox.Show("Bạn chưa nhập nội dung phản hồi!", "Thông báo");
            }
            else
            {
                sendFeedBack("customerdreamcoffee@gmail.com", "123!@#123!@#", "DreamCoffeeHCM@gmail.com", subject, content);
            }
        }

        private void sendFeedBack( string mailfrom, string pass, string mailto, string subject, string content )
        {

            MailMessage mail = new MailMessage(mailfrom, mailto, subject, content);
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("customerdreamcoffee@gmail.com", "jncpdpjethiqmzun");
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}
