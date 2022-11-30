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
        public CustomerView()
        {
            InitializeComponent();
            LoadData();
            LoadCustomerData();
        }
        void LoadData()
        {
            AdminViewModel admin = new AdminViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = admin.getAdminName(userName);
        }
        void LoadCustomerData()
        {
            DataTable dt = new DataTable();

            DataColumn dc;
            dc = new DataColumn("id");
            dt.Columns.Add(dc);
            dc = new DataColumn("name");
            dt.Columns.Add(dc);
            dc = new DataColumn("phone");
            dt.Columns.Add(dc);
            dc = new DataColumn("email");
            dt.Columns.Add(dc);
            dc = new DataColumn("address");
            dt.Columns.Add(dc);
            dc = new DataColumn("accPoint");
            dt.Columns.Add(dc);

            //int nRows = customerVM.getCustomerList().Count;
            //var customerDataList = customerVM.getCustomerList();
            //foreach (var item in customerVM.getCustomerList() )
            //{

            //}

            MessageBox.Show(dt.Rows.Count.ToString());
            //dtCustomer.ItemsSource = customerVM.getCustomerList();
        }
    }
}
