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
    }
}
