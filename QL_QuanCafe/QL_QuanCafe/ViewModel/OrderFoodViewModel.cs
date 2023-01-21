using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class OrderFoodViewModel : ViewModelBase
    {
        public int GetCustomerId(string userName)
        {
            return DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN='{userName}'").ElementAt(0).MaKH;
        }
        public DATBAN GetOrderTabeleInfo(int customerId)
        {
            
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN WHERE MaKH={customerId} AND TrangThai=1 AND TrangThaiDatMon=0").ElementAt(0);
        }

        public List<SANPHAM> GetAllFood()
        {
            return DataProvider.Ins.DB.SANPHAMs.SqlQuery("SELECT * FROM SANPHAM").ToList<SANPHAM>();
        }

        public bool IsOrdering(int customerId)
        {
            return DataProvider.Ins.DB.HOADONs.SqlQuery($"SELECT * FROM HOADON WHERE MaKH={customerId} AND TrangThaiThanhToan = 0").Count() > 0;
        }

        public void InsertDataToBill(int customerId, int orderTableId)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO HOADON (MaKH, MaDatBan, TongTien, TrangThaiThanhToan, NgayHD) VALUES ({customerId}, {orderTableId}, 0, 0, '{DateTime.Now.ToString("yyyy/MM/dd")}')");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi: {e}");
            }
        }

        public int GetBillId(int customerId)
        {
            return DataProvider.Ins.DB.HOADONs.SqlQuery($"SELECT * FROM HOADON hd, DATBAN db WHERE hd.MaDatBan = db.MaDatBan AND hd.MaKH={customerId} AND db.TrangThaiDatMon=0 AND db.TrangThai=1").ElementAt(0).MaHD;
        }

        public int GetFoodPrice(int foodId)
        {
            return (int)DataProvider.Ins.DB.SANPHAMs.SqlQuery($"SELECT * FROM SANPHAM WHERE MaSP={foodId}").ElementAt(0).GiaSP;
        }

        public int InsertDataToBillDetail(int billId, int foodId, int quantity, int price) 
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO CT_HOADON (MaHD, MaSP, SoLuong) VALUES ({billId}, {foodId}, {quantity})");
                /// UPDATE LẠI SỐ LƯỢNG CÒN SẴN Ở HANGHOA
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE HOADON SET TongTien = TongTien + {quantity * price} WHERE MaHD={billId}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi: {e}");
                return 0;
            }
            return 1;
        }

        public List<CT_SANPHAM> GetFoodDetailInfo(int foodId)
        {
            return DataProvider.Ins.DB.CT_SANPHAM.SqlQuery($"SELECT * FROM CT_SANPHAM WHERE MaSP={foodId}").ToList<CT_SANPHAM>();
        }

        public string GetMaterialName(int materialId)
        {
            return DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaHH={materialId}").ElementAt(0).TenHH;
        }

        public void UpdateAvailableQuantityOfMaterial(string materialName, int usedQuantityTotal)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE HANGHOA SET SoLuongConSan = SoLuongConSan - {usedQuantityTotal} WHERE TenHH=N'{materialName}'");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi {e}");
            }
        }

        public List<CT_HOADON> GetOrderDetailOfCustomer(int orderTableId)
        {
            var billId = DataProvider.Ins.DB.HOADONs.Where(hd => hd.MaDatBan == orderTableId).Select(x => new { x.MaHD }).First().MaHD;
            return DataProvider.Ins.DB.CT_HOADON.Where(ct => ct.MaHD == billId).Select(x => x).ToList();
        }

        public string GetFoodName(int foodId) 
        {
            return DataProvider.Ins.DB.SANPHAMs.Where(food => food.MaSP == foodId).Select(food => new { food.TenSP }).First().TenSP;
        }
    }
}
