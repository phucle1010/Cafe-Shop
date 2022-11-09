using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    class LoginViewModel
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
                DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.SqlQuery($"INSERT INTO TAIKHOANDANGSUDUNG VALUES('{user}', '{currentIPAddress}', {role})");
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
                DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.SqlQuery("DELETE FROM TAIKHOANDANGSUDUNG");
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
        public int userRole()
        {
            int role = 0;
            try
            {
                role = Int32.Parse( DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.SqlQuery("SELECT PhanQuyen FROM TAIKHOANDANGSUDUNG").ToList()[0].PhanQuyen.ToString() );
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
                userName = DataProvider.Ins.DB.TAIKHOANDANGSUDUNGs.SqlQuery("SELECT TaiKhoan FROM TAIKHOANDANGSUDUNG").ToList() [0].TaiKhoan.ToString();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
            return userName;
        }
    }
}
