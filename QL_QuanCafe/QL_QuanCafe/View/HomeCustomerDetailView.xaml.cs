using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
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
    /// Interaction logic for HomeCustomerDetailView.xaml
    /// </summary>
    public partial class HomeCustomerDetailView : Page
    {
        CustomerViewModel customerVM = new CustomerViewModel();
        public string [] FoodTitles { get; set; }
        public int [] Values { get; set; }
        int customerId;

        public HomeCustomerDetailView()
        {
            InitializeComponent();
            customerId = customerVM.getCustomerId(Properties.Settings.Default ["user"].ToString());
            LoadUIData();
            LoadFavoriteFood();
            DataContext = this;
        }

        private void LoadUIData()
        {
            tbOrderedQuantity.Text = customerVM.GetOrderedQuantityOfCustomer(customerId).ToString();
        }

        private void LoadFavoriteFood()
        {
            FoodTitles = customerVM.GetAllNameByFood(customerId).Select(x => x).ToArray();
            Values = customerVM.GetAllQuantityByFood(customerId).Select(x => x).ToArray();

            firstFoodSeries.Title = FoodTitles [0];
            firstFoodSeries.Values = new ChartValues<int> { Values [0] };

            secondFoodSeries.Title = FoodTitles [1];
            secondFoodSeries.Values = new ChartValues<int> { Values [1] };

            thirdFoodSeries.Title = FoodTitles [2];
            thirdFoodSeries.Values = new ChartValues<int> { Values [2] };
        }

        private void Chart_OnDataClick( object sender, ChartPoint chartpoint )
        {
            var chart = (LiveCharts.Wpf.PieChart) chartpoint.ChartView;

            //clear selected slice.
            foreach ( PieSeries series in chart.Series )
                series.PushOut = 0;

            var selectedSeries = (PieSeries) chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
