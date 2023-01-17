using QL_QuanCafe.LocalStore;
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
    /// Interaction logic for MainView_Customer.xaml
    /// </summary>
    public partial class MainView_Customer : Window
    {
        public MainView_Customer()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            CustomerViewModel customer = new CustomerViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            MainContent.Navigate( new HomeCustomerView() );
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnSignOut_Click( object sender, RoutedEventArgs e )
        {
            LoginViewModel login = new LoginViewModel();
            login.removeUserIsUsing();
            MessageBox.Show("Đăng xuất thành công!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            LoginView loginLayout = new LoginView();
            this.Visibility = Visibility.Hidden;
            loginLayout.Show();
        }

        private void btnPersonal_Click( object sender, RoutedEventArgs e )
        {
            MainContent.Navigate( new HomeCustomerView() );
        }

        private void btnHotFood_Click( object sender, RoutedEventArgs e )
        {
            MainContent.Navigate( new HotFoodView(MainContent) );
        }

        private void btnOrderTable_Click( object sender, RoutedEventArgs e )
        {
            MainContent.Navigate( new OrderTableView() );
        }

        private void btnOrderFood_Click( object sender, RoutedEventArgs e )
        {
            MainContent.Navigate( new OrderFoodView() );
        }

        private void btnAccPoint_Click( object sender, RoutedEventArgs e )
        {
            MainContent.Navigate( new AccumlatorPointView() );
        }

        private void btnRespone_Click( object sender, RoutedEventArgs e )
        {
            MainContent.Navigate( new ResponseView() );
        }

        private void btnSecurity_Click( object sender, RoutedEventArgs e )
        {
            SecurityView security = new SecurityView();
            security.Show();
        }

        private void btnRestart_Click( object sender, RoutedEventArgs e )
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
