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
        Frame MainContent;
        public ManageOrderTableItemView( int maDatBan )
        {
            InitializeComponent();
        }

        public ManageOrderTableItemView( int orderTableId, string tableId, int customerId, bool status, Frame MainContent )
        {
            InitializeComponent();
            this.MainContent = MainContent;
            tbOrderTableId.Text = orderTableId.ToString();
            tbTableId.Text = tableId;
            tbCustomerId.Text = customerId.ToString();
            if (status)
            {
                tbStatus.Text = "Đã xác nhận";
                btnSubmit.Visibility = Visibility.Hidden;
            } 
            else
            {
                tbStatus.Visibility = Visibility.Hidden;
            }
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            if (tbStatus.Text == "Đã xác nhận")
            {
                MessageBox.Show("Bàn đã được xác nhận trước đó. Vui lòng chọn bàn đặt khác!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else
            {
                if (mnOrderTableItemVM.SubmitOrderTable(Int32.Parse(tbOrderTableId.Text), tbTableId.Text) == 1)
                {
                    MessageBox.Show($"Xác nhận đặt bàn thành công!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainContent.Navigate(new ManageOrderTableView(MainContent));
                }
            }
        }
    }
}
