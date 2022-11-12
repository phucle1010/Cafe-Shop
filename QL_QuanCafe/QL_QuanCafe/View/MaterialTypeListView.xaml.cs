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
        Frame CurrentContent;
        public MaterialTypeListView()
        {
            InitializeComponent();
        }
        public MaterialTypeListView(Frame MaterialContent)
        {
            InitializeComponent();
            MaterialContent.Content = this;
            this.CurrentContent = MaterialContent;
        }

        private int RandomId()
        {
            Random rb = new Random();
            return rb.Next(100000, 999999);
        }

        private void InsertMaterialImportData()
        {
            int importId = 0;
            string employeeId = Properties.Settings.Default ["user"].ToString();
            MaterialTypeListViewModel materialList = new MaterialTypeListViewModel();
            do
            {
                importId = RandomId();
            } while ( materialList.insertImportId(importId) > 0 );
            Properties.Settings.Default ["importId"] = importId.ToString();
            materialList.insertImportMaterialData(importId, employeeId, 0);
        }

        private void btnTraditionalCf_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "01";
            CurrentContent.Content = new MaterialTypeItemView();
        }

        private void btnIce_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "02";
            CurrentContent.Content = new MaterialTypeItemView();
        }

        private void btnSmoothie_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "03";
            CurrentContent.Content = new MaterialTypeItemView();
        }

        private void btnIceCream_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "04";
            CurrentContent.Content = new MaterialTypeItemView();
        }

        private void btnMachineCf_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "05";
            CurrentContent.Content = new MaterialTypeItemView();
        }

        private void btnJuice_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "06";
            CurrentContent.Content = new MaterialTypeItemView();
        }

        private void btnTea_Click( object sender, RoutedEventArgs e )
        {
            InsertMaterialImportData();
            Properties.Settings.Default ["materialType"] = "07";
            CurrentContent.Content = new MaterialTypeItemView();
        }
    }
}
