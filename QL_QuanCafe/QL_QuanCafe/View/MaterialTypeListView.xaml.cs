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
    /// Interaction logic for MaterialTypeListView.xaml
    /// </summary>
    public partial class MaterialTypeListView : Page
    {
        MaterialTypeListViewModel materialList = new MaterialTypeListViewModel();
        Frame CurrentContent, MainContent;
        string employeeId = Properties.Settings.Default ["user"].ToString();
        public MaterialTypeListView()
        {
            InitializeComponent();
        }
        public MaterialTypeListView(Frame MaterialContent, Frame MainContent)
        {
            InitializeComponent();
            MaterialContent.Content = this;
            this.MainContent = MainContent;
            this.CurrentContent = MaterialContent;
        }

        private void InsertMaterialImportData()
        {
            materialList.insertImportMaterialData(employeeId, 0);
            int importId = materialList.GetImportId();
            Properties.Settings.Default ["importId"] = importId.ToString();
        }

        private void btnTraditionalCf_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "01";
            CurrentContent.Content = new MaterialTypeItemView(MainContent);
        }

        private void btnIce_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "02";
            CurrentContent.Content = new MaterialTypeItemView(MainContent);
        }

        private void btnSmoothie_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "03";
            CurrentContent.Content = new MaterialTypeItemView(MainContent);
        }

        private void btnIceCream_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "04";
            CurrentContent.Content = new MaterialTypeItemView(MainContent);
        }

        private void btnMachineCf_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "05";
            CurrentContent.Content = new MaterialTypeItemView(MainContent);
        }

        private void btnJuice_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "06";
            CurrentContent.Content = new MaterialTypeItemView(MainContent);
        }

        private void btnTea_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "07";
            CurrentContent.Content = new MaterialTypeItemView(MainContent);
        }
    }
}
