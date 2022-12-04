using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class UpdateEmployeeViewModel : ViewModelBase
    {
        public NHANVIEN GetEmployeeData(int employeeId)
        {
            return DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV={employeeId}").ElementAt(0);
        }

        public int UpdateEmployeeData(int employeeId, string name, string phone, string email, string address, string position) 
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHANVIEN SET TenNV=N'{name}', SDT='{phone}', Email='{email}', DiaChi='{address}', ChucVu='{position}'");
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return 1;
            }catch(Exception e)
            {
                MessageBox.Show($"Lỗi {e}");
            }
            return 0;
        }


    }
}
