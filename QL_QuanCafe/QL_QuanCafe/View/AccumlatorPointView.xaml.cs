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
    /// Interaction logic for AccumlatorPointView.xaml
    /// </summary>
    public partial class AccumlatorPointView : Page
    {
        private int currentPoint;
        private int customerId;
        private string userName = Properties.Settings.Default.user;
        CustomerViewModel customerVM = new CustomerViewModel();
        FoodViewModel foodVM = new FoodViewModel();
        Frame MainContent;

        public AccumlatorPointView(Frame MainContent )
        {
            InitializeComponent();
            this.MainContent= MainContent;
            this.customerId = customerVM.getCustomerId(userName);
            LoadData();
            LoadFood();
        }
        private void LoadData()
        {
            CafeShopEntities entity = new CafeShopEntities();
            this.currentPoint = customerVM.GetAccumlatorPointOfCustomer(this.customerId, entity);
            tbUserName.Text = entity.KHACHHANGs.Where(client => client.TenDN == this.userName).First().TenKH;
        }

        private void LoadFood()
        {
            var foodList = foodVM.GetAllFood();
            foreach(var food in foodList)
            {
                plFood.Children.Add(new AccumlatorPointItemView(food, this.currentPoint, customerId, MainContent));
            }
        }
    }
}
