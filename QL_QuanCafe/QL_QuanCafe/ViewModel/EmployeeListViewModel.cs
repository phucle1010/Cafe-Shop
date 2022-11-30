using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.ViewModel
{
    public class EmployeeListViewModel : ViewModelBase
    {
        public List<NHANVIEN> getEmployeeList()
        {
            var customerList = DataProvider.Ins.DB.NHANVIENs.SqlQuery("SELECT * FROM NHANVIEN").ToList<NHANVIEN>();
            return customerList;
        }
    }
}
