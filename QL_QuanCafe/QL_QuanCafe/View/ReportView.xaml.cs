using LiveCharts.Helpers;
using LiveCharts.Wpf;
using LiveCharts;
using QL_QuanCafe.Model;
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
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.Reflection;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : System.Windows.Controls.Page
    {
        ReportViewModel reportVM = new ReportViewModel();
        public LiveCharts.SeriesCollection SaleCollection { get; set; }
        public string [] SaleLabels { get; set; }
        public Func<double, string> SaleFormatter { get; set; }
        public LiveCharts.SeriesCollection FoodTrendCollection { get; set; }
        public string [] FoodTrendLabels { get; set; }
        public Func<double, string> FoodTrendFormatter { get; set; }
        public LiveCharts.SeriesCollection ImportMaterialCollection { get; set; }
        public string [] ImportMaterialLabels { get; set; }
        public Func<double, string> ImportMaterialFormatter { get; set; }
        List<SaleOfYear> finalSale = new List<SaleOfYear>();
        List<ImportOfYear> finalImport = new List<ImportOfYear>();
        List<int> benefits = new List<int>();
        List<int> quantityOfEachTrendFoods = new List<int>();
        List<double> quantityOfMaterials = new List<double>();
        List<string> listOfMaterialNames = new List<string>();
        private int indexOfExportType = -1;
        System.Data.DataTable exportData;
        List<string> months = new List<string>();
        public ReportView()
        {
            InitializeComponent();
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            CafeShopEntities entity = new CafeShopEntities();
            string userName = Properties.Settings.Default.user;
            tbUserName.Text = entity.NHANVIENs.Where(employee => employee.MaNV.ToString() == userName).FirstOrDefault().TenNV;

            LoadSaleChart();
            LoadFoodTrendChart();
            LoadImportMaterialChart();
        }

        private void LoadSaleChart()
        {
            for ( int i = 1; i <= 12; i++ )
            {
                months.Add(i.ToString());
            }

            SaleLabels = months.Select(x => x.ToString()).ToArray();
            SaleFormatter = value => String.Format("{0:C0}", value);

            SaleCollection = new LiveCharts.SeriesCollection
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
            tbSaleTitle.Text = $"THỐNG KÊ DOANH THU TRONG NĂM {year}";

            List<SaleOfYear> saleOfYear = reportVM.GetSaleOfYear(year);
            finalSale = SetSaleOfYear(saleOfYear);
            SaleCollection [0].Values = finalSale.Select(x => x.SaleTotal).ToArray().AsChartValues<int>();

            List<ImportOfYear> importOfYear = reportVM.GetImportOfYear(year);
            finalImport = SetImportOfYear(importOfYear);
            SaleCollection [1].Values = finalImport.Select(x => x.ImportTotal).ToArray().AsChartValues<int>();

            benefits = SetBenefitsOfYear(12, benefits, finalSale, finalImport);
            SaleCollection [2].Values = benefits.Select(x => x).ToArray().AsChartValues<int>();
        }

        private List<SaleOfYear> SetSaleOfYear( List<SaleOfYear> sales )
        {
            List<SaleOfYear> filterSale = new List<SaleOfYear>();
            if ( sales.Count > 0 )
            {
                var minMonth = sales [0].Month;
                var maxMonth = sales [sales.Count - 1].Month;
                if ( minMonth == maxMonth )
                {
                    for ( int i = 1; i <= 12; i++ )
                    {
                        if ( i < minMonth || i > minMonth )
                        {
                            filterSale.Add(new SaleOfYear
                            {
                                Month = i,
                                SaleTotal = 0
                            });
                        }
                        else
                        {
                            filterSale.Add(sales [0]);
                        }
                    }
                }
                else
                {
                    for ( int i = 1; i <= 12; i++ )
                    {
                        if ( i < minMonth || i > maxMonth )
                        {
                            filterSale.Add(new SaleOfYear
                            {
                                Month = i,
                                SaleTotal = 0
                            });
                        }
                        else
                        {
                            foreach ( var sale in sales )
                            {
                                if ( i <= 12 )
                                {
                                    filterSale.Add(sale);
                                    i++;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for ( int i = 1; i <= 12; i++ )
                {
                    filterSale.Add(new SaleOfYear
                    {
                        Month = i,
                        SaleTotal = 0
                    });
                }
            }
            return filterSale;
        }

        private List<ImportOfYear> SetImportOfYear( List<ImportOfYear> imports )
        {
            List<ImportOfYear> filterImport = new List<ImportOfYear>();
            if ( imports.Count > 0 )
            {
                var minMonth = imports [0].Month;
                var maxMonth = imports [imports.Count - 1].Month;
                if ( minMonth == maxMonth )
                {
                    for ( int i = 1; i <= 12; i++ )
                    {
                        if ( i < minMonth || i > minMonth )
                        {
                            filterImport.Add(new ImportOfYear
                            {
                                Month = i,
                                ImportTotal = 0
                            });
                        }
                        else
                        {
                            filterImport.Add(imports [0]);
                        }
                    }
                }
                else
                {
                    for ( int i = 1; i <= 12; i++ )
                    {
                        if ( i < minMonth || i > maxMonth )
                        {
                            filterImport.Add(new ImportOfYear
                            {
                                Month = i,
                                ImportTotal = 0
                            });
                        }
                        else
                        {
                            foreach ( var import in imports )
                            {
                                if ( i <= 12 )
                                {
                                    filterImport.Add(import);
                                    i++;
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                for ( int i = 1; i <= 12; i++ )
                {
                    filterImport.Add(new ImportOfYear
                    {
                        Month = i,
                        ImportTotal = 0
                    });
                }
            }
            return filterImport;
        }

        private List<int> SetBenefitsOfYear( int monthLoops, List<int> benefits, List<SaleOfYear> finalSale, List<ImportOfYear> finalImport )
        {
            for ( int i = 0; i < monthLoops; i++ )
            {
                benefits.Add(finalSale [i].SaleTotal - finalImport [i].ImportTotal);
            }
            return benefits;
        }

        private void LoadFoodTrendChart()
        {
            quantityOfEachTrendFoods = reportVM.GetTopTrendProductQuantity();
            FoodTrendLabels = reportVM.GetTopTrendProductName().Select(x => x.ToString()).ToArray();
            FoodTrendFormatter = value => value.ToString();

            FoodTrendCollection = new LiveCharts.SeriesCollection
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
            listOfMaterialNames = reportVM.GetAllMaterialNeedToImport();
            ImportMaterialLabels = listOfMaterialNames.Select(x => x).ToArray();
            ImportMaterialFormatter = value => value.ToString();

            foreach ( var item in listOfMaterialNames )
            {
                quantityOfMaterials.Add(reportVM.GetQuantityOfMaterial(item));
            }

            ImportMaterialCollection = new LiveCharts.SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Số lượng còn lại",
                }
            };
            ImportMaterialCollection [0].Values = quantityOfMaterials.ToArray().AsChartValues<double>();
        }

        private object [] CreateObjectArrayDataFromList<T>( List<T> items )
        {
            var values = new object [items.Count];
            for ( int i = 0; i < items.Count; i++ )
            {
                values [i] = items [i];
            }
            return values;
        }

        private System.Data.DataTable SetDataFromListToDataTable( System.Data.DataTable dt )
        {
            switch ( indexOfExportType )
            {
                case 0:
                    dt.Rows.Add(CreateObjectArrayDataFromList<int>(finalSale.Select(x => x.SaleTotal).ToList()));
                    dt.Rows.Add(CreateObjectArrayDataFromList<int>(finalImport.Select(x => x.ImportTotal).ToList()));
                    dt.Rows.Add(CreateObjectArrayDataFromList<int>(benefits.Select(x => x).ToList()));
                    return dt;
                case 1:
                    dt.Rows.Add(CreateObjectArrayDataFromList<int>(quantityOfEachTrendFoods.Select(x => x).ToList()));
                    return dt;
                case 2:
                    dt.Rows.Add(CreateObjectArrayDataFromList<double>(quantityOfMaterials.Select(x => x).ToList()));
                    return dt;
                default:
                    break;
            }
            return null;
        }

        private System.Data.DataTable ConvertDataToDataTable()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            switch ( indexOfExportType )
            {
                case 0:
                    foreach ( var month in months )
                    {
                        dataTable.Columns.Add($"Tháng {month}");
                    }
                    break;
                case 1:
                    foreach ( var productName in reportVM.GetTopTrendProductName().Select(x => x.ToString()).ToList() )
                    {
                        dataTable.Columns.Add(productName);
                    }
                    break;
                case 2:
                    foreach ( var materialName in reportVM.GetAllMaterialNeedToImport() )
                    {
                        dataTable.Columns.Add(materialName);
                    }
                    break;
                default:
                    break;
            }
            dataTable = SetDataFromListToDataTable(dataTable);
            return dataTable;
        }

        private void btnExport_Click( object sender, RoutedEventArgs e )
        {
            if ( cbExportType.Text == "" )
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo cần xuất file", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.indexOfExportType = cbExportType.SelectedIndex;
                exportData = ConvertDataToDataTable();
                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(exportData);

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkBook = excelApp.Workbooks.Add();
                _Worksheet xlWorksheet = excelWorkBook.Sheets [1];
                Range xlRange = xlWorksheet.UsedRange;
                foreach ( System.Data.DataTable table in dataSet.Tables )
                {
                    Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                    excelWorkSheet.Name = table.TableName;

                    for ( int i = 1; i < table.Columns.Count + 1; i++ )
                    {
                        excelWorkSheet.Cells [2, i + 1] = table.Columns [i - 1].ColumnName;
                    }

                    for ( int j = 0; j < table.Rows.Count; j++ )
                    {
                        for ( int k = 0; k < table.Columns.Count; k++ )
                        {
                            excelWorkSheet.Cells [j + 3, k + 2] = indexOfExportType == 0 ? String.Format("{0:C0}", table.Rows [j].ItemArray [k]) : table.Rows [j].ItemArray [k].ToString();
                        }
                    }
                    SetSideTitleOfExcel(excelWorkSheet);
                }

                string fileName = RenameReport();
                string path = "F:" + "\\" + fileName;
                excelWorkBook.Saved = true;
                excelWorkBook.SaveCopyAs(path);
                excelWorkBook.Close();
                excelApp.Quit();
                System.Windows.MessageBox.Show("Xuất báo cáo thành công!!", "Thông báo");
            } 
        }
        
        private void SetSideTitleOfExcel( Worksheet excelWorkSheet )
        {
            switch(indexOfExportType)
            {
                case 0:
                    excelWorkSheet.Cells [3, 1] = "Doanh thu";
                    excelWorkSheet.Cells [4, 1] = "Số tiền nhập hàng";
                    excelWorkSheet.Cells [5, 1] = "Tiền lãi";
                    break;
                case 1:
                    excelWorkSheet.Cells [3, 1] = "Số lượng đã đặt";
                    break;
                case 2:
                    excelWorkSheet.Cells [3, 1] = "Số lượng còn lại";
                    break;
                default:
                    break;
            }
        }

        private string RenameReport()
        {
            Random rd = new Random();
            switch(indexOfExportType)
            {
                case 0:
                    return $"Sale Report-{rd.Next(1000,9999)}-{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}.xlsx";
                case 1:
                    return $"Trend Foods Report-{rd.Next(1000, 9999)}-{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}.xlsx";
                case 2:
                    return $"Import Materials Report-{rd.Next(1000, 9999)}-{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}.xlsx";
                default:
                    break;
            }
            return "";
        }
    }
}
