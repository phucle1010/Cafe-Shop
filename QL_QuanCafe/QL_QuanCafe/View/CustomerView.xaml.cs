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
            foreach ( var customer in customerVM.getCustomerList() )
            {
                plCustomer.Children.Add(new CustomerItemView(customer));
            }
        }
    }
}
