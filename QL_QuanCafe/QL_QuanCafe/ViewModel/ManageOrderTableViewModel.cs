using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class ManageOrderTableViewModel : ViewModelBase 
    {
        public List<DATBAN> GetOrderTableList()
        {
            return DataProvider.Ins.DB.DATBANs.SqlQuery($"SELECT * FROM DATBAN").ToList<DATBAN>();
        }
    }
}
