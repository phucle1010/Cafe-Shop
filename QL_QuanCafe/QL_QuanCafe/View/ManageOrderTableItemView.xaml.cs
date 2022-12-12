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
    /// Interaction logic for ManageOrderTableItemView.xaml
    /// </summary>
    public partial class ManageOrderTableItemView : UserControl
    {
        ManageOrderTableItemViewModel mnOrderTableItemVM = new ManageOrderTableItemViewModel();
        public ManageOrderTableItemView( int maDatBan )
        {
            InitializeComponent();
        }

        public ManageOrderTableItemView( int orderTableId, string tableId, int customerId, bool status )
        {
            InitializeComponent();
            tbOrderTableId.Text = orderTableId.ToString();
            tbTableId.Text = tableId;
            tbCustomerId.Text = customerId.ToString();
            tbStatus.Text = status == true ? "Đã xác nhận" : "Chưa xác nhận";
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            if (tbStatus.Text == "Đã xác nhận")
            {
                MessageBox.Show("Bàn đã được xác nhận trước đó. Vui lòng chọn bàn đặt khác!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else
            {
                mnOrderTableItemVM.SubmitOrderTable(Int32.Parse(tbOrderTableId.Text), tbTableId.Text);
            }
        }
    }
}
