using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for AccumlatorPointItemView.xaml
    /// </summary>
    public partial class AccumlatorPointItemView : UserControl
    {
        private int customerId;
        CustomerViewModel customerVM = new CustomerViewModel();
        Frame MainContent;
        public AccumlatorPointItemView()
        {
            InitializeComponent();
        }

        public AccumlatorPointItemView(SANPHAM food, int currentPointOfCustomer, int customerId, Frame MainContent)
        {
            InitializeComponent();
            this.MainContent = MainContent;
            tbFoodName.Text = food.TenSP;
            igFoodImage.Source = new BitmapImage(new Uri(food.HinhAnh));
            tbNeededPoints.Text = food.DiemTichLuy.ToString();
            tbAvailableQuantity.Text = currentPointOfCustomer >= food.DiemTichLuy ? (currentPointOfCustomer / food.DiemTichLuy).ToString() : "0";
            if (Int32.Parse(tbAvailableQuantity.Text) == 0)
            {
                SolidColorBrush disableButton = new SolidColorBrush();
                disableButton = (SolidColorBrush) (new BrushConverter().ConvertFrom("#40826D"));
                btnExchange.Background = disableButton;
            }
            this.customerId = customerId;
        }

        private void btnExchange_Click( object sender, RoutedEventArgs e )
        {
            if ( Int32.Parse(tbAvailableQuantity.Text) == 0 )
            {
                MessageBox.Show("Bạn không đủ điểm để đổi món ăn này");
            }
            else
            {
                if (customerVM.ExchangePoints(customerId, Int32.Parse(tbNeededPoints.Text)) == 1)
                {
                    MessageBox.Show("Đổi điểm thành công!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainContent.Navigate(new AccumlatorPointView(MainContent));
                }
            } 
                
        }
    }
}
