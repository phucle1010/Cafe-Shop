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
    /// Interaction logic for FoodItemView.xaml
    /// </summary>
    public partial class FoodItemView : UserControl
    {
        Frame MainContent;
        SANPHAM food;
        public FoodItemView()
        {
            InitializeComponent();
        }
        public FoodItemView(Frame MainContent, SANPHAM food)
        {
            InitializeComponent();
            this.MainContent = MainContent;
            this.food = food;
            LoadUI();
        }

        private void LoadUI()
        {
            tbFoodName.Text = food.TenSP;
            foodImage.Source = new BitmapImage(new Uri(food.HinhAnh));
            tbFoodPrice.Text = String.Format("{0:C0}", food.GiaSP);
        }

        private void btnUpdateFood_Click( object sender, RoutedEventArgs e )
        {
            UpdateFoodView updFood = new UpdateFoodView(food.MaSP, MainContent);
            updFood.Show();
            updFood.Closed += UpdFood_Closed;
        }
        private void btnUpdateTip_Click( object sender, RoutedEventArgs e )
        {
            UpdateFoodDetailView updFoodDetail = new UpdateFoodDetailView(food.MaSP, MainContent);
            updFoodDetail.Show();
            updFoodDetail.Closed += UpdFood_Closed;
        }

        private void UpdFood_Closed( object sender, EventArgs e )
        {
            MainContent.Navigate(new FoodView(MainContent, "update"));
        }

    }
}
