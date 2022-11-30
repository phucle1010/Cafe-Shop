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
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    public partial class EmployeeListView : Page
    {
        Frame MainContent;
        EmployeeListViewModel employeeListVM = new EmployeeListViewModel();
        public EmployeeListView()
        {
            InitializeComponent();
        }


        public EmployeeListView(Frame CurrentLayout)
        {
            InitializeComponent();
            this.MainContent = CurrentLayout;
            LoadEmployeeListData();
        }
        void LoadEmployeeListData()
        {
            //MessageBox.Show(employeeListVM.getEmployeeList().Count.ToString());
            employeeList.CanUserDeleteRows = false;
            employeeList.CanUserAddRows = false;
            //employeeList.ColumnWidth = "*";
            List<NHANVIEN> employeeDataList = employeeListVM.getEmployeeList();
            
        }

        private void btnUpdateEmplyee_Click( object sender, RoutedEventArgs e )
        {

        }

        private void btnAddEmplyee_Click( object sender, RoutedEventArgs e )
        {
            MainContent.Content = new AddEmployeeView();
        }
    }
}
