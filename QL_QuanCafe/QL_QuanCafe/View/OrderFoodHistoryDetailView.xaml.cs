using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for OrderFoodHistoryDetailView.xaml
    /// </summary>
    public partial class OrderFoodHistoryDetailView : Window
    {
        OrderFoodViewModel orderFoodVM = new OrderFoodViewModel();
        private int orderTableId;
        public OrderFoodHistoryDetailView()
        {
            InitializeComponent();
        }

        public OrderFoodHistoryDetailView(int orderTableId)
        {
            InitializeComponent();
            this.orderTableId = orderTableId;
            LoadUIData();
        }  


        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage( IntPtr hWnd, int wMsg, int wParam, int lParam );

        private void btnMinimize_Click( object sender, RoutedEventArgs e )
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click( object sender, RoutedEventArgs e )
        {
            this.Close();
        }

        private void pnlControlBar_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter( object sender, System.Windows.Input.MouseEventArgs e )
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void LoadUIData()
        {
            foreach(var item in orderFoodVM.GetOrderDetailOfCustomer(orderTableId))
            {
                plFoodDetail.Children.Add(new OrderFoodHistoryDetailItemView(item));
            }
        }
    }
}
