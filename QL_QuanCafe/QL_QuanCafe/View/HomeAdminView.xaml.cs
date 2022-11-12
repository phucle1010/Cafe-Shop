using QL_QuanCafe.ViewModel;
using System.Windows.Controls;

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
        }
        void LoadData()
        {
            AdminViewModel admin = new AdminViewModel();
            string userName = Properties.Settings.Default ["user"].ToString();
            tbUserName.Text = admin.getAdminName(userName);
        }
    }
}
