using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    class AdminViewModel
    {
        public bool isLoginWithAdminRole( string user, string pass )
        {
            int successDataRows = 0;
            try
            {
                successDataRows = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV ='{user}' AND MatKhau ='{pass}'").Count();
            }
            catch ( Exception e )
            {
                throw (e);
            }
            return successDataRows > 0;
        }
        public string getAdminName( string user )
        {
            string name = "";
            try
            {
                name = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = '{user}'").ToList() [0].TenNV.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return name;
        }
    }
}
