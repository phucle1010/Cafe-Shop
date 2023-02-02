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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for CustomerProfileView.xaml
    /// </summary>
    public partial class CustomerProfileView : Window
    {
        CustomerProfileViewModel customerProfile = new CustomerProfileViewModel();
        string userName = Properties.Settings.Default.user;
        string selectedFileName;

        public CustomerProfileView()
        {
            InitializeComponent();
            LoadData();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage( IntPtr hWnd, int wMsg, int wParam, int lParam );
        private void btnMaximize_Click( object sender, RoutedEventArgs e )
        {
            if ( this.WindowState == WindowState.Normal )
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

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

        void LoadData()
        {
            KHACHHANG customer = customerProfile.GetCustomerInfo(this.userName);
            txt_Name.Text = customer.TenKH;
            txt_Email.Text = customer.Email;
            txt_Phone.Text = customer.SDT;
            txt_Address.Text = customer.DiaChi;
            txt_CustomerType.Text = customerProfile.GetCustomerType(userName);

            if ( customer.AnhDaiDien != null )
            {
                ImageSource imageSource = new BitmapImage(new Uri(customer.AnhDaiDien));
                ImageViewer.Source = imageSource;
                selectedFileName = customer.AnhDaiDien;
            }
        }

        private void btn_SaveChange_Click( object sender, RoutedEventArgs e )
        {
            string name = txt_Name.Text;
            string email = txt_Email.Text;
            string address = txt_Address.Text;
            string phone = txt_Phone.Text;
            if ( string.IsNullOrEmpty(name) )
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập họ tên!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if ( string.IsNullOrEmpty(email) )
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập email!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if ( string.IsNullOrEmpty(phone) )
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số diện thoại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if ( customerProfile.UpdateProfile(userName, name, phone, address, email, selectedFileName) == 1 )
                {
                    System.Windows.MessageBox.Show("Bạn đã cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
        }

        private void btnAddImage_Click( object sender, RoutedEventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if ( dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                selectedFileName = dlg.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(selectedFileName));
                ImageViewer.Source = imageSource;
            }
        }
    }
}
