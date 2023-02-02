﻿using QL_QuanCafe.ViewModel;
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
    /// Interaction logic for AddNewEmployeeView.xaml
    /// </summary>
    public partial class AddNewEmployeeView : Window
    {
        Frame MainContent;
        public AddNewEmployeeView()
        {
            InitializeComponent();
        }

        public AddNewEmployeeView(Frame MainContent)
        {
            InitializeComponent();
            this.MainContent = MainContent;
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

        private void btnAdd_Click( object sender, RoutedEventArgs e )
        {
            string name = txtName.Text;
            int sex = getSex();
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string phone = txtPhonenumber.Text;
            string workShiftName = cbWorkShift.Text;
            string position = (cbPosition.SelectedIndex + 1).ToString();
            if ( IsNullData(name, sex.ToString(), address, email, phone, workShiftName, position) )
            {
                MessageBox.Show("Nhập không đủ thông tin. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if ( !IsValidEmail(email) )
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                RegisterAccountViewModel register = new RegisterAccountViewModel();
                if ( register.InsertEmployeeData(name, phone, email, address, workShiftName, position, sex) == 1 )
                {
                    txtName.Clear();
                    txtAddress.Clear();
                    txtEmail.Clear();
                    txtPhonenumber.Clear();
                    this.Close();
                    MainContent.Navigate(new EmployeeView(MainContent, null));
                }
                
            }
        }
        public int getSex()
        {
            int sex = 0;
            if ( rdNu.IsChecked == true ) { sex = 1; }
            return sex;
        }
        bool IsNullData( string name, string sex, string address, string email, string phone, string workShift, string position )
        {
            if ( string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sex) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(workShift) || string.IsNullOrEmpty(position) )
                return true;
            return false;
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
        public bool isNumber( string str )
        {
            foreach ( Char c in str )
            {
                if ( !Char.IsDigit(c) ) return false;
            }
            return true;
        }
    }
}
