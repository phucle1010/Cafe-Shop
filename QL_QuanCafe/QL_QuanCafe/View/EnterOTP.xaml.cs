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

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for EnterOTP.xaml
    /// </summary>
    public partial class EnterOTP : Window
    {
        public EnterOTP()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_TimKiem_Click(object sender, RoutedEventArgs e)
        {
            string otp = txt_OTP.Text.ToString();
            if (otp == OTPCode.Instance.GetOTP())
            {
                MessageBox.Show("Xác thực mã thành công!!!", "Thông báo");
                this.Close();
                CreateNewPasswork newpass = new CreateNewPasswork();
                newpass.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mã OTP không chính xác. Vui lòng kiểm tra lại!!", "Thông báo");
            }
        }
    }
}
