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
    /// Interaction logic for ManageOrderTableView.xaml
    /// </summary>
    public partial class ManageOrderTableView : Page
    {
        ManageOrderTableViewModel mnOrderTbVM = new ManageOrderTableViewModel();
        Frame MainContent;
        public ManageOrderTableView()
        {
            InitializeComponent();
            LoadData();
            LoadOrderTableListData();
        }
        public ManageOrderTableView(Frame MainContent)
        {
            InitializeComponent();
            this.MainContent = MainContent;
            LoadData();
            LoadOrderTableListData();
        }
        void LoadData()
        {
            AdminViewModel admin = new AdminViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = admin.getAdminName(userName);
        }

        void LoadOrderTableListData()
        {
            foreach ( var item in mnOrderTbVM.GetOrderTableList() )
            {
                ManageOrderTableItemView tbItem = new ManageOrderTableItemView(item.MaDatBan, item.MaBan, (int) item.MaKH,(bool) item.TrangThai, MainContent);
                orderTableList.Children.Add(tbItem);
            }
        }
    }
}
