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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for AddStaffView.xaml
    /// </summary>
    public partial class AddStaffView : Page
    {
        public AddStaffView()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            int sex = getSex();
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string phone = txtPhonenumber.Text;
            string salary =txtSalary.Text;
            string position = cbPosition.Text;
            string datework = DPdatework.Text;
            string pass = txtPass.Password.ToString();
            if(IsNullData(name,sex.ToString(),address,email,phone,salary,position,datework,pass))
            {
                MessageBox.Show("Nhập không đủ thông tin. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else  if(!isNumber(salary))
            {
                MessageBox.Show("Lương phải là kiểu số . Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if(!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                RegisterViewModel register = new RegisterViewModel();
                register.UpdateDataStaff(name, pass, phone, email, address, float.Parse(salary), position, datework, sex);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                txtName.Clear();
                txtAddress.Clear();
                txtEmail.Clear();
                txtPhonenumber.Clear();
                txtSalary.Clear();
                txtPass.Clear();
            }



        }
        public int getSex()
        {
            int sex = 0;
            if(rdNu.IsChecked== true) { sex = 1; }
            return sex;
        }
        bool IsNullData(string name, string sex, string address, string email, string phone, string salary, string position,string datework,string pass)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sex) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(salary) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(datework) || string.IsNullOrEmpty(pass))
                return true;
            return false;
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
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
        public bool isNumber(string str)
        {
            foreach(Char c in str)
            {
                if(!Char.IsDigit(c)) return false;
            }
            return true;
        }

    }
}
