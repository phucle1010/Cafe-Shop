using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace QL_QuanCafe.ViewModel
{
    public class ManageOrderTableItemViewModel : ViewModelBase
    {
        public int SubmitOrderTable(int customerId, int orderTableId, string tableId)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE DATBAN SET TrangThai=1 WHERE MaDatBan={orderTableId}");
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE BAN SET TrangThai=0 WHERE MaBan='{tableId}'");
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO HOADON (MaKH, MaDatBan, TongTien, TrangThaiThanhToan, NgayHD) VALUES ({customerId}, {orderTableId}, 0, 0, '{DateTime.Now.ToString("yyyy/MM/dd")}')");
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show($"Lỗi: {e}");
                return 0;
            }
            return 1;
        }
    }
}
