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
using System.Windows.Shapes;
using QL_QuanCafe.Model;
using QL_QuanCafe.LocalStore;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for InformationPersonal.xaml
    /// </summary>
    public partial class InformationPersonal_Customer : Window
    {
        public InformationPersonal_Customer()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //CurrentAccount.Ins.setAccount("Hoang Quan");
            string hoten = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"select * from khachhang kh where kh.tendn = '{CurrentAccount.Ins.getAccount()}'").ElementAt(0).TenKH.ToString();
            txt_HoTen.Text = hoten;
            string email = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"select * from khachhang kh where kh.tendn = '{CurrentAccount.Ins.getAccount()}'").ElementAt(0).Email.ToString();
            txt_Email.Text = email;
            string Sdt = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"select * from khachhang kh where kh.tendn = '{CurrentAccount.Ins.getAccount()}'").ElementAt(0).SDT.ToString();
            txt_Sdt.Text = Sdt;
            DateTime date = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"select * from khachhang kh where kh.tendn = '{CurrentAccount.Ins.getAccount()}'").ElementAt(0).NgaySinh.Value;
            date_picker.SelectedDate = date;
            string diemtichluy = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"select * from khachhang kh where kh.tendn = '{CurrentAccount.Ins.getAccount()}'").ElementAt(0).DiemTichLuy.ToString();
            txt_DiemTichLuy.Text = diemtichluy;
            string loaikh = DataProvider.Ins.DB.LOAIKHACHHANGs.SqlQuery($"select * from khachhang kh, loaikhachhang lkh where kh.tendn = '{CurrentAccount.Ins.getAccount()}' and kh.maloaikh = lkh.maloaikh").ElementAt(0).TenLoaiKH.ToString();
            txt_LoaiKhachHang.Text = loaikh;
        }

        private void btn_SaveChange_Click(object sender, RoutedEventArgs e)
        {
            string hoten = txt_HoTen.Text.ToString();
            string email = txt_Email.Text.ToString();
            DateTime date = date_picker.SelectedDate.Value;
            string Sdt = txt_Sdt.Text.ToString();
            if (string.IsNullOrEmpty(hoten))
            {
                MessageBox.Show("Bạn chưa nhập họ tên!", "Thông báo");
            }else if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Bạn chưa nhập email!", "Thông báo");
            }
            else if (string.IsNullOrEmpty(Sdt))
            {
                MessageBox.Show("Bạn chưa nhập số diện thoại!", "Thông báo");
            }else
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"update khachhang set tenkh = N'{hoten}', sdt = N'{Sdt}', ngaysinh = N'{date}', email = N'{email}' where tendn = '{CurrentAccount.Ins.getAccount()}'");
                MessageBox.Show("Bạn đã cập nhật thành công!", "Thông báo");
            }
        }
        
    }
}
