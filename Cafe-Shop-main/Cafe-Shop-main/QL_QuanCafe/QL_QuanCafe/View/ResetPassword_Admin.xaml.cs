using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
using QL_QuanCafe.ViewModel;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for ResetPassword_Admin.xaml
    /// </summary>
    public partial class ResetPassword_Admin : UserControl
    {
        string username= Properties.Settings.Default["user"].ToString();
        string role = Properties.Settings.Default["role"].ToString();
        public ResetPassword_Admin()
        {
            InitializeComponent();
         
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            string pass = txtpass.Password.ToString();
            string newpass = txtnewpass.Password.ToString();
            string renewpass= txtrenewpass.Password.ToString();
            ResetPassswordViewModel resetPasssword = new ResetPassswordViewModel();
            string passwordhash= resetPasssword.ComputeSha256Hash(pass);
            if (IsNullData(pass, newpass,renewpass))
            {
                MessageBox.Show("Nhập không đủ thông tin. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if(!CorrectPassword(passwordhash))
            {
                MessageBox.Show("Mật khẩu không chính xác. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!SubmitPassCorrect(newpass, renewpass)) 
            {
                MessageBox.Show("Xác nhận mật khẩu không chính xác. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
               
                resetPasssword.UpdatePassword(role,username,newpass);
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                txtpass.Clear();
                txtnewpass.Clear();
                txtrenewpass.Clear();
            }

        }
         
        
       public  bool IsNullData(string pass, string newpass, string renewpass)
        {
            if (string.IsNullOrEmpty(pass)|| string.IsNullOrEmpty(newpass)|| string.IsNullOrEmpty(renewpass))
                return true;
            return false;
        }
        public bool CorrectPassword( string pass)
        {
            bool corect = false;
            string pass1 = "";
            try
            {
                pass1 = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV='{username}'").ElementAt(0).MatKhau.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            if (pass == pass1) corect = true;
            return corect;
        }
        public bool SubmitPassCorrect(string pass, string repass)
        {
            return repass == pass;
        }
    }
}
