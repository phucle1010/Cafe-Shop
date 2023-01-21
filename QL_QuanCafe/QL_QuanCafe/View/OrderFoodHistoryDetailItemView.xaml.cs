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
    /// Interaction logic for OrderFoodHistoryDetailItemView.xaml
    /// </summary>
    public partial class OrderFoodHistoryDetailItemView : UserControl
    {
        CT_HOADON billDetail;
        OrderFoodViewModel orderFoodVM = new OrderFoodViewModel();
        public OrderFoodHistoryDetailItemView()
        {
            InitializeComponent();
        }

        public OrderFoodHistoryDetailItemView(CT_HOADON billDetail)
        {
            InitializeComponent();
            this.billDetail = billDetail;
            LoadUI();
        }

        private void LoadUI()
        {
            tbFoodName.Text = orderFoodVM.GetFoodName((int) billDetail.MaSP);
            tbQuantity.Text = billDetail.SoLuong.ToString();
            tbFoodPrice.Text = String.Format("{0:C0}", orderFoodVM.GetFoodPrice((int) billDetail.MaSP)); 
        }
    }
}
