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
using WpfApp1.Models;
using WpfApp1.PageAdmin;
using WpfApp1.PageManager;
using WpfApp1.Repositories;

namespace WpfApp1.Avtorizacia
{
    /// <summary>
    /// Логика взаимодействия для PageAvtoriz.xaml
    /// </summary>
    public partial class PageAvtoriz : Page
    {
        public PageAvtoriz()
        {
            InitializeComponent();
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txbLogin.Focus();
        }

        private void txbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txbLogin.Text) && txbLogin.Text.Length > 0)
            {
                textLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                textLogin.Visibility = Visibility.Visible;                
            }
        }


        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txbPassword.Focus();
        }

        private void txbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txbPassword.Password) && txbPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txbLogin.Text) && !string.IsNullOrEmpty(txbPassword.Password))
            {
                MessageBox.Show("Добро пожаловать!");                
            }
            NavigationService.Navigate(new GlavnayaAdmin());

        }     

        private void BtbManager_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txbLogin.Text) && !string.IsNullOrEmpty(txbPassword.Password))
            {
                MessageBox.Show("Добро пожаловать!");               
            }
            NavigationService.Navigate(new GlavnayaManager());

        }      
        
    }
}