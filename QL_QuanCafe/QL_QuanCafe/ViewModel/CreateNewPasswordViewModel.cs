using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class CreateNewPasswordViewModel : ViewModelBase
    {
        public string ComputeSha256Hash( string rawData )
        {
            using ( SHA256 sha256Hash = SHA256.Create() )
            {
                byte [] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for ( int i = 0; i < bytes.Length; i++ )
                {
                    builder.Append(bytes [i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public void UpdatePassword(string pass, string email)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE KHACHHANG SET MatKhau = '{ComputeSha256Hash(pass)}' WHERE Email = '{email}'");
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHANVIEN SET MatKhau = '{ComputeSha256Hash(pass)}' WHERE Email = '{email}'");
                MessageBox.Show("Khôi phục tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi khôi phục tài khoản!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
