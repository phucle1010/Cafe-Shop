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
    /// Interaction logic for OrderFoodHistoryItemInHomeView.xaml
    /// </summary>
    public partial class OrderFoodHistoryItemInHomeView : UserControl
    {
        private DateTime orderDate;
        private int total;
        public OrderFoodHistoryItemInHomeView(DateTime orderDate, int total)
        {
            InitializeComponent();
            this.orderDate = orderDate;
            this.total = total;
            LoadData();
        }

        private void LoadData()
        {
            tbDate.Text = $"{orderDate.Day}/{orderDate.Month}/{orderDate.Year}";
            tbTotal.Text = String.Format("{0:C0}", total);
        }
    }
}
