using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace QL_QuanCafe.ViewModel
{
    public class AddFoodMaterialViewModel : ViewModelBase
    {
        //public List<LOAIHANGHOA> GetAllProductType()
        //{
        //    return DataProvider.Ins.DB.LOAIHANGHOAs.SqlQuery("SELECT * FROM LOAIHANGHOA").ToList<LOAIHANGHOA>();
        //}

        public string GetProductName(string typeId)
        {
            return DataProvider.Ins.DB.LOAIHANGHOAs.SqlQuery($"SELECT * FROM LOAIHANGHOA WHERE MaloaiHH='{typeId}'").ElementAt(0).TenLoaiHH.ToString();
        }

        public string GetProductTypeId( string name)
        {
            return DataProvider.Ins.DB.LOAIHANGHOAs.SqlQuery($"SELECT * FROM LOAIHANGHOA WHERE TenloaiHH=N'{name}'").ElementAt(0).MaLoaiHH.ToString();
        }

        public string GetProductId(string materialName, string typeId)
        {
            return DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE TenHH=N'{materialName}' AND MaLoaiHH='{typeId}'").ElementAt(0).MaHH.ToString();
        }

        public List<string> GetAllProductWithTypeId( string id )
        {
            var result = DataProvider.Ins.DB.HANGHOAs.Where(item => item.MaLoaiHH == id).Select(m => m.TenHH).Distinct().ToList();
            return result;
        }

        public string GetUnitOfProduct(string name)
        {
            return DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE TenHH=N'{name}'").ElementAt(0).DonVi.ToString();
        }

        public int InsertMaterialData(string foodId, int materialId, int quantity)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO CT_SANPHAM (MaSP, MaHH, SoLuong) VALUES (${foodId}, ${materialId}, ${quantity})");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi {e}");
                return 0;
            }
            return 1;
        }

       
    }
}
