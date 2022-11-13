using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QL_QuanCafe.Model;
namespace QL_QuanCafe.ViewModel
{
    internal class RegisterViewModel:ViewModelBase
    {


        public string CreateIdCustommer()
        {
            string ID = "000000";
            int nAcount = 0;
            int maxId = 0;
            string id = "000001";
            nAcount = DataProvider.Ins.DB.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG").Count();
            if (nAcount > 0)
            {               
                maxId = Int32.Parse(DataProvider.Ins.DB.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG ORDER  BY MaKH DESC").ElementAt(0).MaKH.ToString());
                int nextId = ++maxId;
                int lNextId = nextId.ToString().Length;
                string subId = ID.Substring(0, 6 - lNextId);
                id = string.Concat(subId, nextId);

            }
            return id;
        }

        public string CreateIdStaff()
        {
            string ID = "000000";
            int nAcount = 0;
            int maxId = 0;
            string id = "000001";
            nAcount = DataProvider.Ins.DB.NHANVIENs.SqlQuery("SELECT * FROM NHANVIEN").Count();
            if (nAcount > 0)
            {
                maxId = Int32.Parse(DataProvider.Ins.DB.NHANVIENs.SqlQuery("SELECT * FROM NHANVIEN ORDER  BY MaNV DESC").ElementAt(0).MaNV.ToString());
                int nextId = ++maxId;
                int lNextId = nextId.ToString().Length;
                string subId = ID.Substring(0, 6 - lNextId);
                id = string.Concat(subId, nextId);

            }
            return id;
        }
        public bool haveUsernameIsUsing( string username)
        {
            int nDataRows = 0;
            try
            {
                nDataRows = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN ='{username}'").Count();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return nDataRows > 0;
        }
        public void UpdateData(string ten,string loaikh, string sdt, string email, string diachi,int diemtichluy, string tendn, string matkhau )
        {
            string makh = this.CreateIdCustommer();
            string matkhauhash=this.ComputeSha256Hash(matkhau);
            DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO KHACHHANG VALUES ('{makh}', N'{ten}', '{loaikh}','{sdt}','{email}',N'{diachi}',{diemtichluy},N'{tendn}','{matkhauhash}')");
        }

        public void UpdateDataStaff(string ten,string matkhau, string sdt, string email, string diachi, float luong, string chucvu, string ngayvaolam, int giotinh)
        {
            string manv = this.CreateIdStaff();
            string matkhauhash = this.ComputeSha256Hash(matkhau);
            DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO NHANVIEN VALUES ('{manv}','{matkhauhash}', N'{ten}','{sdt}','{email}',N'{diachi}',{luong},'{chucvu}','{ngayvaolam}',{giotinh},{1})");
        }

        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
