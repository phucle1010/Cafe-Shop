using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_QuanCafe.ViewModel
{
    public class FoodViewModel : ViewModelBase
    {
        public List<SANPHAM> GetAllFood()
        {
            return DataProvider.Ins.DB.SANPHAMs.SqlQuery("SELECT * FROM SANPHAM").ToList<SANPHAM>();
        }

    }
}
