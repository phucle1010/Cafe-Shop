using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        
        public bool isLoginWithAdminRole( string user, string pass )
        {
            LoginViewModel login = new LoginViewModel();
            int successDataRows = 0;
            try
            {
                successDataRows = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = {user} AND MatKhau = '{login.ComputeSha256Hash(pass)}'").Count();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
            return successDataRows > 0;
        }
        public string getAdminName( string user )
        {
            string name = "";
            try
            {
                name = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = {user}").ElementAt(0).TenNV.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return name;
        }

        public int getTheNumberOfEmployee()
        {
            return DataProvider.Ins.DB.NHANVIENs.Count();
        }
    }
}
