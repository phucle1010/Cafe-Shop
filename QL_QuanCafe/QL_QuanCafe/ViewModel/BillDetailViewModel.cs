using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_QuanCafe.ViewModel
{
    internal class BillDetailViewModel : ViewModelBase
    {
        public List<CT_HOADON> GetBillDetailList(int billId)
        {
            return DataProvider.Ins.DB.CT_HOADON.SqlQuery($"SELECT * FROM CT_HOADON WHERE MaHD={billId}").ToList();
        }

        public SANPHAM GetFoodInfo( int foodId )
        {
            return DataProvider.Ins.DB.SANPHAMs.SqlQuery($"SELECT * FROM SANPHAM WHERE MaSP={foodId}").ElementAt(0);
        }

        public int GetOrderTableId(int billId)
        {
            return (int) DataProvider.Ins.DB.HOADONs.SqlQuery($"SELECT * FROM HOADON WHERE MaHD={billId}").ElementAt(0).MaDatBan;
        }

        public string GetTableId(int orderTableId)
        {
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN WHERE MaDatBan={orderTableId}").ElementAt(0).MaBan;
        }

        public int GetEmplyeeId(string username)
        {
            return DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV={username}").ElementAt(0).MaNV;
        }

        public int UpdateBill(int billId, int orderTableId, string tableId, int employeeId)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE HOADON SET TrangThaiThanhToan=1, MaNV={employeeId}, NgayHD='{DateTime.Now.ToString("yyyy/MM/dd")}' WHERE MaHD={billId}");
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE DATBAN SET TrangThaiDatMon=1 WHERE MaDatBan={orderTableId}");
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE BAN SET TrangThai=1 WHERE MaBan='{tableId}'");
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi: {e}");
            }
            return 0;
        }
    }
}
