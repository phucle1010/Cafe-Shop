using QL_QuanCafe.LocalStore;
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
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for CreateNewPasswordView.xaml
    /// </summary>
    public partial class CreateNewPasswordView : Window
    {
        public CreateNewPasswordView()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click( object sender, RoutedEventArgs e )
        {
            WindowState = WindowState.Maximized;
        }

        private void btnClose_Click( object sender, RoutedEventArgs e )
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown( object sender, MouseButtonEventArgs e )
        {
            if ( e.LeftButton == MouseButtonState.Pressed )
                DragMove();
        }

        private void btnCancel_Click( object sender, RoutedEventArgs e )
        {
            Application.Current.Shutdown();
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            EmailResetPassword.Instance.SetEmail("nguyen@gmail.com");
            string pass = txt_Pass.Text.ToString();
            string email = EmailResetPassword.Instance.GetEmail();
            if ( pass.Length >= 6 )
            {
                CreateNewPasswordViewModel newPass = new CreateNewPasswordViewModel();
                newPass.UpdatePassword(pass, email);
                LoginView loginLayout = new LoginView();
                this.Visibility = Visibility.Hidden;
                loginLayout.Show();
            }
            else
            {
                MessageBox.Show("Mật khẩu phải dài hơn hoặc bằng 6 ký tự!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
