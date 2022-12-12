using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class AddNewFoodViewModel : ViewModelBase
    {
        public List<LOAISANPHAM> GetAllFoodType()
        {
            return DataProvider.Ins.DB.LOAISANPHAMs.SqlQuery("SELECT * FROM LOAISANPHAM").ToList<LOAISANPHAM>();
        }

        public string GetFoodTypeId(string typeName)
        {
            return DataProvider.Ins.DB.LOAISANPHAMs.SqlQuery($"SELECT * FROM LOAISANPHAM WHERE TenLoaiSP=N'{typeName}'").ElementAt(0).MaLoaiSP.ToString();
        }

        public void InsertFoodData(string name, string typeId, string price, string pathImage)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO SANPHAM (TenSP, MaLoaiSP, GiaSP, TrangThai, HinhAnh) VALUES (N'{name}', '{typeId}', {price}, 1, N'{pathImage}')");
                MessageBox.Show("Thêm món ăn mới thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e) 
            {
                MessageBox.Show($"Lỗi: {e}");
            }
        }

        public string GetTheLatestFoodId()
        {
            List<SANPHAM> f = DataProvider.Ins.DB.SANPHAMs.SqlQuery("SELECT * FROM SANPHAM").ToList<SANPHAM>();
            return f [f.Count - 1].MaSP.ToString();
        }
    }
}
