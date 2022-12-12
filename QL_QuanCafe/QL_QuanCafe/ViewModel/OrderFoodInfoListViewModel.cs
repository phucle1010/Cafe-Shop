using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class OrderFoodInfoListViewModel : ViewModelBase
    {
        public int GetCustomerId(string user)
        {
            return DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN='{user}'").ElementAt(0).MaKH;
        }

        public bool IsSubmitOrderTable( int userId )
        {
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN WHERE MaKH={userId} AND TrangThai=1 AND TrangThaiDatMon=0").Count() > 0;
        }

        public bool IsWaitingForSubmitOrderTable( int userId )
        {
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN WHERE MaKH={userId} AND TrangThai=0 AND TrangThaiDatMon=0").Count() > 0;
        }

        public int NumberOfMaterialForFood(int foodId)
        {
            return DataProvider.Ins.DB.CT_SANPHAM.SqlQuery($"SELECT * FROM CT_SANPHAM WHERE MaSP={foodId}").Count();
        }

        public int GetMaterialId(int foodId, int index)
        {
            return (int)DataProvider.Ins.DB.CT_SANPHAM.SqlQuery($"SELECT * FROM CT_SANPHAM WHERE MaSP={foodId}").ElementAt(index).MaHH;
        }

        public int GetMinQuantityForFood(int foodId, int materialId)
        {
            return (int) DataProvider.Ins.DB.CT_SANPHAM.SqlQuery($"SELECT * FROM CT_SANPHAM WHERE MaSP={foodId} AND MaHH={materialId}").ElementAt(0).SoLuong;
        }

        public int GetAvailableQuantityOfMaterial(int materialId)
        {
            return (int)DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaHH={materialId}").ElementAt(0).SoLuongConSan;
        }
    }
}
