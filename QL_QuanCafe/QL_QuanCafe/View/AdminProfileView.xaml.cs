using QL_QuanCafe.Model;
using QL_QuanCafe.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace QL_QuanCafe.View
{
    /// <summary>
    /// Interaction logic for AdminProfileView.xaml
    /// </summary>
    public partial class AdminProfileView : Window
    {
        AdminProfileViewModel adminProfile = new AdminProfileViewModel();
        string username = Properties.Settings.Default ["user"].ToString();
        string selectedFileName;
        public AdminProfileView()
        {
            InitializeComponent();
            LoadData();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage( IntPtr hWnd, int wMsg, int wParam, int lParam );
        private void btnMaximize_Click( object sender, RoutedEventArgs e )
        {
            if ( this.WindowState == WindowState.Normal )
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click( object sender, RoutedEventArgs e )
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click( object sender, RoutedEventArgs e )
        {
            this.Close();
        }

        private void pnlControlBar_MouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter( object sender, System.Windows.Input.MouseEventArgs e )
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private byte [] converImgToByte()
        {
            FileStream fs;
            fs = new FileStream(selectedFileName, FileMode.Open, FileAccess.Read);
            byte [] picbyte = new byte [fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

        private Image ByteToImg( string byteString )
        {
            byte [] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            //Image image = Image.FromStream(ms, true);
            return new Image();
        }

        private void btnAddImage_Click( object sender, RoutedEventArgs e )
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if ( dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                selectedFileName = dlg.FileName;
                ImageSource imageSource = new BitmapImage(new Uri(selectedFileName));
                ImageViewer.Source = imageSource;
            }
        }

        private void btnSubmit_Click( object sender, RoutedEventArgs e )
        {
            if ( adminProfile.UpdateProfile(txtName.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text, selectedFileName) == 1 )
            {
                this.Close();
                System.Windows.Forms.Application.Restart();
                Environment.Exit(0);
            }
        }

        void LoadData()
        {
            NHANVIEN e = adminProfile.EmployeeInfo(username);

            txtId.Text = e.MaNV.ToString();
            txtName.Text = e.TenNV.ToString();
            txtGender.Text = Boolean.Parse(e.GioiTinh.ToString()) == true ? "Nam" : "Nữ";
            txtEmail.Text = e.Email.ToString();
            txtPhone.Text = e.SDT.ToString();
            txtAddress.Text = e.DiaChi.ToString();
            txtEntryDay.Text = e.NgayVaoLam.ToString();
            txtWorkshift.Text = e.MaCaLV.ToString();

            if (e.AnhDaiDien != "")
            {
                ImageSource imageSource = new BitmapImage(new Uri(e.AnhDaiDien));
                ImageViewer.Source = imageSource;
            }
        }

        
    }
}
