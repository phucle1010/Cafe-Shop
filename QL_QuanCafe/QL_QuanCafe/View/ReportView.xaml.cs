using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
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
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Diagnostics;
using LiveCharts.Helpers;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Page
    {
        public SeriesCollection SaleCollection { get; set; }
        public string [] SaleLabels { get; set; }
        public Func<double, string> SaleFormatter { get; set; }
        public SeriesCollection FoodTrendCollection { get; set; }
        public string [] FoodTrendLabels { get; set; }
        public Func<double, string> FoodTrendFormatter { get; set; }
        public SeriesCollection ImportMaterialCollection { get; set; }
        public string [] ImportMaterialLabels { get; set; }
        public Func<double, string> ImportMaterialFormatter { get; set; }
        ReportViewModel reportVM = new ReportViewModel();
        public ReportView()
        {
            InitializeComponent();
            LoadData();
            LoadSaleChart();
            LoadFoodTrendChart();
            LoadImportMaterialChart();
            DataContext = this;
        }

        private void LoadData()
        {
            AdminViewModel admin = new AdminViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = admin.getAdminName(userName);
        }

        private void LoadSaleChart()
        {
            SaleCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = new ChartValues<double> { 10, 50, 39, 50, 32, 35, 51, 64, 42, 27, 50, 48 }
                },
                new ColumnSeries
                {
                    Title = "Tiền lãi",
                    Values = new ChartValues<double> { 11, 56, 42, 48, 22, 29, 41, 34, 36, 21, 44, 40 }
                }
            };
            //adding series will update and animate the chart automatically

            var months = new List<string>();
            for(int i = 1; i <= 12; i++)
            {
                months.Add(i.ToString());
            }

            //Labels = new string [] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            SaleLabels = months.Select(x => x.ToString()).ToArray();
            SaleFormatter = value => String.Format("{0:C0}", value);
        }

        private void LoadFoodTrendChart()
        {
            List<int> quantityOfEachTrendFoods = reportVM.GetTopTrendProductQuantity();
            FoodTrendLabels = reportVM.GetTopTrendProductName().Select(x => x.ToString()).ToArray();
            FoodTrendFormatter = value => value.ToString();

            FoodTrendCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Số lượng",
                }
            };

            FoodTrendCollection [0].Values = quantityOfEachTrendFoods.ToArray().AsChartValues<int>();

        }
        private void LoadImportMaterialChart()
        {
            List<string> listOfMaterialNames = reportVM.GetAllMaterialNeetToImport();
            ImportMaterialLabels = listOfMaterialNames.Select(x => x).ToArray(); 
            ImportMaterialFormatter = value => value.ToString();

            List<double> quantityOfMaterials = new List<double>();
            foreach(var item in listOfMaterialNames)
            {
                quantityOfMaterials.Add(reportVM.GetQuantityOfMaterial(item));
            }

            ImportMaterialCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Số lượng còn lại",
                }
            };
            ImportMaterialCollection [0].Values = quantityOfMaterials.ToArray().AsChartValues<double>();

        }
    }
}
