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
            int nDataRows = 0;
            try
            {
                nDataRows = DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.SqlQuery("SELECT * FROM TAIKHOANDANGSUDUNG").Count();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
            return nDataRows > 0;
        }
        public bool isAdmin()
        {
            bool role = false;
            try
            {
                role = Boolean.Parse( DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.SqlQuery("SELECT * FROM TAIKHOANDANGSUDUNG").ElementAt(0).PhanQuyen.ToString() );
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
            return role;
        }
        public string getUserNameOfUser()
        {
            string userName = "";
            try
            {
                userName = DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.SqlQuery("SELECT * FROM TAIKHOANDANGSUDUNG").ElementAt(0).TaiKhoan.ToString();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
            return userName;
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
