using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class MaterialTypeItemViewModel : ViewModelBase
    {
        public string getMaterialTypeName(string id)
        {
            string name = "";
            try
            {
                name = DataProvider.Ins.DB.LOAIHANGHOAs.SqlQuery($"SELECT * FROM LOAIHANGHOA WHERE MaLoaiHH = {id}").ElementAt(0).TenLoaiHH.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return name;
        }
        public int numberOfMaterialItems(string id)
        {
            int count = 0;
            try
            {
                count = DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaLoaiHH = '{id}'").Count();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return count;
        }
        public int getMaterialId(string id, string name)
        {
            return DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaLoaiHH = '{id}' AND TenHH = N'{name}'").ElementAt(0).MaHH;
        }
        public string getMaterialUnit( string id, string name )
        {
            string unit = "";
            try
            {
                unit = DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaLoaiHH = '{id}' AND TenHH = N'{name}'").ElementAt(0).DonVi.ToString();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return unit;
        }
        public string getAvailableMaterialQuantity( string name )
        {
            string quantity = "";
            try
            {
                quantity = DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE TenHH = N'{name}'").ElementAt(0).SoLuongConSan.ToString();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return quantity;
        }
        public string getMaterialPrice( string id, string name )
        {
            string price = "";
            try
            {
                price = DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaLoaiHH = '{id}' AND TenHH = N'{name}'").ElementAt(0).DonGia.ToString();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return price;
        }
        
        public void insertDetailImportMaterialData(int importId, int materialId, int quantity)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO CT_NHAPHANG (MaNH, MaHH, SoLuong) VALUES ({importId}, {materialId}, {quantity})");
                MessageBox.Show("Nhập nguyên liệu thành công !!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi nhập nguyên liệu: {e}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void updateAvailableMaterialQuantity(string materialName, int importQuantity)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE HANGHOA SET SoluongConSan = SoluongConSan + {importQuantity} WHERE TenHH = N'{materialName}'");
            }
            catch
            {
                MessageBox.Show("Lỗi cập nhật hàng hóa", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public string getPricePerMaterial(int materialId)
        {
            string price = "";
            try
            {
                price = DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaHH = {materialId}").ElementAt(0).DonGia.ToString();
            }
            catch 
            {
                MessageBox.Show("Lỗi hiển thị giá của nguyên liệu nhập hàng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return price;
        }
        public void updateCurrentTotalPrice(int importId, int totalImportPrice)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHAPHANG SET TongTienNH = TongTienNH + {totalImportPrice} WHERE MaNH = {importId}");
            }
            catch
            {
                MessageBox.Show("Lỗi cập nhật tổng giá tiền nhập hàng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
