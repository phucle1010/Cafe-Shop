using QL_QuanCafe.ViewModel;
using System.Windows.Controls;
using LiveCharts;
using System;
using QL_QuanCafe.Model;
using System.Linq;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for HomeAdminView.xaml
    /// </summary>
    public partial class HomeAdminView : Page
    {
        public HomeAdminView()
        {
            InitializeComponent();
            LoadData();
            MainContent.Navigate(new HomeAdminDetailView());
        }

        void LoadData()
        {
            CafeShopEntities entity = new CafeShopEntities();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = entity.NHANVIENs.Where(employee => employee.MaNV.ToString() == userName).FirstOrDefault().TenNV;
        }

        private void txtProfile_Click( object sender, System.Windows.Input.MouseButtonEventArgs e )
        {
            AdminProfileView profileView = new AdminProfileView();
            profileView.Show();
            profileView.Closed += ProfileView_Closed;
        }

        private void ProfileView_Closed( object sender, EventArgs e )
        {
            MainContent.Navigate(new HomeAdminDetailView());
        }
    }
}
