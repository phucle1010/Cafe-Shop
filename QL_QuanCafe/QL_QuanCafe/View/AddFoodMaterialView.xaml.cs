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
    /// Interaction logic for AddFoodMaterialView.xaml
    /// </summary>
    public partial class AddFoodMaterialView : Window
    {
        List<CT_SANPHAM> productTypeLst = new List<CT_SANPHAM>();
        AddFoodMaterialViewModel foodMaterialVM = new AddFoodMaterialViewModel();
        string foodId;
        string typeId;
        public AddFoodMaterialView()
        {
            InitializeComponent();
            this.foodId = "";
            LoadData();
        }
        public AddFoodMaterialView(string foodId, string typeId)
        {
            InitializeComponent();
            this.foodId = foodId;
            this.typeId = typeId;
            LoadData();
            MessageBox.Show(foodId);
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage( IntPtr hWnd, int wMsg, int wParam, int lParam );
        private void btnMaximize_Click( object sender, RoutedEventArgs e )
        {
            if ( this.WindowState == WindowState.Normal )
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

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

        public void LoadData()
        {
            cbMaterialType.Items.Add(foodMaterialVM.GetProductName(this.typeId));
            cbMaterialType.SelectedIndex = 0;
        }

        private void pnlControlBar_MouseEnter( object sender, System.Windows.Input.MouseEventArgs e )
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void cbMaterialType_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            cbMaterialName.Items.Clear();
            string materialTypeName = cbMaterialType.SelectedItem.ToString();
            string materialTypeId = foodMaterialVM.GetProductTypeId(materialTypeName);  /// Mã loại hàng hóa

            List<string> productNameLst = foodMaterialVM.GetAllProductWithTypeId(materialTypeId);
            foreach ( var item in productNameLst )
            {
                cbMaterialName.Items.Add(item);
            }
        }


        private void btnAddSubmit_Click( object sender, RoutedEventArgs e )
        {
            if (cbMaterialType.SelectedIndex < 0 || cbMaterialName.SelectedIndex < 0 || String.IsNullOrEmpty(tbQuantity.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi");
            }
            else
            {
                string materialTypeName = cbMaterialType.SelectedItem.ToString();  /// Tên loại hàng hóa
                string materialName = cbMaterialName.SelectedItem.ToString();  /// Tên hàng hóa
                string materialTypeId = foodMaterialVM.GetProductTypeId(materialTypeName);

                string materialId = foodMaterialVM.GetProductId(materialName, materialTypeId);

                foodMaterialVM.InsertMaterialData(this.foodId, Int32.Parse(materialId), Int32.Parse(tbQuantity.Text));

                tbUnit.Text = "";
                tbQuantity.Text = "";
                //cbMaterialType.Items.Clear();
                //cbMaterialName.Items.Clear();
            }
        }

        private void cbMaterialName_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            if ( cbMaterialName.Items.Count > 0)
            {
                string name = cbMaterialName.SelectedItem.ToString();
                string unit = foodMaterialVM.GetUnitOfProduct(name);
                if (unit != null)
                {
                    tbUnit.Text = unit;
                }
            }
        }
    }
}
