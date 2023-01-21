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
    /// Interaction logic for UpdateEmployeeView.xaml
    /// </summary>
    public partial class UpdateEmployeeView : Window
    {
        UpdateEmployeeViewModel updEmployeeVM = new UpdateEmployeeViewModel();
        int employeeId;
        Frame MainContent;
        public UpdateEmployeeView()
        {
            InitializeComponent();
        }

        public UpdateEmployeeView(int employeeId, Frame mainContent )
        {
            InitializeComponent();
            this.employeeId = employeeId;
            LoadData();
            MainContent = mainContent;
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

        public void LoadData()
        {
            MessageBox.Show(this.employeeId.ToString());
            tbEmployeeId.Text = this.employeeId.ToString();

            NHANVIEN v = updEmployeeVM.GetEmployeeData(this.employeeId);
            tbName.Text = v.TenNV.ToString();
            tbPhonenumber.Text = v.SDT.ToString();
            tbEmail.Text = v.Email.ToString();
            tbAddress.Text = v.DiaChi.ToString();
            cbPosition.Text = v.ChucVu.ToString() == "1" ? "Quản lý" : "Nhân viên";
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

        private void btnUpdate_Click( object sender, RoutedEventArgs e )
        {
            if ( String.IsNullOrEmpty(tbName.Text) || String.IsNullOrEmpty(tbAddress.Text) || String.IsNullOrEmpty(tbEmail.Text) || String.IsNullOrEmpty(tbPhonenumber.Text) || cbPosition.Text == "")
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin nhân viên", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            } 
            else
            {
                if (!IsValidEmail(tbEmail.Text))
                {
                    MessageBox.Show("Vui lòng kiểm tra lại Email", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                } 
                else
                {
                    if (cbPosition.Text == "Quản lý")
                    {
                        if (updEmployeeVM.UpdateEmployeeData(this.employeeId, tbName.Text, tbPhonenumber.Text, tbEmail.Text, tbAddress.Text, "1") == 1)
                        {
                            this.Close();
                            MainContent.Navigate(new EmployeeView());
                        }
                    } else
                    {
                        if ( updEmployeeVM.UpdateEmployeeData(this.employeeId, tbName.Text, tbPhonenumber.Text, tbEmail.Text, tbAddress.Text, "0") == 1 )
                        {
                            this.Close();
                            MainContent.Navigate(new EmployeeView(MainContent));
                        }
                    }
                }
            }
        }
    }
}
