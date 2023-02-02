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
        public int UpdateProfile(string name, string email, string phone, string address, string path)
        {
            
            int status = 0;
            string username = Properties.Settings.Default ["user"].ToString();
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHANVIEN SET TenNV = N'{name}', SDT = '{phone}', DiaChi = N'{address}', Email = '{email}', AnhDaiDien=N'{path}' WHERE MaNV = {username}");
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
            CafeShopEntities entity = new CafeShopEntities();
            return entity.NHANVIENs.Where(employee => employee.MaNV.ToString() == user).First();
        }
    }
}
