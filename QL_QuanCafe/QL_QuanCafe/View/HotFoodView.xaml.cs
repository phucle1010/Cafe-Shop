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
    /// Interaction logic for HotFoodView.xaml
    /// </summary>
    public partial class HotFoodView : Page
    {
        List<string> Image = new List<string>();
        List<string> FoodName = new List<string>();
        List<int> Price = new List<int>();
        List<int> Quantity = new List<int>();
        HotFoodViewModel hotFoodVM = new HotFoodViewModel();
        Frame MainContent;

        public HotFoodView()
        {
            InitializeComponent();
            LoadData();
            LoadUIData();
        }

        public HotFoodView(Frame Content)
        {
            InitializeComponent();
            this.MainContent = Content;
            LoadData();
            LoadUIData();
        }

        private void LoadData()
        {
            CustomerViewModel customer = new CustomerViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = customer.getCustomerName(userName);

            Image = hotFoodVM.GetAllImageByFood();
            FoodName = hotFoodVM.GetAllNameByFood();
            Price = hotFoodVM.GetAllPriceByFood();
            Quantity = hotFoodVM.GetAllQuantityByFood();
        }

        private void LoadUIData()
        {
            LoadImage();
            LoadFoodName();
            LoadPrice();
            LoadQuantity();
        }

        private void LoadImage()
        {
            top1Image.Source = new BitmapImage(new Uri(Image [0]));
            top2Image.Source = new BitmapImage(new Uri(Image [1]));
            top3Image.Source = new BitmapImage(new Uri(Image [2]));
            top4Image.Source = new BitmapImage(new Uri(Image [3]));
        }

        private void LoadFoodName()
        {
            top1Name.Text = FoodName [0];
            top2Name.Text = FoodName [1];
            top3Name.Text = FoodName [2];
            top4Name.Text = FoodName [3];
        }

        private void LoadPrice()
        {
            top1Price.Text = String.Format("{0:C0}", Price [0]);
            top2Price.Text = String.Format("{0:C0}", Price [1]);
            top3Price.Text = String.Format("{0:C0}", Price [2]);
            top4Price.Text = String.Format("{0:C0}", Price [3]);
        }

        private void LoadQuantity()
        {
            top1Quantity.Text = Quantity [0].ToString();
            top2Quantity.Text = Quantity [1].ToString();
            top3Quantity.Text = Quantity [2].ToString();
            top4Quantity.Text = Quantity [3].ToString();

        }

        private void btnView_Click( object sender, RoutedEventArgs e )
        {
            MainContent.Navigate(new OrderFoodView(MainContent));
        }

    }
}
