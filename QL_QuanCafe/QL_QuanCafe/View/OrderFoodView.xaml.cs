using QL_QuanCafe.ViewModel;
using System.Windows.Controls;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for OrderFoodView.xaml
    /// </summary>
    public partial class OrderFoodView : Page
    {
        public OrderFoodView()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            CustomerViewModel customer = new CustomerViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = customer.getCustomerName(userName);
        }
    }
}
