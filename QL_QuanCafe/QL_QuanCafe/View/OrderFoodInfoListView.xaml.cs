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
    /// Interaction logic for OrderFoodInfoListView.xaml
    /// </summary>
    public partial class OrderFoodInfoListView : UserControl
    {
        OrderFoodInfoListViewModel orderFoodInfoListVM = new OrderFoodInfoListViewModel();
        string userName = Properties.Settings.Default ["user"].ToString();
        int customerId;
        int foodId;
        string imagePath;
        string name;
        int price;
        int currentValue;
        List<CT_DATMON> orderDetailList;
        public OrderFoodInfoListView()
        {
            InitializeComponent();
            currentValue = 0;
        }

        public OrderFoodInfoListView(List<CT_DATMON> orderDetailList, int foodId, string imagePath, string name, int price)
        {
            InitializeComponent();
            customerId = orderFoodInfoListVM.GetCustomerId(userName);
            this.foodId = foodId;
            this.imagePath = imagePath;
            this.name = name;
            this.price = price;
            this.currentValue = 0;
            this.orderDetailList = orderDetailList;
            LoadData();
        }

        void LoadData()
        {
            ImageSource imageSource = new BitmapImage(new Uri(imagePath));
            foodImage.Source = imageSource;
            foodName.Text = name;
            foodPrice.Text = price.ToString();
        }

        private void btnDownValue_Click( object sender, RoutedEventArgs e )
        {
            if ( this.currentValue > 0 )
            {
                this.currentValue--;
                txtcurrentValue.Text = this.currentValue.ToString();
            }
        }

        private void btnUpValue_Click( object sender, RoutedEventArgs e )
        {
            this.currentValue++;
            txtcurrentValue.Text = this.currentValue.ToString();
        }

        public void AddOrderDetail()
        {
            CT_DATMON sp = new CT_DATMON();
            sp.MaSP = this.foodId;
            sp.SoLuong = (short?) this.currentValue;
            this.orderDetailList.Add(sp);
        }

        public bool IsFullQuantity(int numberOfMaterial )
        {
            for ( var i = 0; i < numberOfMaterial; i++ )
            {
                int materialId = orderFoodInfoListVM.GetMaterialId(foodId, i);

                int neededQuantityOfMaterial = orderFoodInfoListVM.GetMinQuantityForFood(foodId, materialId);
                int availableQuantityOfMaterial = orderFoodInfoListVM.GetAvailableQuantityOfMaterial(materialId);
                if (availableQuantityOfMaterial < neededQuantityOfMaterial * this.currentValue) 
                    return false;
            }
            AddOrderDetail();
            return true;
        }

        public void HandleOrderFood()
        {
            if ( this.currentValue == 0 )
            {
                MessageBox.Show("Vui lòng chọn số lượng muốn đặt!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int numberOfMaterial = orderFoodInfoListVM.NumberOfMaterialForFood(foodId);
                if (IsFullQuantity(numberOfMaterial))
                {
                    MessageBox.Show($"Bạn vừa chọn {foodName.Text} vào danh sách đặt món", "Thông báo");
                } 
                else
                {
                    MessageBox.Show("Món ăn hiện tại đã hết. Vui lòng chọn món khác", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            if (orderFoodInfoListVM.IsSubmitOrderTable(customerId) )
            {
                HandleOrderFood();
            }
            else
            {
                if ( orderFoodInfoListVM.IsWaitingForSubmitOrderTable(customerId) )
                {
                    MessageBox.Show("Yêu cầu đặt bàn của bạn đang được xử lý. Vui lòng chờ trong chốc lát!!!", "Thông báo", MessageBoxButton.OK);
                } else
                {
                    MessageBox.Show("Vui lòng đặt bàn trước khi đặt món!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void vote_ValueChanged( object sender, RoutedPropertyChangedEventArgs<double> e )
        {
            
        }
    }
}
