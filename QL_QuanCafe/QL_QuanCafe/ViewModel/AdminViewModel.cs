using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        
        public bool isLoginWithAdminRole( string user, string pass )
        {
            LoginViewModel login = new LoginViewModel();
            var hashPass = login.ComputeSha256Hash(pass);
            try
            {
                return DataProvider.Ins.DB.NHANVIENs.Where(employee => employee.MaNV.ToString() == user && employee.MatKhau == hashPass).Count() > 0;
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.ToString());
            }
            return false;
        }
        public string getAdminName( string userName )  
        {
            CafeShopEntities entity = new CafeShopEntities();   
            return entity.NHANVIENs.Where(employee => employee.MaNV.ToString() == userName).First().TenNV;
        }

        public int getTheNumberOfEmployee()
        {
            return DataProvider.Ins.DB.NHANVIENs.Count();
        }
    }
}
