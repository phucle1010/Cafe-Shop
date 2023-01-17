using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QL_QuanCafe.ViewModel
{
    public class OrderTableViewModel : ViewModelBase
    {
        public string GetPhoneNumber(string user)
        {
            string phone = ""; 
            try
            {
                phone = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).SDT.ToString();
            }
            catch 
            {
            }
            return phone;
        }

        public ComboBox LoadTableData(ComboBox combo, int area)
        {
            int count = DataProvider.Ins.DB.BANs.SqlQuery($"SELECT * FROM BAN WHERE MaKV='{area}'").Count();
            try
            {
                for ( int i = 0; i < count; i++ )
                {
                    string a = DataProvider.Ins.DB.BANs.SqlQuery($"SELECT * FROM BAN WHERE TrangThai = 1 AND MaKV='{area}'").ElementAt(i).TenBan.ToString();
                    combo.Items.Add(a);
                }
            }
            catch 
            {
            }
            return combo;
        }

        public string GetCustomerId (string user)
        {
            string customerId = "";
            try
            {
                customerId = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).MaKH.ToString();
            }
            catch 
            {
            }
            return customerId;
        }

        public string GetCustomerName( int customerId )
        {
            return DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE MaKH='{customerId}'").ElementAt(0).TenKH;
        }

        public string GetTableId( string tableName )
        {
            string tableId = "";
            try
            {
                tableId = DataProvider.Ins.DB.BANs.SqlQuery($"select * from Ban WHERE TenBan = N'{tableName}'").ElementAt(0).MaBan.ToString();
            }
            catch 
            {
            }
            return tableId;
        }

        public string GetTableName(string tableId)
        {
            return DataProvider.Ins.DB.BANs.SqlQuery($"SELECT * FROM BAN WHERE MaBan='{tableId}'").ElementAt(0).TenBan;
        }

        public int GetCurrentTotalOfTable(int orderTableId)
        {
            return (int) DataProvider.Ins.DB.HOADONs.SqlQuery($"SELECT * FROM HOADON WHERE MaDatBan={orderTableId}").ElementAt(0).TongTien;
        }

        public string GetTimeOfOrder(int orderTableId)
        {
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN WHERE MaDatBan={orderTableId}").ElementAt(0).GioDat.ToString();
        }

        public void InsertOrderTableData(string tableId, string customerId, string note, DateTime bookTime)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO DATBAN (MaBan, TrangThai, MaKH, GioDat, GhiChu, TrangThaiDatMon) values ('{tableId}', 0, {customerId}, '{bookTime.ToString("yyyy/MM/dd")}', '{note}', 0)");
                MessageBox.Show("Bạn đã đặt bàn, vui lòng chờ nhân viên xác nhận đặt bàn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<DATBAN> GetAllOrderTableDataOfUser(int customerId)
        {
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN WHERE MaKH={customerId}").ToList<DATBAN>();
        }

        public List<BAN> GetAllEmptyTable()
        {
            return DataProvider.Ins.DB.BANs.SqlQuery("SELECT * FROM BAN WHERE TrangThai=1").ToList<BAN>();
        }

        public int GetOrderTableIdByTableName(string tableName, int customerId)
        {
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN DB, BAN B WHERE DB.MaBan = B.MaBan AND DB.MaKH={customerId} AND B.TenBan=N'{tableName}' AND DB.TrangThaiDatMon=0").ElementAt(0).MaDatBan;
        }

        public void UpdateTotalBillAfterMerging(int orderTableIdOfMergedChosedTable, int total ) 
        {
            DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE HOADON SET TongTien += {total} WHERE MaDatBan={orderTableIdOfMergedChosedTable}");
        }

        public int GetBillIdOfMergedTable(int orderTableId)
        {
            return DataProvider.Ins.DB.HOADONs.SqlQuery($"SELECT * FROM HOADON WHERE MaDatBan={orderTableId}").ElementAt(0).MaHD;
        }

        public int UpdateAllDataAgainOfMergedTable( int billIdOfMergedChosedTable, int billIdOfMergedTable, int mergedTableId, string mergedChosedTableName )
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE CT_HOADON SET MaHD={billIdOfMergedChosedTable} WHERE MaHD={billIdOfMergedTable}");
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"DELETE FROM HOADON WHERE MaHD={billIdOfMergedTable}");  /// Cập nhật lại thành mã của hóa đơn được gộp
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE BAN SET TrangThai=1 WHERE TenBan=N'{mergedChosedTableName}'");
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"DELETE FROM DATBAN WHERE MaDatBan={mergedTableId}");
            }
            catch (Exception e)
            {
                return 0;
                throw e;
            }
            return 1;
        }
    }
}
