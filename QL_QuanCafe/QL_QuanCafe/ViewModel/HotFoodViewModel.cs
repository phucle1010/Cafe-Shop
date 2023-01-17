using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.ViewModel
{
    internal class HotFoodViewModel
    {
        List<FavoriteFood> favoriteFoodList = new List<FavoriteFood>();
        public void LoadFavoriteFood( )
        {
            var DataBase = DataProvider.Ins.DB;
            var foods = DataBase.HOADONs
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
                                         .Take(4)
                                         .ToList();
            favoriteFoodList = sumQuantityByFood;
        }

        public List<int> GetAllQuantityByFood()
        {
            LoadFavoriteFood();
            return favoriteFoodList.Select(x => x.sumOfOrderedQuantities).ToList();
        }

        public List<int> GetAllPriceByFood()
        {
            LoadFavoriteFood();
            var foodIdList = favoriteFoodList.Select(x => x.foodId).ToList();
            List<int> prices = new List<int>();
            foreach ( var foodId in foodIdList )
            {
                prices.Add((int) DataProvider.Ins.DB.SANPHAMs.Where(food => food.MaSP == foodId).Select(food => food.GiaSP).First());
            }
            return prices;
        }

        public List<string> GetAllNameByFood()
        {
            LoadFavoriteFood();
            var foodIdList = favoriteFoodList.Select(x => x.foodId).ToList();
            List<string> names = new List<string>();
            foreach ( var foodId in foodIdList )
            {
                names.Add(DataProvider.Ins.DB.SANPHAMs.Where(food => food.MaSP == foodId).Select(food => food.TenSP).First());
            }
            return names;
        }

        public List<string> GetAllImageByFood()
        {
            LoadFavoriteFood();
            var foodIdList = favoriteFoodList.Select(x => x.foodId).ToList();
            List<string> images = new List<string>();
            foreach ( var foodId in foodIdList )
            {
                images.Add(DataProvider.Ins.DB.SANPHAMs.Where(food => food.MaSP == foodId).Select(food => food.HinhAnh).First());
            }
            return images;
        }
    }
}
