using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    public class ForgotPasswordViewModel : ViewModelBase
    {
        public bool IsExistedAccount( string _email )
        {
            int successDataRows = 0;
            try
            {
                successDataRows = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE Email = '{_email}'").Count();
                if (successDataRows == 0)
                {
                    successDataRows = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM NHANVIEN WHERE Email = '{_email}'").Count();
                }
            }
            catch 
            {
                MessageBox.Show("Lỗi truy xuất địa chỉ Email người dùng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return successDataRows > 0;
        }
    }
}
