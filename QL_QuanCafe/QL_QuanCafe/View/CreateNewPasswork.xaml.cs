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
    /// Interaction logic for CreateNewPasswork.xaml
    /// </summary>
    public partial class CreateNewPasswork : Window
    {
        public CreateNewPasswork()
        {
            InitializeComponent();
        }

        private void btn_Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_CapNhat_Click(object sender, RoutedEventArgs e)
        {
            string pass = txt_Pass.Text.ToString();
            if (pass.Length>= 6)
            {
                try
                {
                    DataProvider.Ins.DB.Database.ExecuteSqlCommand($"update khachhang set matkhau = '{pass}' where email = '{EmailResetPass.Instance.GetEmail()}'");
                }
                catch
                {
                    
                }
                MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu phải dài hơn hoặc bằng 6 ký tự!", "Thông báo");
            }
        }
    }
}
