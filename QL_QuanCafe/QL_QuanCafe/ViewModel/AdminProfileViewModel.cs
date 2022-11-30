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
        public string GetName( string user )
        {
            string str = "";
            try
            {
                str = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = '{user}'").ElementAt(0).TenNV.ToString();
            }
            catch
            {

            }
            return str;
        }

        public string GetEmail( string user )
        {
            string str = "";
            try
            {
                str = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = '{user}'").ElementAt(0).Email.ToString();
            }
            catch
            {

            }
            return str;
        }

        public string GetPhone( string user )
        {
            string str = "";
            try
            {
                str = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = '{user}'").ElementAt(0).SDT.ToString();
            }
            catch
            {

            }
            return str;
        }

        public string GetBeignDate( string user )
        {
            string str = "";
            try
            {
                str = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = '{user}'").ElementAt(0).NgayVaoLam.ToString();
            }
            catch
            {

            }
            return str;
        }

        public string GetPosition( string user )
        {
            string str = "";
            try
            {
                str = DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = '{user}'").ElementAt(0).ChucVu.ToString();
            }
            catch
            {

            }
            return str;
        }

        
        public void UpdateProfile(string name, string email, DateTime date, string phone)
        {
            string username = Properties.Settings.Default ["user"].ToString();
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHANVIEN SET TenNV = N'{name}', SDT = '{phone}', NgayVaoLam = '{date}', Email = '{email}' WHERE MaNV = '{username}'");
                MessageBox.Show("Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi");
            }
        }
    }
}
