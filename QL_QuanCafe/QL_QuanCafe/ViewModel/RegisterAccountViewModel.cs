using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class RegisterAccountViewModel : ViewModelBase
    {
        public string CreateIdCustommer()
        {
            string ID = "000000";
            int nAcount = 0;
            int maxId = 0;
            string id = "000001";
            nAcount = DataProvider.Ins.DB.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG").Count();
            if ( nAcount > 0 )
            {
                maxId = Int32.Parse(DataProvider.Ins.DB.KHACHHANGs.SqlQuery("SELECT * FROM KHACHHANG ORDER  BY MaKH DESC").ElementAt(0).MaKH.ToString());
                int nextId = ++maxId;
                int lNextId = nextId.ToString().Length;
                string subId = ID.Substring(0, 6 - lNextId);
                id = string.Concat(subId, nextId);
            }
            return id;
        }

        public bool IsExistedUsername( string username )
        {
            int nDataRows = 0;
            try
            {
                nDataRows = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN ='{username}'").Count();
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
            return nDataRows > 0;
        }

        public int InsertCustomerData( string fullname, string customerType, string phone, string email, string address, string username, string pass )
        {
            string passHash = this.ComputeSha256Hash(pass);
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO KHACHHANG (TenKH, MaLoaiKH, SDT, Email, DiaChi, TenDN, MatKhau) VALUES (N'{fullname}', '{customerType}','{phone}','{email}',N'{address}',N'{username}','{passHash}')");
                int customerId = DataProvider.Ins.DB.KHACHHANGs.Where(user => user.TenDN == username).First().MaKH;
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO THETICHDIEM (MaKH, DiemTichLuy) VALUES ({customerId}, 0)");
            }
            catch 
            {
                MessageBox.Show("Lỗi đăng ký thành viên. Hệ thống đang xử lý", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return 1;
        }

        public int RandomPass()
        {
            Random rd = new Random();
            return rd.Next(1000000, 9999999);
        }

        public string getWorkShiftId (string workShiftName)
        {
            string id = "";
            try
            {
                id = DataProvider.Ins.DB.CALAMVIECs.SqlQuery($"SELECT * FROM CALAMVIEC WHERE TenCaLV = N'{workShiftName}'").ElementAt(0).MaCaLV.ToString();
            }
            catch
            {

            }
            return id;
        }

        public int InsertEmployeeData( string fullname, string phone, string email, string address, string workShiftName, string position, int gender )
        {
            string pass = "123456";
            string workShiftId = getWorkShiftId(workShiftName);
            string passHash = this.ComputeSha256Hash(pass); 
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"INSERT INTO NHANVIEN (MatKhau, TenNV, SDT, Email, DiaChi, ChucVu, NgayVaoLam, GioiTinh, MaCaLV) VALUES ('{passHash}', N'{fullname}', '{phone}', '{email}', N'{address}', '{position}', '{DateTime.Now.ToString("yyyy/MM/dd")}', {gender}, '{workShiftId}')");
                MessageBox.Show("Thêm nhân viên mới thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show($"Mật khẩu của tài khoản: {pass}");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
            return 1;
        }

        public string ComputeSha256Hash( string rawData )
        {
            using ( SHA256 sha256Hash = SHA256.Create() )
            {
                byte [] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for ( int i = 0; i < bytes.Length; i++ )
                {
                    builder.Append(bytes [i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
