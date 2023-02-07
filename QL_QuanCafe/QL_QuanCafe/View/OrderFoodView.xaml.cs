using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for OrderFoodView.xaml
    /// </summary>
    public partial class OrderFoodView : Page
    {
        OrderFoodViewModel orderFoodVM = new OrderFoodViewModel();
        CafeShopEntities entity = new CafeShopEntities();
        List<CT_HOADON> orderDetailList = new List<CT_HOADON>();
        string userName = Properties.Settings.Default.user;
        int customerId;
        string tableName;
        Frame MainContent;
        public OrderFoodView(Frame MainContent )
        {
            InitializeComponent();
            this.MainContent = MainContent;
            this.tableName = "";
            LoadData();
            LoadOrderTable();
            LoadFoodList();
            ((INotifyCollectionChanged) lvOrderChosedFood.Items).CollectionChanged += OrderFoodView_CollectionChanged;
        }

        private void OrderFoodView_CollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
        {
            if (lvOrderChosedFood.Items.Count > 0)
            {
                btnSubmit.Visibility = Visibility.Visible;
            }
            else
            {
                btnSubmit.Visibility = Visibility.Hidden;
            } 
        }

        void LoadData()
        {
            CustomerViewModel customer = new CustomerViewModel();
            tbUserName.Text = entity.KHACHHANGs.Where(client => client.TenDN == this.userName).First().TenKH; 
            customerId = orderFoodVM.GetCustomerId(userName);
            btnSubmit.Visibility = Visibility.Hidden;
            tbTableName.Visibility = Visibility.Hidden;
        }

        void LoadOrderTable()
        {
            List<DATBAN> orderedTable = entity.DATBANs.Where(table => table.MaKH == customerId && (bool) table.TrangThaiDatMon == false).ToList();
            foreach (DATBAN orderedItem in orderedTable)
            {
                lvOrderedTable.Items.Add(entity.BANs.Where(table => table.MaBan == orderedItem.MaBan).First().TenBan);
            }
        }

        void LoadFoodList()
        {
            List<SANPHAM> sp = orderFoodVM.GetAllFood();
            foreach (var item in sp)
            {
                OrderFoodInfoListView foodDetailInfo = new OrderFoodInfoListView(lvOrderChosedFood, orderDetailList, item.MaSP, item.HinhAnh, item.TenSP, (int)item.GiaSP);
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

        public bool InsertBillDetail( int billId )
        {
            foreach(var item in orderDetailList )
            {
                int price = orderFoodVM.GetFoodPrice((int) item.MaSP);
                if (orderFoodVM.InsertDataToBillDetail(billId, (int) item.MaSP, (int) item.SoLuong, price) == 0)
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
                if (tableName == "")
                {
                    MessageBox.Show("Vui lòng chọn bàn muốn đặt món!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string tableId = entity.BANs.Where(table => table.TenBan == tableName).FirstOrDefault().MaBan;
                    int orderTableId = entity.DATBANs.Where(table => table.MaBan == tableId).FirstOrDefault().MaDatBan;

                    int billId = orderFoodVM.GetBillId(orderTableId);
                    if ( InsertBillDetail(billId) == true )
                    {
                        MessageBox.Show("Đặt món thành công!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainContent.Navigate(new OrderFoodView(MainContent));
                    }
                    else
                    {
                        MessageBox.Show("Đặt món thất bại!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }    
            }
        }

        private void btnViewHistory_MouseMove( object sender, System.Windows.Input.MouseEventArgs e )
        {
            iconHistory.Foreground = new SolidColorBrush(Colors.LightGray);
            tbHistory.Foreground = new SolidColorBrush(Colors.LightGray);
        }

        private void btnViewHistory_MouseLeave( object sender, System.Windows.Input.MouseEventArgs e )
        {
            iconHistory.Foreground = new SolidColorBrush(Colors.Gray);
            tbHistory.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void btnViewHistory_Click( object sender, RoutedEventArgs e )
        {
            OrderFoodHistoryView orderFoodHistory = new OrderFoodHistoryView();
            orderFoodHistory.Show();
        }

        private void lvOrderedTable_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            if (lvOrderedTable.SelectedIndex == -1)
            {
                tbTableName.Visibility = Visibility.Hidden;
            }
            else
            {
                tbTableName.Visibility = Visibility.Visible;
                tableName = lvOrderedTable.SelectedValue.ToString();
                tbTableName.Text = $"Bàn được chọn: {lvOrderedTable.SelectedValue}";
            }
        }
    }
}
