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
        public KHACHHANG GetCustomerInfo(string userName)
        {
            CafeShopEntities entity = new CafeShopEntities();
            return entity.KHACHHANGs.Where(customer => customer.TenDN == userName).FirstOrDefault();
        }

        public string GetAccumlatorPoint( string user )
        {
            CafeShopEntities entity = new CafeShopEntities();
            var customerId = DataProvider.Ins.DB.KHACHHANGs.Where(customer => customer.TenDN == user).Select(customer => customer.MaKH).FirstOrDefault();
            return entity.THETICHDIEMs.Where(customer => customer.MaKH == customerId).Select(customer => customer.DiemTichLuy).First().ToString();
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

        public int UpdateProfile(string userName, string name, string phone, string address, string email, string avt )
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE KHACHHANG SET TenKH = N'{name}', SDT = '{phone}', DiaChi = N'{address}', Email = '{email}', AnhDaiDien='{avt}' WHERE TenDN = '{userName}'");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi");
                return 0;
            }
            return 1;
        }
    }
}
