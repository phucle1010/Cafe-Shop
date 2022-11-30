using QL_QuanCafe.ViewModel;
using System.Windows.Controls;
using LiveCharts;
using System;

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
            MainContent.Content = new HomeAdminDetailView();
        }

        void LoadData()
        {
            AdminViewModel admin = new AdminViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = admin.getAdminName(userName);   
        }

        private void txtProfile_Click( object sender, System.Windows.Input.MouseButtonEventArgs e )
        {
            MainContent.Content = new AdminProfileView();
        }
    }
}
