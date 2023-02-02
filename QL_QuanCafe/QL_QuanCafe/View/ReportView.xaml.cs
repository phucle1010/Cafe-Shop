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
using QL_QuanCafe.Model;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Page
    {
        ReportViewModel reportVM = new ReportViewModel();
        public SeriesCollection SaleCollection { get; set; }
        public string [] SaleLabels { get; set; }
        public Func<double, string> SaleFormatter { get; set; }
        public SeriesCollection FoodTrendCollection { get; set; }
        public string [] FoodTrendLabels { get; set; }
        public Func<double, string> FoodTrendFormatter { get; set; }
        public SeriesCollection ImportMaterialCollection { get; set; }
        public string [] ImportMaterialLabels { get; set; }
        public Func<double, string> ImportMaterialFormatter { get; set; }
        public ReportView()
        {
            InitializeComponent();
            LoadData();
            this.Loaded += ReportView_Loaded;
        }

        private void ReportView_Loaded( object sender, RoutedEventArgs e )
        {
            LoadSaleChart();
            LoadFoodTrendChart();
            LoadImportMaterialChart();
        }

        private void LoadData()
        {
            CafeShopEntities entity = new CafeShopEntities();
            string userName = Properties.Settings.Default.user;
            tbUserName.Text = entity.NHANVIENs.Where(employee => employee.MaNV.ToString() == userName).FirstOrDefault().TenNV;
        }

        private void LoadSaleChart()
        {
            var months = new List<string>();
            for(int i = 1; i <= 12; i++)
            {
                months.Add(i.ToString());
            }

            SaleLabels = months.Select(x => x.ToString()).ToArray();
            SaleFormatter = value => String.Format("{0:C0}", value);

            SaleCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                },
                new ColumnSeries
                {
                    Title = "Tiền nhập hàng",
                },
                new ColumnSeries
                {
                    Title = "Tiền lãi",
                }

            };

            var year = DateTime.Now.Year;

            List<SaleOfYear> saleOfYear = reportVM.GetSaleOfYear(year);
            List<SaleOfYear> finalSale = SetSaleOfYear(saleOfYear);
            SaleCollection [0].Values = finalSale.Select(x => x.SaleTotal).ToArray().AsChartValues<int>();

            List<ImportOfYear> importOfYear = reportVM.GetImportOfYear(year);
            List<ImportOfYear> finalImport = SetImportOfYear(importOfYear);
            SaleCollection [1].Values = finalImport.Select(x => x.ImportTotal).ToArray().AsChartValues<int>();

            List<int> benefits = new List<int>();
            var monthLoops = finalImport.Count > finalSale.Count ? finalImport.Count : finalSale.Count;
            SetBenefitsOfYear(monthLoops, benefits, finalSale, finalImport);
            SaleCollection [2].Values = benefits.Select(x => x).ToArray().AsChartValues<int>();
        }

        private List<SaleOfYear> SetSaleOfYear(List<SaleOfYear> sales)
        {
            List<SaleOfYear> filterSale = new List<SaleOfYear>();
            if (sales.Count > 0)
            {
                var minMonth = sales [0].Month;
                if (minMonth > 1)
                {
                    for (int i = 1; i < minMonth; i++)
                    {
                        filterSale.Add(new SaleOfYear
                        {
                            Month = i,
                            SaleTotal = 0
                        });
                    }
                }
                foreach (var sale in sales)
                {
                    filterSale.Add(sale);
                }
            }
            return filterSale;
        }

        private List<ImportOfYear> SetImportOfYear( List<ImportOfYear> imports )
        {
            List<ImportOfYear> filterImport = new List<ImportOfYear>();
            if (imports.Count > 0)
            {
                var minMonth = imports [0].Month;
                if ( minMonth > 1 )
                {
                    for ( int i = 1; i < minMonth; i++ )
                    {
                        filterImport.Add(new ImportOfYear
                        {
                            Month = i,
                            ImportTotal = 0
                        });
                    }
                }
                foreach ( var import in imports )
                {
                    filterImport.Add(import);
                }
            }
            return filterImport;
        }

        private List<int> SetBenefitsOfYear(int monthLoops, List<int> benefits, List<SaleOfYear> finalSale, List<ImportOfYear> finalImport)
        {
            for ( int i = 0; i < monthLoops; i++ )
            {
                if ( i < finalImport.Count - 1 && i < finalSale.Count )
                {
                    benefits.Add(finalSale [i].SaleTotal - finalImport [i].ImportTotal);
                }
                else
                {
                    if ( i > finalSale.Count - 1 )
                    {
                        benefits.Add(0 - finalImport [i].ImportTotal);
                    }
                    else if ( i > finalSale.Count - 1 )
                    {
                        benefits.Add(finalSale [i].SaleTotal - 0);
                    }
                }
            }
            return benefits;
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
