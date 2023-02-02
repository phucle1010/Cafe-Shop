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
    /// Interaction logic for ImportMaterialView.xaml
    /// </summary>
    public partial class ImportMaterialView : Page
    {
        Frame MainContent;
        CafeShopEntities entity = new CafeShopEntities();
        string type;

        public ImportMaterialView(Frame MainContent, string type )
        {
            InitializeComponent();
            this.MainContent = MainContent;
            LoadData();
            this.type = type;
        }
        void LoadData()
        {
            if ( type == "update" )
            {
                string userName = Properties.Settings.Default ["user"].ToString();
                tbUserName.Text = entity.NHANVIENs.Where(employee => employee.MaNV.ToString() == userName).FirstOrDefault().TenNV;

            }
            else
            {
                string userName = Properties.Settings.Default ["user"].ToString();
                AdminViewModel admin = new AdminViewModel();
                tbUserName.Text = admin.getAdminName(userName);
            }
            CategoryMaterialType.Navigate(new MaterialTypeListView(CategoryMaterialType, MainContent));
        }
    }
}
