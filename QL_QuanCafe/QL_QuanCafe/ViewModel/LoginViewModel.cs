using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public string getIPAddress()
        {
            string hostName = Dns.GetHostName();
            string IP = Dns.GetHostEntry(hostName).AddressList [0].ToString();
            return IP;
        }
        public void insertUserIsUsing(string user,int role)
        {
            string currentIPAddress = getIPAddress();
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO TAIKHOANDANGSUDUNG VALUES ('{user}', {role}, '{currentIPAddress}')");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void removeUserIsUsing()
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand("DELETE FROM TAIKHOANDANGSUDUNG");
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
        }
        public bool haveUserIsUsing()
        {
            return DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.Count() > 0;
        }
        public bool isAdmin()
        {
            return (bool) DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.ToList() [0].PhanQuyen;
        }
        public string getUserNameOfUser()
        {
            return DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.ToList() [0].TaiKhoan;
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
    }
}
