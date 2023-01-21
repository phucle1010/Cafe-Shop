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
    /// Interaction logic for HomeCustomerView.xaml
    /// </summary>
    public partial class HomeCustomerView : Page
    {
        public HomeCustomerView()
        {
            InitializeComponent();
            LoadData();
            MainContent.Content = new HomeCustomerDetailView();
        }

        void LoadData()
        {
            CustomerViewModel customer = new CustomerViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = customer.getCustomerName(userName);
        }

        private void txtProfile_Click( object sender, MouseButtonEventArgs e )
        {
            MainContent.Content = new CustomerProfileView();
        }
    }
}
