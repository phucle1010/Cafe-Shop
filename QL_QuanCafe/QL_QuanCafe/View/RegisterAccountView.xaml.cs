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
    /// Interaction logic for RegisterAccountView.xaml
    /// </summary>
    public partial class RegisterAccountView : Window
    {
        public RegisterAccountView()
        {
            InitializeComponent();
        }

        private void btnClose_Click( object sender, RoutedEventArgs e )
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click( object sender, RoutedEventArgs e )
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown( object sender, MouseButtonEventArgs e )
        {
            if ( e.LeftButton == MouseButtonState.Pressed )
                DragMove();
        }

        private void btnRegister_Click( object sender, RoutedEventArgs e )
        {
            string fullname = txtName.Text;
            string user = txtUser.Text;
            string pass = txtPass.Password.ToString();
            string repass = txtRepass.Password.ToString();
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string phone = txtPhonenumber.Text;

            RegisterAccountViewModel registerViewModel = new RegisterAccountViewModel();

            if ( IsNullData(fullname, user, pass, repass, address, email, phone) )
            {
                MessageBox.Show("Nhập không đủ thông tin. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if ( !SubmitPassCorrect(pass, repass) )
                    MessageBox.Show("Mật khẩu xác nhận không chính xác. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    if ( !IsValidEmail(email) )
                    {
                        MessageBox.Show("Email không chính xác. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if ( phone.Length < 10 )
                    {
                        System.Windows.MessageBox.Show("Thông tin 'Số điện thoại' không chính xác. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if ( registerViewModel.IsExistedUsername(user) )
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng sử dụng tên đăng nhập khác.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        registerViewModel.InsertCustomerData(fullname, "0", phone, email, address, 1, user, pass);
                        MessageBox.Show("Đăng ký thành công !!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtName.Clear();
                        txtUser.Clear();
                        txtPass.Clear();
                        txtRepass.Clear();
                        txtAddress.Clear();
                        txtPhonenumber.Clear();
                        LoginView loginLayout = new LoginView();
                        this.Visibility = Visibility.Hidden;
                        loginLayout.Show();
                    }
                }
            }
        }

        bool IsNullData( string Name, string Username, string Pass, string Repass, string Address, string Email, string Phone )
        {
            if ( string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Pass) || string.IsNullOrEmpty(Repass) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Phone) )
                return true;
            return false;
        }

        bool SubmitPassCorrect( string pass, string repass )
        {
            return repass == pass;
        }

        bool IsValidEmail( string email )
        {
            var trimmedEmail = email.Trim();

            if ( trimmedEmail.EndsWith(".") )
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
