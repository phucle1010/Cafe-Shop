using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for OrderFoodView.xaml
    /// </summary>
    public partial class OrderFoodView : Page
    {
        OrderFoodViewModel orderFoodVM = new OrderFoodViewModel();
        List<CT_DATMON> orderDetailList = new List<CT_DATMON>();
        string userName = Properties.Settings.Default ["user"].ToString();
        int customerId;
        public OrderFoodView()
        {
            InitializeComponent();
            LoadData();
            LoadFoodList();
        }
        void LoadData()
        {
            CustomerViewModel customer = new CustomerViewModel();
            tbUserName.Text = customer.getCustomerName(userName);
            customerId = orderFoodVM.GetCustomerId(userName);
        }

        void LoadFoodList()
        {
            List<SANPHAM> sp = orderFoodVM.GetAllFood();
            foreach (var item in sp)
            {
                OrderFoodInfoListView foodDetailInfo = new OrderFoodInfoListView(orderDetailList, item.MaSP, item.HinhAnh, item.TenSP, (int)item.GiaSP);
                navigationFoodList.Children.Add(foodDetailInfo);
            }
        }

        public void UpdateAvailableMaterial( List<CT_SANPHAM> foodDetailList , int numberOfFoodInOrders)
        {
            foreach(var item in foodDetailList)
            {
                int usedQuantityTotal = numberOfFoodInOrders * (int) item.SoLuong;
                string materialName = orderFoodVM.GetMaterialName((int)item.MaHH);
                orderFoodVM.UpdateAvailableQuantityOfMaterial(materialName, usedQuantityTotal);
            }
        }

        public bool InsertOrderDetail( int orderFoodId )
        {
            foreach(var item in orderDetailList )
            {
                int price = orderFoodVM.GetFoodPrice((int) item.MaSP);
                if (orderFoodVM.InsertDataToOrderFoodDetail(orderFoodId, (int) item.MaSP, (int) item.SoLuong, price) == 0)
                {
                    return false;
                }
                List<CT_SANPHAM> foodDetailList = orderFoodVM.GetFoodDetailInfo((int) item.MaSP);
                UpdateAvailableMaterial(foodDetailList, (int) item.SoLuong);
            }
            return true;
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            if ( orderDetailList.Count == 0 )
            {
                MessageBox.Show("Số lượng món đã đặt là 0. Vui lòng chọn món để đặt trước khi xác nhận đặt món", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                DATBAN orderTable = orderFoodVM.GetOrderTabeleInfo(customerId);
                int orderTableId = orderTable.MaDatBan;
                orderFoodVM.InsertDataToOrderFood(customerId, orderTableId);

                int orderFoodId = orderFoodVM.GetOrderFoodId(customerId);
                if (InsertOrderDetail(orderFoodId) == true)
                {
                    MessageBox.Show("Đặt món thành công!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                } 
                else
                {
                    MessageBox.Show("Đặt món thất bại!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                /// xử lý đặt món trong list CT_DATMON
            }
        }
    }
}
