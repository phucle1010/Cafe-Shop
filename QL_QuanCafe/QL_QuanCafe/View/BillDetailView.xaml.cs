using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for BillDetailView.xaml
    /// </summary>
    public partial class BillDetailView : System.Windows.Window
    {
        System.Windows.Controls.Page payment;
        List<CT_HOADON> billDetailList = new List<CT_HOADON>();
        System.Data.DataTable billDetailData; 
        BillDetailViewModel billDetailVM = new BillDetailViewModel();
        private int billId;
        private int billDetailStatus;
        private string customer;
        public BillDetailView()
        {
            InitializeComponent();
        }
        public BillDetailView(int billId, System.Windows.Controls.Page payment, int billDetailStatus, string customer )
        {
            InitializeComponent();
            this.billId = billId;
            this.payment = payment;
            this.billDetailStatus = billDetailStatus;
            this.customer = customer;
            this.billDetailData = new System.Data.DataTable(); 
            LoadData();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage( IntPtr hWnd, int wMsg, int wParam, int lParam );
        private void btnClose_Click( object sender, RoutedEventArgs e )
        {
            this.Close();
        }
        private void pnlControlBar_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter( object sender, System.Windows.Input.MouseEventArgs e )
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        void LoadData()
        {
            int totalPrice = 0;
            billDetailList = billDetailVM.GetBillDetailList(billId);
            foreach(var item in billDetailList )
            {
                totalPrice += (int) billDetailVM.GetFoodInfo((int) item.MaSP).GiaSP;
                BillDetailItemView billDetailItem = new BillDetailItemView(item);
                detailList.Children.Add(billDetailItem);
            }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            lbTotal.Content = "Tổng tiền: " + double.Parse(totalPrice.ToString()).ToString("#,###", cul.NumberFormat);
            LoadOptions();
        }

        private void LoadOptions()
        {
            if (this.billDetailStatus == 1)
            {
                btnSubmit.Visibility = Visibility.Hidden;
            } else
            {
                btnExport.Visibility = Visibility.Hidden;
            }

        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            if (this.billDetailStatus == 0)
            {
                int orderTableId = billDetailVM.GetOrderTableId(billId);
                string tableId = billDetailVM.GetTableId(orderTableId);

                string username = Properties.Settings.Default ["user"].ToString();
                int employeeId = billDetailVM.GetEmplyeeId(username);
                if ( billDetailVM.UpdateBill(billId, orderTableId, tableId, employeeId) == 1)
                {
                    MessageBoxResult notice = System.Windows.MessageBox.Show("Thanh toán thành công hóa đơn!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    if ( notice == MessageBoxResult.OK )
                    {
                        this.Close();
                        payment.DataContext = null;
                    }
                }
            } 
        }

        private System.Data.DataTable ConvertDataToDataTable(List<CT_HOADON> billDetail)
        {
            // creating a data table instance and typed it as our incoming model   
            // as I make it generic, if you want, you can make it the model typed you want.  
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("Mã hóa đơn");
            dataTable.Columns.Add("Tên khách hàng");
            dataTable.Columns.Add("Tên món ăn");
            dataTable.Columns.Add("Số lượng");
            dataTable.Columns.Add("Thành tiền");


            foreach ( var item in billDetail )
            {
                int foodId =  (int) item.MaSP;
                string foodName = billDetailVM.GetFoodInfo(foodId).TenSP;
                int quantity = (int) item.SoLuong;
                int price = (int) billDetailVM.GetFoodInfo(foodId).GiaSP;
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                string totalPrice = double.Parse((price * quantity).ToString()).ToString("#,###", cul.NumberFormat);

                var values = new object [] { billId, customer, foodName, quantity, totalPrice };
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private void btnExport_Click( object sender, RoutedEventArgs e )
        {
            billDetailData = ConvertDataToDataTable(billDetailList);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(billDetailData);

            // create a excel app along side with workbook and worksheet and give a name to it  
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkBook = excelApp.Workbooks.Add();
            _Worksheet xlWorksheet = excelWorkBook.Sheets [1];
            Range xlRange = xlWorksheet.UsedRange;
            foreach ( System.Data.DataTable table in dataSet.Tables )
            {
                //Add a new worksheet to workbook with the Datatable name  
                Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                // add all the columns  
                for ( int i = 1; i < table.Columns.Count + 1; i++ )
                {
                    excelWorkSheet.Cells [1, i] = table.Columns [i - 1].ColumnName;
                }

                // add all the rows  
                for ( int j = 0; j < table.Rows.Count; j++ )
                {
                    for ( int k = 0; k < table.Columns.Count; k++ )
                    {
                        excelWorkSheet.Cells [j + 2, k + 1] = table.Rows [j].ItemArray [k].ToString();
                    }
                }
            }
  
            string fileName = $"{customer}-{billId}.xlsx";
            string path = "D:" + "\\" + fileName;
            excelWorkBook.Saved = true;
            excelWorkBook.SaveCopyAs(path);
            excelWorkBook.Close(true, path, Type.Missing);
            //excelWorkBook.SaveAs(path); // -> this will do the custom  
            //excelWorkBook.Close();
            excelApp.Quit();
            System.Windows.MessageBox.Show("In hoá đơn thành công!!", "Thông báo");
        }
    }
}
