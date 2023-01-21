using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class CustomerProfileViewModel : ViewModelBase
    {
        public string GetName(string user)
        {
            string str = "";
            try
            {
                str = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).TenKH.ToString();
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
                str = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).Email.ToString();
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
                str = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).SDT.ToString();
            }
            catch
            {

            }
            return str;
        }

        public string GetAddress( string user )
        {
            string str = "";
            try
            {
                str = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).DiaChi.ToString();
            }
            catch
            {

            }
            return str;
        }

        public string GetAccumlatorPoint( string user )
        {
            var customerId = DataProvider.Ins.DB.KHACHHANGs.Where(customer => customer.TenDN == user).Select(customer => customer.MaKH).FirstOrDefault();
            return DataProvider.Ins.DB.THETICHDIEMs.Where(customer => customer.MaKH == customerId).Select(customer => customer.DiemTichLuy).First().ToString();
        }

        public string GetCustomerType( string user )
        {
            string str = "";
            string typeId = "";
            try
            {
                typeId = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).MaLoaiKH.ToString();
                str = DataProvider.Ins.DB.LOAIKHACHHANGs.SqlQuery($"SELECT * FROM LOAIKHACHHANG WHERE MaLoaiKH = '{typeId}'").ElementAt(0).TenLoaiKH.ToString();
            }
            catch
            {

            }
            return str;
        }

        public void UpdateProfile( string name, string phone, string address, string email )
        {
            string username = Properties.Settings.Default ["user"].ToString();
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE KHACHHANG SET TenKH = N'{name}', SDT = '{phone}', DiaChi = '{address}', Email = '{email}' WHERE TenDN = '{username}'");
                MessageBox.Show("Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi");
            }
        }
    }
}
