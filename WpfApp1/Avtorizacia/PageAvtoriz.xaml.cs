using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.PageAdmin;
using WpfApp1.PageManager;
using WpfApp1.Repositories;

namespace WpfApp1.Avtorizacia
{
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

        private async void BtbManager_Click(object sender, RoutedEventArgs e)
        {
            var repository = new UserRepository();          
                     
            string login = txbLogin.Text;
            string password = txbPassword.Password;                       
                                           
            try
            {
                var user = await repository.LoginAsync(login,password);               
                MessageBox.Show("Здравствуйте, " + user.Name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                switch (user.Role.NameRole.ToLower().Trim())
                {
                    case "администратор":
                        
                        NavigationService.Navigate(new GlavnayaAdmin());
                        break;
                    case "менеджер":
                        
                        NavigationService.Navigate(new GlavnayaManager());
                        break;
                    default:
                        MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);                                
                    break;
                }                                
            }
            catch (Exception)
            {
                MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }

        }      
        
    }
}
