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

        public ComboBox LoadTableData(ComboBox combo)
        {
            int count = DataProvider.Ins.DB.BANs.SqlQuery("SELECT * FROM BAN").Count();
            try
            {
                for ( int i = 0; i < count; i++ )
                {
                    string a = DataProvider.Ins.DB.BANs.SqlQuery("SELECT * FROM BAN WHERE TrangThai != 1").ElementAt(i).TenBan.ToString();
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

        int RandomOrderTableId()
        {
            Random rd = new Random();
            return rd.Next(100000, 999999);
        }

        bool IsExistedOrderTableId(int orderTableId)
        {
            int nRowData = 0;
            try
            {
                nRowData = DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN WHERE MaDatBan = '{orderTableId}'").Count();
            }
            catch
            {
            }
            return nRowData > 0;
        }

        public void InsertOrderTableData(string tableId, string customerId, string note, DateTime bookTime)
        {
            int orderTableId = 0;
            do
            {
                orderTableId = RandomOrderTableId();
            } while ( IsExistedOrderTableId(orderTableId) );

            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO DATBAN values ('{orderTableId}' '{tableId}', 0, '{customerId}', '{note}', '{bookTime.ToString("yyyy/MM/dd")}')");
                MessageBox.Show("Bạn đã đặt bàn, vui lòng chờ nhân viên xác nhận đặt bàn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
