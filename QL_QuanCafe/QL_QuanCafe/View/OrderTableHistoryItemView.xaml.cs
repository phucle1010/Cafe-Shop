using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Interaction logic for OrderTableHistoryItemView.xaml
    /// </summary>
    public partial class OrderTableHistoryItemView : UserControl
    {
        OrderTableViewModel orderTableVM = new OrderTableViewModel();
        DATBAN orderTable;
        ListView mergedTableList;
        ComboBox cbChangedTable;
        public OrderTableHistoryItemView()
        {
            InitializeComponent();
        }

        public OrderTableHistoryItemView(DATBAN orderTable, ListView mergedTableList, ComboBox cbChangedTable )
        {
            InitializeComponent();
            this.orderTable = orderTable;
            this.mergedTableList = mergedTableList;
            this.cbChangedTable = cbChangedTable;
            LoadUI();
        }

        private void LoadUI()
        {
            tbTableName.Text = orderTableVM.GetTableName(orderTable.MaBan);
            tbCustomerName.Text = orderTableVM.GetCustomerName((int) orderTable.MaKH);
            tbTotal.Text = String.Format("{0:C0}", orderTableVM.GetCurrentTotalOfTable(orderTable.MaDatBan));
            if ((bool) orderTable.TrangThaiDatMon)
            {
                cbMergeTable.Visibility = Visibility.Hidden;
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

        private void cbMergeTable_Click( object sender, RoutedEventArgs e )
        {
            if (cbMergeTable.IsChecked == true && !mergedTableList.Items.Contains(tbTableName.Text) )
            {
                mergedTableList.Items.Add(tbTableName.Text);
                cbChangedTable.Items.Add(tbTableName.Text);
            } else
            {
                mergedTableList.Items.Remove(tbTableName.Text);
                cbChangedTable.Items.Remove(tbTableName.Text);
            }
        }
    }
}
