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
    /// Interaction logic for ManageOrderFoodView.xaml
    /// </summary>
    public partial class ManageOrderFoodView : Page
    {
        public ManageOrderFoodView()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            AdminViewModel admin = new AdminViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = admin.getAdminName(userName);
        }

        private void dtOrderFood_MouseDoubleClick( object sender, MouseButtonEventArgs e )
        {

        }

        private void btnDetail_Click( object sender, RoutedEventArgs e )
        {

        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {

        }

       
    }
}
