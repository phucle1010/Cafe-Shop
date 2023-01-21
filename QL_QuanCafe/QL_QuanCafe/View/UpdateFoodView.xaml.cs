using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for UpdateFoodView.xaml
    /// </summary>
    public partial class UpdateFoodView : Window
    {
        UpdateFoodViewModel updFoodVM = new UpdateFoodViewModel();
        int foodId;
        Frame MainContent;
        public UpdateFoodView()
        {
            InitializeComponent();
        }

        public UpdateFoodView( int foodId, Frame MainContent)
        {
            InitializeComponent();
            this.foodId = foodId;
            this.MainContent = MainContent;
            LoadData();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage( IntPtr hWnd, int wMsg, int wParam, int lParam );

        private void btnMinimize_Click( object sender, RoutedEventArgs e )
        {
            this.WindowState = WindowState.Minimized;
        }

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

        public void LoadData()
        {
            MessageBox.Show(foodId.ToString());
            tbFoodId.Text = this.foodId.ToString();

            SANPHAM s = updFoodVM.GetFoodData(foodId);
            tbFoodName.Text = s.TenSP;
            tbFoodPrice.Text = String.Format("{0:C0}", s.GiaSP); 
            cbFoodStatus.Text = Boolean.Parse(s.TrangThai.Value.ToString()) == true ? "Còn sẵn" : "Hết hàng"; 
        }

        private void btnUpdate_Click( object sender, RoutedEventArgs e )
        {
            if (String.IsNullOrEmpty(tbFoodPrice.Text) || cbFoodStatus.Text == "")
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin món ăn", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else
            {
                if ( !IsValidNumber(tbFoodPrice.Text) )
                {
                    System.Windows.MessageBox.Show("Giá tiền không hợp lệ. Vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    int price = Int32.Parse(tbFoodPrice.Text);
                    int status = cbFoodStatus.Text == "Còn sẵn" ? 1 : 0;
                    if(updFoodVM.UpdateFoodData(foodId, price, status) == 1)
                    {
                        this.Close();
                        MainContent.Navigate(new FoodView(MainContent));
                    }
                }
            }
        }

        public bool IsValidNumber( string value )
        {
            string tString = value;
            if ( tString.Trim() == "" ) return false;
            for ( int i = 0; i < tString.Length; i++ )
            {
                if ( !char.IsNumber(tString [i]) )
                {
                    return false;
                }
            }
            return true;
        }
    }
}
