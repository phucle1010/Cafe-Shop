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

        public void InsertDataToOrderFood(int customerId, int orderTableId)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO DATMON (MaKH, MaDatBan, TongTien) VALUES ({customerId}, {orderTableId}, 0)");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi: {e}");
            }
        }

        public int GetOrderFoodId(int customerId)
        {
            return DataProvider.Ins.DB.DATMONs.SqlQuery($"SELECT * FROM DATMON dm, DATBAN db WHERE dm.MaDatBan = db.MaDatBan AND dm.MaKH={customerId} AND db.TrangThaiDatMon=0 AND db.TrangThai=1").ElementAt(0).MaDM;
        }

        public int GetFoodPrice(int foodId)
        {
            return (int)DataProvider.Ins.DB.SANPHAMs.SqlQuery($"SELECT * FROM SANPHAM WHERE MaSP={foodId}").ElementAt(0).GiaSP;
        }

        public int InsertDataToOrderFoodDetail(int orderFoodId, int foodId, int quantity, int price) 
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO CT_DATMON (MaDM, MaSP, SoLuong) VALUES ({orderFoodId}, {foodId}, {quantity})");
                /// UPDATE LẠI SỐ LƯỢNG CÒN SẴN Ở HANGHOA
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE DATMON SET TongTien = TongTien + {quantity * price} WHERE MaDM={orderFoodId}");
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
    }
}
