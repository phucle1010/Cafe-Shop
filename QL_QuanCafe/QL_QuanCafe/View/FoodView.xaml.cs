using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for FoodView.xaml
    /// </summary>
    public partial class FoodView : Page
    {
        AdminViewModel customer = new AdminViewModel();
        FoodViewModel foodVM = new FoodViewModel();

        int chosedFoodIndex = -1;
        public FoodView()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = customer.getAdminName(userName);

            DataTable dt = new DataTable();

            DataColumn dc;
            dc = new DataColumn("Mã món ăn");
            dt.Columns.Add(dc);
            dc = new DataColumn("Tên món ăn");
            dt.Columns.Add(dc);
            dc = new DataColumn("Giá món ăn");
            dt.Columns.Add(dc);
            dc = new DataColumn("Trạng thái");
            dt.Columns.Add(dc);


            foodVM.GetAllFood().ForEach(f =>
            {
                if ( Boolean.Parse(f.TrangThai.Value.ToString()) )
                {
                    dt.Rows.Add(f.MaSP, f.TenSP, f.GiaSP, "Còn sẵn");
                }
                else
                {
                    dt.Rows.Add(f.MaSP, f.TenSP, f.GiaSP, "Đã hết");
                }
            });

            dtFood.ItemsSource = dt.DefaultView;

        }

        private void btnAddFood_Click( object sender, RoutedEventArgs e )
        {
            AddNewFoodView addNewFood = new AddNewFoodView();
            addNewFood.Show();
        }

        private void btnUpdateFood_Click( object sender, RoutedEventArgs e )
        {
            if (chosedFoodIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần cập nhật");
            } else
            {
                UpdateFoodView updFood = new UpdateFoodView(chosedFoodIndex);
                updFood.Show();
            }
        }

        private void dtFood_MouseDoubleClick( object sender, MouseButtonEventArgs e )
        {
            foreach ( DataRowView row in dtFood.SelectedItems )
            {
                System.Data.DataRow MyRow = row.Row;
                string id = MyRow ["Mã món ăn"].ToString();
                string foodName = MyRow ["Tên món ăn"].ToString();
                MessageBox.Show($"Bạn vừa chọn món {foodName}");
                chosedFoodIndex = Int32.Parse(id);
            }
        }

        private void btnUpdateFoodDetail_Click( object sender, RoutedEventArgs e )
        {
            if ( chosedFoodIndex == -1 )
            {
                MessageBox.Show("Vui lòng chọn món ăn cần cập nhật");
            }
            else
            {
                UpdateFoodDetailView updFoodDetail = new UpdateFoodDetailView(chosedFoodIndex);
                updFoodDetail.Show();
            }
        }
    }
}
