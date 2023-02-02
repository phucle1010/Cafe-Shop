using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class ChangeWorkShiftViewModel : ViewModelBase
    {
        public NHANVIEN GetEmployeeInfo(int employeeId)
        {
            return DataProvider.Ins.DB.NHANVIENs.SqlQuery($"SELECT * FROM NHANVIEN WHERE MaNV = {employeeId}").ElementAt(0);
        }

        public int UpdateWorkShift(int employeeId, int workShiftId)
        {
            try
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"UPDATE NHANVIEN SET MaCaLV = {workShiftId} WHERE MaNV = {employeeId}");
            } 
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi: {e}");
                return 0;
            }
            return 1;
        }
    }
}
