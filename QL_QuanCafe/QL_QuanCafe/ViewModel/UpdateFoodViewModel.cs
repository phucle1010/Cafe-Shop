using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class UpdateFoodViewModel : ViewModelBase
    {
        public SANPHAM GetFoodData(int foodId)
        {
            return DataProvider.Ins.DB.SANPHAMs.SqlQuery($"SELECT * FROM SANPHAM WHERE MaSP={foodId}").ElementAt(0);
        }

        public int UpdateFoodData(int foodId, int price, int status)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE SANPHAM SET GiaSP={price}, TrangThai={status} WHERE MaSP={foodId}");
                MessageBox.Show("Cập nhật món ăn thành công!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi {e}");
            }
            return 0;
        }

        public List<SANPHAM> GetAllFood()
        {
            return DataProvider.Ins.DB.SANPHAMs.SqlQuery("SELECT * FROM SANPHAM").ToList<SANPHAM>();
        }

        public List<CT_SANPHAM> GetAllFoodDetail(int foodId)
        {
            return DataProvider.Ins.DB.CT_SANPHAM.SqlQuery($"SELECT * FROM CT_SANPHAM WHERE MaSP={foodId}").ToList<CT_SANPHAM>();
        }

        public string GetMaterialNameByMaterialId(int materialId)
        {
            return DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaHH={materialId}").ElementAt(0).TenHH;
        }

        public CT_SANPHAM GetCurrentMaterialDataForFood( string materialName, int foodId)
        {
            return DataProvider.Ins.DB.CT_SANPHAM.SqlQuery($"SELECT * FROM CT_SANPHAM CT, HANGHOA HH WHERE CT.MaHH = HH.MaHH AND HH.TenHH=N'{materialName}' AND CT.MaSP={foodId}").ElementAt(0);
        }

        public int UpdateNewNeededQuantityForFod(int materialId, int foodId, string quantity)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE CT_SANPHAM SET SoLuong={quantity} WHERE MaSP={foodId} AND MaHH={materialId}");
            }
            catch
            {
                return 0;
            }
            return 1;
        }
    }
}
