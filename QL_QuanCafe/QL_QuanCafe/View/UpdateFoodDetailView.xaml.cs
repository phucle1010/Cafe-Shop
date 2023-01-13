using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UpdateFoodDetailView.xaml
    /// </summary>
    public partial class UpdateFoodDetailView : Window
    {
        UpdateFoodViewModel updFoodVM = new UpdateFoodViewModel();
        private int foodId;
        private int materialId;
        public UpdateFoodDetailView()
        {
            InitializeComponent();
        }

        public UpdateFoodDetailView(int foodId)
        {
            InitializeComponent();
            this.foodId = foodId;
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

        private void LoadData()
        {
            tbFoodName.Text = updFoodVM.GetFoodData(foodId).TenSP;

            foreach(var item in updFoodVM.GetAllFoodDetail(foodId))
            {
                cbMaterialList.Items.Add(updFoodVM.GetMaterialNameByMaterialId((int) item.MaHH));
            }
        }

        private void cbMaterialList_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            string materialName = cbMaterialList.SelectedValue.ToString();
            CT_SANPHAM currentMaterial = updFoodVM.GetCurrentMaterialDataForFood(materialName, foodId);
            tbQuantity.Text = currentMaterial.SoLuong.ToString();
            this.materialId = (int) currentMaterial.MaHH;
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            if ( updFoodVM.UpdateNewNeededQuantityForFod(materialId, foodId, tbQuantity.Text.Replace(",", ".")) == 1 )
            {
                MessageBox.Show("Cập nhật công thức thành công");
            }
        }
    }
}
