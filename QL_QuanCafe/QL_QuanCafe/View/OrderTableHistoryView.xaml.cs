using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for OrderTableHistoryView.xaml
    /// </summary>
    public partial class OrderTableHistoryView : Window
    {
        OrderTableViewModel orderTableVM = new OrderTableViewModel();
        int customerId;
        List<DATBAN> orderTableList;
        public OrderTableHistoryView()
        {
            InitializeComponent();
            LoadInitUI();
            LoadOrderTableListOfUser();
            ((INotifyCollectionChanged) lvMergedChosedTableList.Items).CollectionChanged += OrderTableHistoryView_CollectionChanged;
        }

        private void LoadInitUI()
        {
            grTableOption.Visibility = Visibility.Hidden;
            plMergedTable.Visibility = Visibility.Hidden;
            btnMergeTable.Visibility = Visibility.Hidden;
            foreach(var item in orderTableVM.GetAllEmptyTable())
            {
                cbChangeTableName.Items.Add(item.TenBan);
            }
        }

        private void OrderTableHistoryView_CollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
        {
            if (lvMergedChosedTableList.Items.Count > 0)
            {
                grTableOption.Visibility = Visibility.Visible;
            }
            else
            {
                grTableOption.Visibility = Visibility.Hidden;
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage( IntPtr hWnd, int wMsg, int wParam, int lParam );

        private void btnMinimize_Click( object sender, RoutedEventArgs e )
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click( object sender, RoutedEventArgs e )
        {
            this.Close();
        }

        private void pnlControlBar_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter( object sender, System.Windows.Input.MouseEventArgs e )
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void LoadOrderTableListOfUser() 
        {
            customerId = Int32.Parse(orderTableVM.GetCustomerId(Properties.Settings.Default ["user"].ToString()));
            orderTableList = orderTableVM.GetAllOrderTableDataOfUser(customerId);
            foreach(var item in orderTableList)
            {
                plOrderTableList.Children.Add(new OrderTableHistoryItemView(item, lvMergedChosedTableList, cbChangedTable));
            }
        }
        private void lvMergedChosedTableList_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            plMergedTable.Visibility = Visibility.Visible;
            btnMergeTable.Visibility = Visibility.Visible;
            var item = lvMergedChosedTableList.SelectedValue;
            tbMergedTableName.Text = item.ToString();
        }

        private void btnMergeTable_Click( object sender, RoutedEventArgs e )
        {
            if (lvMergedChosedTableList.Items.Count == 1)
            {
                MessageBox.Show("Bạn chỉ có thể chuyển bàn vì hiện tại số lượng bàn đặt < 2");
            } 
            else
            {
                int orderTableIdOfMergedChosedTable = orderTableVM.GetOrderTableIdByTableName(tbMergedTableName.Text, customerId);
                foreach ( var item in lvMergedChosedTableList.Items)
                {
                    if (item.ToString() != tbMergedTableName.Text )
                    {
                        /// Xử lý gộp bàn
                        int orderTableIdOfMergedTable = orderTableVM.GetOrderTableIdByTableName(item.ToString(), customerId);
                        int total = orderTableVM.GetCurrentTotalOfTable(orderTableIdOfMergedTable);
                        int billIdOfMergedTable = orderTableVM.GetBillIdOfMergedTable(orderTableIdOfMergedTable);

                        orderTableVM.UpdateTotalBillAfterMerging(orderTableIdOfMergedChosedTable, total, orderTableIdOfMergedTable);
                        if (orderTableVM.UpdateAllDataAgainOfMergedTable(billIdOfMergedTable, orderTableIdOfMergedTable, item.ToString()) == 1)
                        {
                            MessageBoxResult result = MessageBox.Show("Gộp bàn thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            if (result == MessageBoxResult.OK )
                            {
                                plOrderTableList.Children.Clear();
                                LoadOrderTableListOfUser();
                                lvMergedChosedTableList.Items.Clear();
                                LoadInitUI();
                            }
                        }
                    }
                }
            }
        }

        private void btnChangeTable_Click(object sender, RoutedEventArgs e)
        {
            string tableToMoveId = "";
            string tableMoveToId = "";
            if (cbChangedTable.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bàn muốn chuyển, vui lòng chọn lại!");
            }else if (cbChangeTableName.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bàn chuyển đến, vui lòng lại!");
            }
            else
            {
                int orderTableId = orderTableVM.GetOrderTableIdByTableName(cbChangedTable.Text.ToString(), customerId);
                
                tableToMoveId = orderTableVM.GetTableId(cbChangedTable.SelectedItem.ToString());

                tableMoveToId = orderTableVM.GetTableId(cbChangeTableName.SelectedItem.ToString());
               //MessageBox.Show(orderTableVM.getStateOrderTable(orderTableId).ToString());
                if ((bool)orderTableVM.getStateOrderTable(orderTableId))
                {
                    //MessageBox.Show(tableMoveToId);
                    orderTableVM.MoveTable(tableMoveToId, orderTableId);
                    int stateTable = 1;
                    //MessageBox.Show(tableToMoveId);
                    orderTableVM.updateTable(tableToMoveId, stateTable);
                    stateTable = 0;
                    //MessageBox.Show(tableMoveToId);
                    orderTableVM.updateTable(tableMoveToId, stateTable);
                }
                else
                {
                    //MessageBox.Show(tableMoveToId);
                    orderTableVM.MoveTable(tableMoveToId, orderTableId);
                }
                MessageBox.Show("Bạn đã chuyển bàn thành công");
            }
        }
    }
}
