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
using LiveCharts;
using LiveCharts.Wpf;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for HomeAdminDetailView.xaml
    /// </summary>
    public partial class HomeAdminDetailView : Page
    {
        HomeAdminViewModel home = new HomeAdminViewModel();
        public HomeAdminDetailView()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            txtEmployees.Text = home.getTheNumberOfEmployee().ToString();
            txtCustomers.Text = home.getTheNumberOfCustomer().ToString();

            standardSeries.Values = new ChartValues<int> { Int32.Parse(home.getTheNumberOfStandardCustomer().ToString()) };
            loyalSeries.Values = new ChartValues<int> { Int32.Parse(home.getTheNumberOfLoyalCustomer().ToString()) };
            vipstandardSeries.Values = new ChartValues<int> { Int32.Parse(home.getTheNumberOfVIPCustomer().ToString()) };

            dpToday.Text = DateTime.Now.ToString();
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
