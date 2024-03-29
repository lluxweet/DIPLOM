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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Avtorizacia;
using WpfApp1.Repositories;
using Word = Microsoft.Office.Interop.Word;

namespace WpfApp1.PageManager
{
    /// <summary>
    /// Логика взаимодействия для GlavnayaManager.xaml
    /// </summary>
    public partial class GlavnayaManager : Page
    {
        public GlavnayaManager()
        {
            InitializeComponent();           
            AppFrame.frameMain = FrmMain;

        }     

        private void BtnVixod_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAvtoriz());
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.Navigate(new ProductPage());
        }

        private void BtnProdaja_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.Navigate(new ProdajaPage());
        }        

        private void BtnOtshet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
