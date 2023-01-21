using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for AddNewFoodView.xaml
    /// </summary>
    public partial class AddNewFoodView : Window
    {
        List<CT_SANPHAM> foodDetailLst = new List<CT_SANPHAM>();
        AddNewFoodViewModel newFoodVM = new AddNewFoodViewModel();
        string selectedFileName;
        Frame MainContent;
        public AddNewFoodView()
        {
            InitializeComponent();
            LoadData();
        }
        public AddNewFoodView(Frame MainContent)
        {
            InitializeComponent();
            LoadData();
            this.MainContent = MainContent;
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

            foreach(var item in newFoodVM.GetAllFoodType())
            {
                cbFoodType.Items.Add(item.TenLoaiSP);
            }
        }

        private void btnAddImage_Click( object sender, RoutedEventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if ( dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                selectedFileName = dlg.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(selectedFileName));
                ImageViewer.Source = imageSource;
            }
        }

        private void btnAddMaterial_Click( object sender, RoutedEventArgs e )
        {
            if ( String.IsNullOrEmpty(tbProductName.Text) || String.IsNullOrEmpty(tbProductPrice.Text) || cbFoodType.SelectedIndex == -1 )
            {
                System.Windows.MessageBox.Show("Vui lòng điền đày đủ thông tin món ăn");
            } else
            {
                if (!IsValidNumber(tbProductPrice.Text))
                {
                    System.Windows.MessageBox.Show("Giá tiền không hợp lệ. Vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                } else
                {
                    string typeName = cbFoodType.SelectedItem.ToString();
                    string typeId = newFoodVM.GetFoodTypeId(typeName);
                    newFoodVM.InsertFoodData(tbProductName.Text, typeId, tbProductPrice.Text, selectedFileName);
                    string foodId = newFoodVM.GetTheLatestFoodId();
                    AddFoodMaterialView addMaterialView = new AddFoodMaterialView(foodId, typeId);
                    addMaterialView.Show();
                    this.Close();
                    MainContent.Navigate(new FoodView(MainContent));
                }
            }
        }

        public bool IsValidNumber(string value)
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
