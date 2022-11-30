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
    /// Interaction logic for FoodView.xaml
    /// </summary>
    public partial class FoodView : Page
    {
        public FoodView()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            AdminViewModel customer = new AdminViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = customer.getAdminName(userName);
        }

        private void btnAddFood_Click( object sender, RoutedEventArgs e )
        {
            AddNewFoodView addNewFood = new AddNewFoodView();
            addNewFood.Show();
        }

        private void btnUpdateFood_Click( object sender, RoutedEventArgs e )
        {

        }
    }
}
