using System;
using System.Collections.Generic;
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
    /// Interaction logic for PaymentCompletedView.xaml
    /// </summary>
    public partial class PaymentCompletedView : UserControl
    {
        Page payment;
        public PaymentCompletedView()
        {
            InitializeComponent();
        }

        public PaymentCompletedView( int billId, string customerName, int total , Page payment )
        {
            InitializeComponent();
            lbBillId.Content = billId.ToString();
            lbCustomerName.Content = customerName;
            lbTotal.Content = String.Format("{0:C0}", total);
            this.payment = payment;
        }

        private void btnViewDetail_Click( object sender, RoutedEventArgs e )
        {
            int billId = Int32.Parse(lbBillId.Content.ToString());
            int billDetailStatus = 1;
            BillDetailView billDetail = new BillDetailView(billId, payment, billDetailStatus, lbCustomerName.Content.ToString());
            billDetail.Show();  
        }
    }
}
