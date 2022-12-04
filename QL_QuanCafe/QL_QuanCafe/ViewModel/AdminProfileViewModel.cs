using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class AdminProfileViewModel : ViewModelBase
    {
        public int UpdateProfile(string name, string email, string phone, string address)
        {
            int status = 0;
            string username = Properties.Settings.Default ["user"].ToString();
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHANVIEN SET TenNV = N'{name}', SDT = '{phone}', DiaChi = '{address}', Email = '{email}' WHERE MaNV = {username}");
                status = 1;
                MessageBox.Show("Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi");
            }
            return status;
        }

        public NHANVIEN EmployeeInfo( string user )
        {
            NHANVIEN e = new NHANVIEN();
            try
            {
                var result = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = {user}").ToList<NHANVIEN>();
                e = result [0];
                return e;
            }
            catch ( Exception err )
            {
                MessageBox.Show(err.ToString(), "Lỗi");
            }
            return null;
        }
    }
}
