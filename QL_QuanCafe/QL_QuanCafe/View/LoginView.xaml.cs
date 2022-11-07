using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click( object sender, RoutedEventArgs e )
        {
            string userText = txtUser.Text;
            string passText = txtPass.Password.ToString();
            if ( userText == "annoy" && passText == "123456" )
            {
                MessageBox.Show("Đăng nhập thành công với quyền khách hàng");
                MainView_Customer customerLayout = new MainView_Customer();
                this.Visibility = Visibility.Hidden;
                customerLayout.Show();
            } 
            else if ( userText == "admin" && passText == "123456" )
            {
                MessageBox.Show("Đăng nhập thành công với quyền quản trị viên");
                MainView_Admin adminLayout = new MainView_Admin();
                this.Visibility = Visibility.Hidden;
                adminLayout.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản không đúng");
            }
        }
    }
}
