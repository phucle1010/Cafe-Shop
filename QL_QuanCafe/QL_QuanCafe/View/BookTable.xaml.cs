﻿using System;
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

        }
    }
}
