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
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView : Page
    {
        PaymentViewModel paymentVM = new PaymentViewModel();
        CafeShopEntities entity = new CafeShopEntities();
        Frame MainContent;
        string type;
        public PaymentView(Frame MainContent, string type)
        {
            InitializeComponent();
            this.MainContent = MainContent;
            this.type = type;
            LoadData();
            LoadPaymentUnCompleteItem();
            LoadPaymentCompleteItem();
        }
        void LoadData()
        {
            AdminViewModel admin = new AdminViewModel();
            string userName = Properties.Settings.Default.user;
            tbUserName.Text = admin.getAdminName(userName);          
        }

        void LoadPaymentUnCompleteItem()
        {
            List<HOADON> unPayedBillList;
            if (type == "update")
            {
                unPayedBillList = entity.HOADONs.Where(bill => bill.TrangThaiThanhToan == false).ToList();
            }
            else
            {
                unPayedBillList = paymentVM.billListNotPayments();
            }
            foreach(var item in unPayedBillList)
            {
                PaymentItemView paymentItem = new PaymentItemView((int) item.MaDatBan, paymentVM.GetCustomerName((int) item.MaKH), (int) item.TongTien, this, (int) item.MaHD, MainContent);
                unPayedList.Children.Add(paymentItem);
            }
        }
        void LoadPaymentCompleteItem()
        {
            List<HOADON> payedBillList; 
            if ( type == "update" )
            {
                payedBillList = entity.HOADONs.Where(bill => bill.TrangThaiThanhToan == true).ToList();
            }
            else
            {
                payedBillList = paymentVM.billListHasPayments();
            }
            foreach ( var item in payedBillList )
            {
                PaymentCompletedView paymentItem = new PaymentCompletedView((int) item.MaHD, paymentVM.GetCustomerName((int) item.MaKH), (int) item.TongTien, MainContent);
                PayedList.Children.Add(paymentItem);
            }
        }
    }
}
