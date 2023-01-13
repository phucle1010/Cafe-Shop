using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.ViewModel
{
    internal class BillDetailItemViewModel : ViewModelBase
    {
        public SANPHAM GetFoodInfo(int foodId)
        {
            return DataProvider.Ins.DB.SANPHAMs.SqlQuery($"SELECT * FROM SANPHAM WHERE MaSP={foodId}").ElementAt(0);
        }
    }
}
