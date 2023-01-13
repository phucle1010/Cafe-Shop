using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
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
    /// Interaction logic for BillDetailItemView.xaml
    /// </summary>
    public partial class BillDetailItemView : UserControl
    {
        private CT_HOADON billDetail;
        BillDetailItemViewModel billDetailItemVM = new BillDetailItemViewModel();
        public BillDetailItemView()
        {
            InitializeComponent();
        }

        public BillDetailItemView(CT_HOADON billDetail )
        {
            InitializeComponent();
            this.billDetail = billDetail;
            LoadData();
        }

        void LoadData()
        {
            lbFoodId.Content = billDetail.MaSP;
            lbFoodName.Content = billDetailItemVM.GetFoodInfo((int) billDetail.MaSP).TenSP;
            lbQuantity.Content = billDetail.SoLuong;
            int price = (int) billDetailItemVM.GetFoodInfo((int) billDetail.MaSP).GiaSP;
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            lbTotal.Content = double.Parse((price * billDetail.SoLuong).ToString()).ToString("#,###", cul.NumberFormat); 
        }
    }
}
