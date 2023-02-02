using QL_QuanCafe.Model;
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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Page
    {
        Frame MainContent;
        EmployeeViewModel employeeVM = new EmployeeViewModel();
        CafeShopEntities entity = new CafeShopEntities();
        List<NHANVIEN> employees;
        string type;
        public EmployeeView(Frame MainContent, string type)
        {
            InitializeComponent();
            DataContext = employeeVM;
            this.MainContent = MainContent;
            this.type = type;
            LoadData();
        }
        void LoadData()
        {
            if ( type == "update" )
            {
                string userName = Properties.Settings.Default ["user"].ToString();
                tbUserName.Text = entity.NHANVIENs.Where(employee => employee.MaNV.ToString() == userName).FirstOrDefault().TenNV;

            }
            else
            {
                string userName = Properties.Settings.Default ["user"].ToString();
                AdminViewModel admin = new AdminViewModel();
                tbUserName.Text = admin.getAdminName(userName);
            }
            LoadEmployee();
        }

        private void LoadEmployee()
        {
            if (type == "update")
            {
                employees = entity.NHANVIENs.ToList();
            }
            else
            {
                employees = employeeVM.GetEmployeeList();
            }
            foreach(var employee in employees)
            {
                plEmployee.Children.Add(new EmployeeItemView(MainContent, employee));
            }
        }

        private void btnAddEmplyee_Click( object sender, RoutedEventArgs e )
        {
            AddNewEmployeeView newEmployee = new AddNewEmployeeView(MainContent);
            newEmployee.Show();
            newEmployee.Closed += NewEmployee_Closed;
        }

        private void NewEmployee_Closed( object sender, EventArgs e )
        {
            MainContent.Navigate(new EmployeeView(MainContent, null));
        }
    }
}
