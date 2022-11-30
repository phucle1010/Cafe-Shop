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
    public class SecurityViewModel : ViewModelBase
    {
        public void UpdatePassword( string role, string username, string newpass )
        {

            string newpasshash = ComputeSha256Hash(newpass);
            if ( role == "1" )
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHANVIEN SET MatKhau = '{newpasshash}' WHERE MaNV ='{username}'");
            else
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE KHACHHANG SET MatKhau = '{newpasshash}' WHERE TenDN ='{username}'");
        }

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

        public bool IsCorrectCurrentPassword(string role, string username, string inputPass)
        {
            string currentPass = "";
            try
            {
                if ( role == "1" )
                {
                    currentPass = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = '{username}'").ElementAt(0).MatKhau.ToString();
                }
                else if ( role == "0" )
                {
                    currentPass = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{username}'").ElementAt(0).MatKhau.ToString();
                }
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
            MessageBox.Show($"Current Pass: {currentPass} and Input Pass: {inputPass}");
            if ( inputPass != currentPass )
            {
                return false;
            }
            return true;
        }
    }
}
