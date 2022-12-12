using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class MaterialTypeListViewModel : ViewModelBase
    {
        public int GetImportId()
        {
            int nRows = DataProvider.Ins.DB.NHAPHANGs.SqlQuery($"SELECT * FROM NHAPHANG").Count();
            return DataProvider.Ins.DB.NHAPHANGs.SqlQuery($"SELECT * FROM NHAPHANG").ElementAt(nRows - 1).MaNH;
        }
        public string getProviderId()
        {
            string id = "";
            try
            {
                id = DataProvider.Ins.DB.NHACUNGCAPs.SqlQuery($"SELECT * FROM NHACUNGCAP").ElementAt(0).MaNCC.ToString();
            }
            catch
            {

            }
            return id;
        }
        public void insertImportMaterialData( string employeeId, int totalPrice )
        {
            string providerId = getProviderId();
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO NHAPHANG (MaNV, NgayNH, TongTienNH, MaNCC) VALUES ({employeeId}, '{DateTime.Now.ToString("yyyy/MM/dd")}', {totalPrice} , '{providerId}')");
                MessageBox.Show("Tạo mã nhập hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
