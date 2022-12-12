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
        public void SubmitOrderTable(int orderTableId, string tableId)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE DATBAN SET TrangThai=1 WHERE MaDatBan={orderTableId}");
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE BAN SET TrangThai=0 WHERE MaBan='{tableId}'");
                System.Windows.MessageBox.Show($"Xác nhận đặt bàn thành công!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show($"Lỗi: {e}");
            }
        }
    }
}
