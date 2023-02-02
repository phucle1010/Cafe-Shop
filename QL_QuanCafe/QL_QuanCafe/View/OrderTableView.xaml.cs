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
    /// Interaction logic for OrderTableView.xaml
    /// </summary>
    public partial class OrderTableView : Page
    {
        string userName = Properties.Settings.Default.user;
        string tableId;
        string customerId;
        int area = 0;
        CustomerViewModel customer = new CustomerViewModel();
        OrderTableViewModel table = new OrderTableViewModel();
        CafeShopEntities entity = new CafeShopEntities();
        Frame MainContent;
       
        public OrderTableView(Frame MainContent )
        {
            InitializeComponent();
            this.MainContent = MainContent;
            LoadData();
        }

        void LoadData()
        {
            tbUserName.Text = entity.KHACHHANGs.Where(client => client.TenDN == this.userName).First().TenKH;
            txtCusomerName.Text = tbUserName.Text;
            txtPhone.Text = table.GetPhoneNumber(this.userName);
            this.customerId = customer.getCustomerId(this.userName).ToString();
            LoadTable();
        }

        private void LoadTable()
        {
            if (area != 0)
            {
                cbbTable = table.LoadTableData(cbbTable, area);
            } 
        }

        private void btnCancel_Click( object sender, RoutedEventArgs e )
        {

        }

        private void btnSave_Click( object sender, RoutedEventArgs e )
        {

            DateTime time = new DateTime();
            if ( PresetTimePicker.SelectedTime != null )
            {
                time = PresetTimePicker.SelectedTime.Value;
            }
            string note = txtNote.Text;
            if ( time == null )
            {
                MessageBox.Show("Bạn chưa chọn thời gian đến", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if ( string.IsNullOrEmpty(tableId) )
                    MessageBox.Show("Bạn chưa chọn bàn!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    if (table.InsertOrderTableData(tableId, customerId, note, time) == 1)
                    {
                        MessageBox.Show("Bạn đã đặt bàn, vui lòng chờ nhân viên xác nhận đặt bàn!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainContent.Navigate(new OrderTableView(MainContent));
                    }
                }
            }
        }

        private void cbbTable_Change( object sender, SelectionChangedEventArgs e )
        {
            this.tableId = table.GetTableId(cbbTable.SelectedItem.ToString());
        }

        private void btnShowArea1_Click( object sender, RoutedEventArgs e )
        {
            this.area = 1;
            cbbTable.Items.Clear();
            cbbTable = table.LoadTableData(cbbTable, area);
        }

        private void btnShowArea2_Click( object sender, RoutedEventArgs e )
        {
            this.area = 2;
            cbbTable.Items.Clear();
            cbbTable = table.LoadTableData(cbbTable, area);
        }

        private void btnShowArea3_Click( object sender, RoutedEventArgs e )
        {
            this.area = 3;
            cbbTable.Items.Clear();
            cbbTable = table.LoadTableData(cbbTable, area);
        }

        private void btnViewHistory_MouseMove( object sender, MouseEventArgs e )
        {
            iconHistory.Foreground = new SolidColorBrush(Colors.LightGray);
            tbHistory.Foreground = new SolidColorBrush(Colors.LightGray);
        }

        private void btnViewHistory_MouseLeave( object sender, MouseEventArgs e )
        {
            iconHistory.Foreground = new SolidColorBrush(Colors.Gray);
            tbHistory.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void btnViewHistory_Click( object sender, RoutedEventArgs e )
        {
            OrderTableHistoryView orderTableHistory = new OrderTableHistoryView();
            orderTableHistory.Show();
        }
    }
}
