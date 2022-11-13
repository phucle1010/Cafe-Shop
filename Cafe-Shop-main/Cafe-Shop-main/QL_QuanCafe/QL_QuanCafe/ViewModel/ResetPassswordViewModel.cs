using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Media;

namespace QL_QuanCafe.ViewModel
{
    public class ResetPassswordViewModel: ViewModelBase
    {
        public void UpdatePassword(string role, string username, string newpass)
        {

            string newpasshash = ComputeSha256Hash(newpass);
            if(role == "1")
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHANVIEN SET MatKhau = '{newpasshash}' WHERE MaNV ='{username}'");
            else
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE KHACHHANG SET MatKhau = '{newpasshash}' WHERE TenDN ='{username}'");

        }

        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
