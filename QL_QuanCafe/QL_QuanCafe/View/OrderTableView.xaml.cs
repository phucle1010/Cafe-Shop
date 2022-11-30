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
        string userName = Properties.Settings.Default ["user"].ToString();
        string tableId;
        string customerId;
        CustomerViewModel customer = new CustomerViewModel();
        OrderTableViewModel table = new OrderTableViewModel();
        public OrderTableView()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            tbUserName.Text = customer.getCustomerName(this.userName);
            txtCusomerName.Text = customer.getCustomerName(this.userName);
            txtPhone.Text = table.GetPhoneNumber(this.userName);
            customerId = customer.getCustomerId(this.userName);
            LoadTable();
        }

        private void LoadTable()
        {
            cbbTable = table.LoadTableData(cbbTable);
        }

        private void btnCancel_Click( object sender, RoutedEventArgs e )
        {

        }

        private void btnSave_Click( object sender, RoutedEventArgs e )
        {
            DateTime time = PresetTimePicker.SelectedTime.Value;
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
                    table.InsertOrderTableData(tableId, customerId, note, time);
                }
            }
        }

        private void cbbTable_Change( object sender, SelectionChangedEventArgs e )
        {
            this.tableId = table.GetTableId(cbbTable.SelectedItem.ToString());
            MessageBox.Show(tableId);
        }
    }
}
