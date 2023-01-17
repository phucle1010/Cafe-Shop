using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        public List<string> GetAllMaterialNeetToImport()
        {
            return DataProvider.Ins.DB.HANGHOAs
                                               .Where(x => x.SoLuongConSan <= 2)
                                               .Select(x => x.TenHH)
                                               .Distinct()
                                               .ToList();
        }

        public double GetQuantityOfMaterial(string materialName)
        {
            return (double) DataProvider.Ins.DB.HANGHOAs
                                                .Where(x => x.TenHH == materialName)
                                                .Select(x => x.SoLuongConSan)
                                                .First();
        }

        public List<int> GetTopTrendProductQuantity()
        {
            var quantity = DataProvider.Ins.DB.CT_HOADON
                                                .GroupBy(x => x.MaSP)
                                                .Select(x => new
                                                {
                                                    SUM = x.Sum(s => s.SoLuong)
                                                })
                                                .OrderByDescending(x => x.SUM)
                                                .Take(3)
                                                .ToList();
            List<int> sumOrderOfEachFood = new List<int>();
            foreach (var item in quantity)
            {
                sumOrderOfEachFood.Add((int)item.SUM);
            }
            return sumOrderOfEachFood;
        }

        public List<string> GetTopTrendProductName()
        {
            var quantity = DataProvider.Ins.DB.CT_HOADON
                                                .GroupBy(x => x.MaSP)
                                                .Select(x => new
                                                {
                                                    MaSP = x.Key,
                                                    SUM = x.Sum(s => s.SoLuong)
                                                })
                                                .OrderByDescending(x => x.SUM)
                                                .Take(3)
                                                .ToList();
            List<string> OrderOfEachFoodName = new List<string>();
            foreach ( var item in quantity )
            {
                OrderOfEachFoodName.Add(DataProvider.Ins.DB.SANPHAMs.Where(x => x.MaSP == item.MaSP).First().TenSP);
            }
            return OrderOfEachFoodName;
        }

    }
}
