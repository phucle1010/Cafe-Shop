using QL_QuanCafe.Model;
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
    /// Interaction logic for CustomerItemView.xaml
    /// </summary>
    public partial class CustomerItemView : UserControl
    {
        private KHACHHANG customer;
        public CustomerItemView(KHACHHANG customer)
        {
            InitializeComponent();
            this.customer = customer;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            if (customer.AnhDaiDien != null)
            {
                ImageViewer.Source = new BitmapImage(new Uri(customer.AnhDaiDien));
            }
            tbName.Text = customer.TenKH;
            tbPhone.Text = customer.SDT;
            tbEmail.Text = customer.Email;
            tbAddress.Text = customer.DiaChi;
        }

    }
}
