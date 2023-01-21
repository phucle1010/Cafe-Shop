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
        CustomerViewModel customerVM = new CustomerViewModel();
        FoodViewModel foodVM = new FoodViewModel();
        Frame MainContent;


        public AccumlatorPointView(Frame MainContent )
        {
            InitializeComponent();
            LoadData();
            this.MainContent= MainContent;
            this.customerId = customerVM.getCustomerId(Properties.Settings.Default ["user"].ToString());
            this.currentPoint = customerVM.GetAccumlatorPointOfCustomer(customerId);
            LoadFood();
        }
        private void LoadData()
        {
            CustomerViewModel customer = new CustomerViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = customer.getCustomerName(userName);
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
