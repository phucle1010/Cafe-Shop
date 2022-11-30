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
using QL_QuanCafe.ViewModel;
using QL_QuanCafe.LocalStore;
using System.Net;
using QL_QuanCafe.Model;

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
            HanleInitData();
        }
        void HanleInitData()
        {
            LoginViewModel login = new LoginViewModel();
            if ( login.haveUserIsUsing() )
            {
                switch ( login.isAdmin() )
                {
                    case false:
                        Properties.Settings.Default ["user"] = login.getUserNameOfUser();
                        Properties.Settings.Default ["role"] = 0;
                        Properties.Settings.Default.Save();
                        MainView_Customer customerLayout = new MainView_Customer();
                        this.Hide();
                        customerLayout.Show();
                        break;
                    case true:
                        Properties.Settings.Default ["user"] = login.getUserNameOfUser();
                        Properties.Settings.Default ["role"] = 1;
                        Properties.Settings.Default.Save();
                        MainView_Admin adminLayout = new MainView_Admin();
                        this.Hide();
                        adminLayout.Show();
                        break;
                    default:
                        break;

                }
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void SaveAccount(string user, int role)
        {
            LoginViewModel login = new LoginViewModel();
            login.insertUserIsUsing(user, role);
            MessageBox.Show("Đăng nhập thành công!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            Properties.Settings.Default ["user"] = user;
            Properties.Settings.Default ["role"] = role;
            Properties.Settings.Default.Save();
        }

        
        private void btnLogin_Click( object sender, RoutedEventArgs e )
        {
            string user = txtUser.Text;
            string pass = txtPass.Password.ToString();
            if ( String.IsNullOrEmpty(user) || String.IsNullOrEmpty(pass) )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                CustomerViewModel customer = new CustomerViewModel();
                AdminViewModel admin = new AdminViewModel();
                if ( customer.isLoginWithCustomerRole(user, pass) )
                {
                    SaveAccount(user, 0);
                    MainView_Customer customerLayout = new MainView_Customer();
                    this.Hide();
                    customerLayout.Show();
                } else if ( admin.isLoginWithAdminRole(user, pass) )
                {

                    SaveAccount(user, 1);
                    MainView_Admin adminLayout = new MainView_Admin();
                    this.Hide();
                    adminLayout.Show();
                }
                else
                {
                    MessageBox.Show("Thông tin nhập không chính xác!!!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void tbCreateNewAccount_PreviewMouseDown( object sender, MouseButtonEventArgs e )
        {
            RegisterAccountView registerLayout = new RegisterAccountView();
            this.Visibility = Visibility.Hidden;
            registerLayout.Show();
        }

        private void tbForgotPassword_PreviewMouseDown( object sender, MouseButtonEventArgs e )
        {
            ForgotPasswordView forgotPassLayout = new ForgotPasswordView();
            this.Visibility = Visibility.Hidden;
            forgotPassLayout.Show();
        }
    }
}
