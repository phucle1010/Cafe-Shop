using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for OrderFoodHistoryItemView.xaml
    /// </summary>
    public partial class OrderFoodHistoryItemView : UserControl
    {
        OrderTableViewModel orderTableVM = new OrderTableViewModel();
        DATBAN orderTable;
        public OrderFoodHistoryItemView()
        {
            InitializeComponent();
        }

        public OrderFoodHistoryItemView(DATBAN orderTable)
        {
            InitializeComponent();
            this.orderTable = orderTable;
            LoadUI();
        }

        private void LoadUI()
        {
            tbTableName.Text = orderTableVM.GetTableName(orderTable.MaBan);
            tbCustomerName.Text = orderTableVM.GetCustomerName((int) orderTable.MaKH);
            tbTotal.Text = String.Format("{0:C0}", orderTableVM.GetCurrentTotalOfTable(orderTable.MaDatBan));
            if ( (bool) orderTable.TrangThaiDatMon )
            {
                tbStatus.Text = "Đã thanh toán";
            }
            else
            {
                tbStatus.Text = "Chưa thanh toán";
            }
            LoadTimeOfOrder();
        }

        private void LoadTimeOfOrder()
        {
            DateTime time = DateTime.Parse(orderTableVM.GetTimeOfOrder(orderTable.MaDatBan));
            tbTime.Text = $"{time.Day}-{time.Month}-{time.Year}";
        }

        private void btnView_Click( object sender, RoutedEventArgs e )
        {
            OrderFoodHistoryDetailView orderFoodHistoryDetail = new OrderFoodHistoryDetailView(orderTable.MaDatBan);
            orderFoodHistoryDetail.Show();
        }
    }
}
