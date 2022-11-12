﻿using QL_QuanCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QL_QuanCafe.ViewModel
{
    class CustomerViewModel
    {
        public bool isLoginWithCustomerRole( string user, string pass )
        {
            LoginViewModel login = new LoginViewModel();
            int successDataRows = 0;
            try
            {
                successDataRows = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}' AND MatKhau = '{pass}'").Count();
            }
            catch ( Exception e )
            {
                throw (e);
            }
            return successDataRows > 0;
        }
        public string getCustomerName (string user)
        {
            string name = "";
            try
            {
                name = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"SELECT * FROM KHACHHANG WHERE TenDN = '{user}'").ElementAt(0).TenKH.ToString();
            }
            catch (Exception e )
            {
                MessageBox.Show(e.ToString(), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return name;
        }
    }
}
