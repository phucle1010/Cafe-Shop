using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.ViewModel
{
    public class HomeAdminViewModel : ViewModelBase
    {
        public int getTheNumberOfEmployee()
        {
            int number = 0;
            try
            {
                number = DataProvider.Ins.DB.NHANVIENs.Count();
            }
            catch
            {

            }
            return number;
        }

        public int getTheNumberOfCustomer()
        {
            int number = 0;
            try
            {
                number = DataProvider.Ins.DB.KHACHHANGs.Count();
            }
            catch
            {

            }
            return number;
        }

        public int getTheNumberOfStandardCustomer()
        {
            int number = 0;
            try
            {
                number = DataProvider.Ins.DB.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG WHERE MaLoaiKH='0'").Count();
            }
            catch
            {

            }
            return number;
        }

        public int getTheNumberOfVIPCustomer()
        {
            int number = 0;
            try
            {
                number = DataProvider.Ins.DB.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG WHERE MaLoaiKH='2'").Count();
            }
            catch
            {

            }
            return number;
        }

        public int getTheNumberOfLoyalCustomer()
        {
            int number = 0;
            try
            {
                number = DataProvider.Ins.DB.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG WHERE MaLoaiKH='1'").Count();
            }
            catch
            {

            }
            return number;
        }
    }
}
