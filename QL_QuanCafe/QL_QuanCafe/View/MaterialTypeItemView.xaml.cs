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

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for MaterialTypeItemView.xaml
    /// </summary>
    public partial class MaterialTypeItemView : Page
    {
        string _materialTypeName;
        string _materialName;
        string importId = Properties.Settings.Default ["importId"].ToString();
        MaterialTypeItemViewModel materialTypeItem = new MaterialTypeItemViewModel();
        string _materialTypeId = Properties.Settings.Default ["materialType"].ToString();
        public MaterialTypeItemView()
        {
            InitializeComponent();
            LoadMaterialImage();
            LoadMaterialTypeData();
            LoadMaterialNameList();
        }
        void LoadMaterialTypeData()
        {
            this._materialTypeName = materialTypeItem.getMaterialTypeName(_materialTypeId);

            materialTypeId.Text = $"Mã loại nguyên liệu: {_materialTypeId}";
            materialTypeName.Text = $"Tên loại nguyên liệu: {_materialTypeName}";
        }

        void LoadMaterialImage()
        {
            switch (_materialTypeId)
            {
                case "01":
                    materialTypeImg.ImageSource = new BitmapImage(new Uri(@"https://bizweb.dktcdn.net/thumb/large/100/405/472/products/cafe-da-3.jpg?v=1602234663170", UriKind.Absolute));
                    break;
                case "02":
                    materialTypeImg.ImageSource = new BitmapImage(new Uri(@"https://cdn.beptruong.edu.vn/wp-content/uploads/2015/12/matcha-da-xay-600x400.jpg", UriKind.Absolute));
                    break;
                case "03":
                    materialTypeImg.ImageSource = new BitmapImage(new Uri(@"https://media-cdn-v2.laodong.vn/Storage/NewsPortal/2020/9/19/837524/Giam-Mo.jpg", UriKind.Absolute));
                    break;
                case "04":
                    materialTypeImg.ImageSource = new BitmapImage(new Uri(@"https://vnn-imgs-f.vgcloud.vn/2020/05/27/09/cach-lam-5-mon-kem-trai-cay-giai-nhiet-ngay-he.jpg", UriKind.Absolute));
                    break;
                case "05":
                    materialTypeImg.ImageSource = new BitmapImage(new Uri(@"https://amazingcoffee.vn/uploads/news/2021_03/qu%C3%A1-tr%C3%ACnh-chi%E1%BA%BFt-xu%E1%BA%A5t-c%C3%A0-ph%C3%AA_1.jpg", UriKind.Absolute));
                    break;
                case "06":
                    materialTypeImg.ImageSource = new BitmapImage(new Uri(@"https://photo-cms-tpo.epicdn.me/w890/Uploaded/2022/rkznae/2020_11_11/nuoc_ep_hoa_qua_FKBO.jpg", UriKind.Absolute));
                    break;
                case "07":
                    materialTypeImg.ImageSource = new BitmapImage(new Uri(@"https://liberico.vn/wp-content/uploads/2021/11/uong-tra-den-tot-cho-suc-khoe.jpg", UriKind.Absolute));
                    break;
                default:
                    break;
            }
        }

        void LoadMaterialNameList()
        {
            int numberOfMaterial = materialTypeItem.numberOfMaterialItems(_materialTypeId);
            for (int i = 0; i < numberOfMaterial; i++ )
            {
                string materialName = DataProvider.Ins.DB.HANGHOAs.SqlQuery($"SELECT * FROM HANGHOA WHERE MaLoaiHH = '{_materialTypeId}'").ElementAt(i).TenHH.ToString();
                materialItemOfTypeList.Items.Add(materialName);
            }
        }
        private void cbMaterialItem_Change( object sender, SelectionChangedEventArgs e )
        {
            _materialName = (sender as ComboBox).SelectedItem as string;
            materialIdValue.Text = materialTypeItem.getMaterialId(_materialTypeId, _materialName);
            availableMaterialQuantityValue.Text = materialTypeItem.getAvailableMaterialQuantity(_materialName) + " " + materialTypeItem.getMaterialUnit(_materialTypeId, _materialName);
            materialPriceValue.Text = materialTypeItem.getMaterialPrice(_materialTypeId, _materialName) + " VNĐ";
        }
        private int RandomId()
        {
            Random rb = new Random();
            return rb.Next(100000, 999999);
        }

        public bool IsValidQuantity()
        {
            return Convert.ToInt32(quantityInputValue.Text) >= 0;
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            if (String.IsNullOrEmpty(_materialName))
            {
                MessageBox.Show("Vui lòng chọn tên nguyên liệu !!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if ( !IsValidQuantity() )
                {
                    MessageBox.Show("Số lượng nhập không hợp lệ !!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int importQuantity = Convert.ToInt32(quantityInputValue.Text);
                    double materialPrice = Convert.ToDouble(materialTypeItem.getPricePerMaterial(materialIdValue.Text));
                    int total = importQuantity * (int)materialPrice;
                    int detailImportId = 0;
                    do
                    {
                        detailImportId = RandomId();
                    } while ( materialTypeItem.insertDetailImportId(detailImportId) > 0 );
                    materialTypeItem.insertDetailImportMaterialData(detailImportId, importId, materialIdValue.Text, Int32.Parse(quantityInputValue.Text));
                    materialTypeItem.updateAvailableMaterialQuantity(_materialName, Int32.Parse(quantityInputValue.Text));
                    materialTypeItem.updateCurrentTotalPrice(importId, total);
                    quantityInputValue.Text = "";
                }
            }
        }
    }
}
