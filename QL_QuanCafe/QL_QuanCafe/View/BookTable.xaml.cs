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
using QL_QuanCafe.ViewModel;

namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for BookTable.xaml
    /// </summary>
    public partial class BookTable : Window
    {
        public BookTable()
        {
            InitializeComponent();
        }

        private void btn_HuyBo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, RoutedEventArgs e)
        {
            string maban = DataProvider.Ins.DB.BANs.SqlQuery($"select * from Ban where tenban = '{cbb_Ban.SelectedItem.ToString()}'").ElementAt(0).MaBan.ToString();
            string makh = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"select * from Khachhang where tendn = '{CurrentAccount.Ins.getAccount()}'").ElementAt(0).MaKH.ToString();
            DateTime time = PresetTimePicker.SelectedTime.Value;
            string ghichu = txt_GhiChu.Text;
            if (time == null)
            {
                MessageBox.Show("Bạn chưa chọn thời gian đến", "Thông báo");
            }
            else if (string.IsNullOrEmpty(maban))
            {
                MessageBox.Show("Bạn chưa chọn bàn!", "Thông báo");
            }
            else
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand($"insert into datban (maban, makh, ghichu, giodat) values ('{maban}','{makh}','{ghichu}', '{time}')");
                MessageBox.Show("Bạn đã đặt bàn, vui lòng chờ nhân viên xác nhận đặt bàn!", "Thông báo");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentAccount.Ins.setAccount("Hoang Quan");
            string hoten = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"select * from khachhang kh where kh.tendn = '{CurrentAccount.Ins.getAccount()}'").ElementAt(0).TenKH.ToString();
            txt_khachhang.Text = hoten;
            string Sdt = DataProvider.Ins.DB.KHACHHANGs.SqlQuery($"select * from khachhang kh where kh.tendn = '{CurrentAccount.Ins.getAccount()}'").ElementAt(0).SDT.ToString();
            txt_Sdt.Text = Sdt;
            loadBan();
        }
        private void loadBan()
        {
            int count = DataProvider.Ins.DB.BANs.Count();
            for (int i = 0; i < count; i++)
            {
                string a = DataProvider.Ins.DB.BANs.SqlQuery("select * from Ban where trangthai != 1").ElementAt(i).TenBan.ToString();
                cbb_Ban.Items.Add(a);
            }
        }
    }
}
