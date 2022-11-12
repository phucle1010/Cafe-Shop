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
        public int insertImportId(int importId)
        {
            int nRows = 0;
            try
            {
                nRows = DataProvider.Ins.DB.NHAPHANGs.SqlQuery($"SELECT * FROM NHAPHANG WHERE MaNH = '{importId}'").Count();
            }
            catch
            {

            }
            return nRows;
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
        public void insertImportMaterialData( int importId, string employeeId, int totalPrice )
        {
            string providerId = getProviderId();
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO NHAPHANG VALUES ('{importId}', '{employeeId}', '{DateTime.Now.ToString("dd/MM/yyyy")}', {totalPrice} , '{providerId}')");
                MessageBox.Show("Tạo mã nhập hàng thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
