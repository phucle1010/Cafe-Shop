using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.ViewModel
{
    public class PaymentViewModel : ViewModelBase
    {
        public List<HOADON> billListNotPayments()
        {
            return DataProvider.Ins.DB.HOADONs.SqlQuery("SELECT * FROM HOADON WHERE TrangThaiThanhToan = 0").ToList();
        }

        public List<HOADON> billListHasPayments()
        {
            return DataProvider.Ins.DB.HOADONs.SqlQuery("SELECT * FROM HOADON WHERE TrangThaiThanhToan = 1").ToList();
        }

        public string GetCustomerName(int customerId)
        {
            return DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE MaKH={customerId}").ElementAt(0).TenKH;
        }

        public string GetTableId(int orderTableId)
        {
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN WHERE MaDatBan={orderTableId}").ElementAt(0).MaBan;
        }

        public string GetTableName(string tableId)
        {
            return DataProvider.Ins.DB.BANs.SqlQuery($"SELECT * FROM BAN WHERE MaBan='{tableId}'").ElementAt(0).TenBan;
        }
    }
}
