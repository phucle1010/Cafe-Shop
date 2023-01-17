using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class FavoriteFood
    {
        public int foodId { get; set; }
        public int sumOfOrderedQuantities { get; set; }
    }

    public class CustomerViewModel : ViewModelBase
    {
        List<FavoriteFood> favoriteFoodList = new List<FavoriteFood>();
        public bool isLoginWithCustomerRole( string user, string pass )
        {
            LoginViewModel login = new LoginViewModel();
            int successDataRows = 0;
            try
            {
                successDataRows = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}' AND MatKhau = '{login.ComputeSha256Hash(pass)}'").Count();
            }
            catch ( Exception e )
            {
                throw (e);
            }
            return successDataRows > 0;
        }
        public string getCustomerName (string user)
        {
            string name = "";
            try
            {
                name = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).TenKH.ToString();
            }
            catch (Exception e )
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return name;
        }

        public int getCustomerId( string user )
        {
            return DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).MaKH;
        }

        public int getTheNumberOfCustomer()
        {
            return DataProvider.Ins.DB.KHACHHANGs.Count();
        }

        public List<KHACHHANG> getCustomerList()
        {
            var customerList = DataProvider.Ins.DB.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG").ToList<KHACHHANG>();
            return customerList;
        }

        public void LoadFavoriteFoodOfCustomer(int customerId)
        {
            var DataBase = DataProvider.Ins.DB;
            var foods = DataBase.HOADONs
                                         .Where(h => h.MaKH == customerId)
                                         .Join(DataBase.CT_HOADON,
                                               h => h.MaHD,
                                               ct => ct.MaHD,
                                               ( h, ct ) => new { ct.MaSP, ct.SoLuong }).ToList();
            
            var sumQuantityByFood = foods.GroupBy(x => x.MaSP)
                                         .Select(x => new FavoriteFood
                                         {
                                             foodId = (int) x.Key,
                                             sumOfOrderedQuantities = (int) x.Sum(s => s.SoLuong)
                                         })
                                         .OrderByDescending(x => x.sumOfOrderedQuantities)
                                         .Take(3)
                                         .ToList();
            favoriteFoodList = sumQuantityByFood;
        }

        public List<int> GetAllQuantityByFood(int customerId)
        {
            LoadFavoriteFoodOfCustomer(customerId);
            return favoriteFoodList.Select(x => x.sumOfOrderedQuantities).ToList();
        }

        public List<string> GetAllNameByFood(int customerId)
        {
            LoadFavoriteFoodOfCustomer(customerId);
            var foodIdList = favoriteFoodList.Select(x => x.foodId).ToList();
            List<string> names = new List<string>();
            foreach(var foodId in foodIdList )
            {
                names.Add(DataProvider.Ins.DB.SANPHAMs.Where(food => food.MaSP == foodId).Select(food => food.TenSP).First());
            }
            return names;
        }

        public int GetOrderedQuantityOfCustomer(int customerId)
        {
            return (int) DataProvider.Ins.DB.HOADONs
                                              .Where(hd => hd.MaKH == customerId)
                                              .Join(DataProvider.Ins.DB.CT_HOADON,
                                                    hd => hd.MaHD,
                                                    ct => ct.MaHD,
                                                    ( hd, ct ) => new { ct.SoLuong })
                                              .ToList()
                                              .Sum(x => x.SoLuong);
        }
    }
}
