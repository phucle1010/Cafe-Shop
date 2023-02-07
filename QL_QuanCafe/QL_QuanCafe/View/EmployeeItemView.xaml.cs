using QL_QuanCafe.Model;
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
    /// Interaction logic for EmployeeItemView.xaml
    /// </summary>
    public partial class EmployeeItemView : UserControl
    {
        Frame MainContent;
        NHANVIEN employee;

        public EmployeeItemView(Frame MainContent, NHANVIEN employee)
        {
            InitializeComponent();
            this.MainContent = MainContent;
            this.employee = employee;
            LoadData();
        }

        private void LoadData()
        {
            LoadAvatar();
            tbEmployeeName.Text = employee.TenNV;
            tbAddress.Text = employee.DiaChi;
            tbPhone.Text = employee.SDT;
            tbEntryDate.Text = employee.NgayVaoLam.Value.ToString("dd/MM/yyyy");
        }

        private void LoadAvatar()
        {
            if ( employee.AnhDaiDien != null )
            {
                ImageViewer.Source = new BitmapImage(new Uri(employee.AnhDaiDien));
            }
            else
            {
                if ( (bool) employee.GioiTinh )
                {
                    ImageViewer.Source = new BitmapImage(new Uri("E:\\Projects\\Công nghệ phần mềm chuyên sâu\\Cafe-Shop\\QL_QuanCafe\\QL_QuanCafe\\Image\\user-male.png"));
                }
                else
                {
                    ImageViewer.Source = new BitmapImage(new Uri("E:\\Projects\\Công nghệ phần mềm chuyên sâu\\Cafe-Shop\\QL_QuanCafe\\QL_QuanCafe\\Image\\user-female.png"));
                }
            }
        }

        private void btnChangeShift_Click( object sender, RoutedEventArgs e )
        {
            ChangeWorkShiftView workShift = new ChangeWorkShiftView(employee, MainContent);
            workShift.Show();
            workShift.Closed += WorkShift_Closed;
        }
        private void btnUpdate_Click( object sender, RoutedEventArgs e )
        {
            UpdateEmployeeView updEmployee = new UpdateEmployeeView(employee, MainContent);
            updEmployee.Show();
            updEmployee.Closed += UpdEmployee_Closed;
        }

        private void UpdEmployee_Closed( object sender, EventArgs e )
        {
            MainContent.Navigate(new EmployeeView(MainContent, "update"));
        }

        private void WorkShift_Closed( object sender, EventArgs e )
        {
            MainContent.Navigate(new EmployeeView(MainContent, "update"));    
        }

    }
}
