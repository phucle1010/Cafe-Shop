using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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
        int chosedFoodIndex = -1;

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
            DataTable dt = new DataTable();

            DataColumn dc;
            dc = new DataColumn("Mã nhân viên");
            dt.Columns.Add(dc);
            dc = new DataColumn("Tên nhân viên");
            dt.Columns.Add(dc);
            dc = new DataColumn("Số điện thoại");
            dt.Columns.Add(dc);
            dc = new DataColumn("Email");
            dt.Columns.Add(dc);
            dc = new DataColumn("Địa chỉ");
            dt.Columns.Add(dc);
            dc = new DataColumn("Ngày vào làm");
            dt.Columns.Add(dc);
            dc = new DataColumn("Mã ca làm");
            dt.Columns.Add(dc);

            foreach ( var item in employeeListVM.getEmployeeList() )
            {
                dt.Rows.Add(item.MaNV, item.TenNV, item.SDT, item.Email, item.DiaChi, item.NgayVaoLam, item.MaCaLV);
            }

            dtEmployee.ItemsSource = dt.DefaultView;
        }

        private void btnUpdateEmplyee_Click( object sender, RoutedEventArgs e )
        {
            if ( chosedFoodIndex == -1 )
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật");
            }
            else
            {
                UpdateEmployeeView updEmployee = new UpdateEmployeeView(chosedFoodIndex);
                updEmployee.Show();
            }
        }

        private void btnAddEmplyee_Click( object sender, RoutedEventArgs e )
        {
            AddNewEmployeeView newEmployee = new AddNewEmployeeView();
            newEmployee.Show();
        }

        private void dtEmployee_MouseDoubleClick( object sender, MouseButtonEventArgs e )
        {
            foreach ( DataRowView row in dtEmployee.SelectedItems )
            {
                System.Data.DataRow MyRow = row.Row;
                string id = MyRow ["Mã nhân viên"].ToString();
                string foodName = MyRow ["Tên nhân viên"].ToString();
                MessageBox.Show($"Bạn vừa chọn nhân viên {foodName}");
                chosedFoodIndex = Int32.Parse(id);
            }
        }

        private void btnUpdateWorkShift_Click( object sender, RoutedEventArgs e )
        {
            if ( chosedFoodIndex == -1 )
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa đổi");
            }
            else
            {
                ChangeWorkShiftView workShift = new ChangeWorkShiftView(chosedFoodIndex);
                workShift.Show();
            }
        }
    }
}
