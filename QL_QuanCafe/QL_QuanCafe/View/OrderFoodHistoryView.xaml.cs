using QL_QuanCafe.Model;
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
    /// Interaction logic for OrderFoodHistoryView.xaml
    /// </summary>
    public partial class OrderFoodHistoryView : Window
    {
        OrderTableViewModel orderTableVM = new OrderTableViewModel();
        int customerId;
        List<DATBAN> orderTableList;
        public OrderFoodHistoryView()
        {
            InitializeComponent();
            LoadOrderFoodData();
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

        private void LoadOrderFoodData()
        {
            customerId = Int32.Parse(orderTableVM.GetCustomerId(Properties.Settings.Default ["user"].ToString()));
            orderTableList = orderTableVM.GetAllOrderTableDataOfUser(customerId);
            foreach ( var item in orderTableList )
            {
                plOrderTableList.Children.Add(new OrderFoodHistoryItemView(item));
            }
        }
    }
}
