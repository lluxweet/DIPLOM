using System;
using System.Collections;
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
using WpfApp1.Models;
using WpfApp1.Repositories;

namespace WpfApp1.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для GlavnayaAdmin.xaml
    /// </summary>
    public partial class GlavnayaAdmin : Page
    {
        public GlavnayaAdmin()
        {
            InitializeComponent();
            AppFrame.frameMain = FrmMain;

        }          

        private void BtnVixod_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAvtoriz());
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.Navigate(new UserPage());
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.Navigate(new ClientPage());
        }
    }
}
