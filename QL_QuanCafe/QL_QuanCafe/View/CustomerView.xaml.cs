using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        CustomerViewModel customerVM = new CustomerViewModel();
        CafeShopEntities entity = new CafeShopEntities();
        string type;
        Frame MainContent;
        public CustomerView(Frame MainContent, string type)
        {
            InitializeComponent();
            this.MainContent = MainContent;
            this.type = type;
            LoadData();
            LoadCustomerData();
        }
        void LoadData()
        {
            if ( type == "update" )
            {
                string userName = Properties.Settings.Default.user;
                tbUserName.Text = entity.NHANVIENs.Where(employee => employee.MaNV.ToString() == userName).FirstOrDefault().TenNV;

            }
            else
            {
                string userName = Properties.Settings.Default.user;
                AdminViewModel admin = new AdminViewModel();
                tbUserName.Text = admin.getAdminName(userName);
            }
        }
        void LoadCustomerData()
        {
            DataTable dt = new DataTable();

            DataColumn dc;
            dc = new DataColumn("Mã khách hàng");
            dt.Columns.Add(dc);
            dc = new DataColumn("Tên khách hàng");
            dt.Columns.Add(dc);
            dc = new DataColumn("Số điện thoại");
            dt.Columns.Add(dc);
            dc = new DataColumn("Email");
            dt.Columns.Add(dc);
            dc = new DataColumn("Địa chỉ");
            dt.Columns.Add(dc);
         
            foreach ( var item in customerVM.getCustomerList() )
            {
                dt.Rows.Add(item.MaKH, item.TenKH, item.SDT, item.Email, item.DiaChi);
            }

            dtCustomer.ItemsSource = dt.DefaultView;
        }
    }
}
