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
        CafeShopEntities entity = new CafeShopEntities();
        FoodViewModel foodVM = new FoodViewModel();
        List<SANPHAM> foods;
        Frame MainContent;
        string type;

        public FoodView(Frame MainContent, string type)
        {
            InitializeComponent();
            this.type = type;
            this.MainContent = MainContent;
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
            LoadFood();
        }

        private void LoadFood()
        {
            if (type == "update")
            {
                foods = entity.SANPHAMs.ToList();
            }
            else
            {
                foods = foodVM.GetAllFood();
            }
            foreach(var food in foods)
            {
                plFoodList.Children.Add(new FoodItemView(MainContent, food));
            }
        }

        private void btnAddFood_Click( object sender, RoutedEventArgs e )
        {
            AddNewFoodView addNewFood = new AddNewFoodView(MainContent);
            addNewFood.Show();
            addNewFood.Closed += AddNewFood_Closed;
        }

        private void AddNewFood_Closed( object sender, EventArgs e )
        {
            MainContent.Navigate(new FoodView(MainContent, null));
        }
    }
}
