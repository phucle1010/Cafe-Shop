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
    /// Interaction logic for PaymentItemView.xaml
    /// </summary>
    public partial class PaymentItemView : UserControl
    {
        PaymentViewModel paymentVM = new PaymentViewModel();
        Frame MainContent;
        private int billId;
        public PaymentItemView()
        {
            InitializeComponent();
        }

        public PaymentItemView(int orderTableId, string customerName, int total, Page payment, int billId, Frame MainContent)
        {
            InitializeComponent();

            string tableId = paymentVM.GetTableId(orderTableId);
            lbTableName.Content = paymentVM.GetTableName(tableId);
            lbCustomerName.Content = customerName;
            lbTotal.Content = String.Format("{0:C0}", total);
            this.MainContent = MainContent;
            this.billId = billId;
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            int billDetailStatus = 0;
            BillDetailView billDetail = new BillDetailView(billId, MainContent, billDetailStatus, lbCustomerName.Content.ToString());
            billDetail.Show();
        }
    }
}
