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
using WpfApp1.Models;
using WpfApp1.Repositories;

namespace WpfApp1.PageAdmin
{ 
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            init();
        }
        private async void init()
        {
            var repository = new UserRepository();
            var users = await repository.GetAllAsync();

            GridUser.ItemsSource = users;

        }
        private void AddRedUserWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                init();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddRedUserWindow addRedUserWindow = new AddRedUserWindow();
            addRedUserWindow.IsVisibleChanged += AddRedUserWindow_IsVisibleChanged;
            addRedUserWindow.ShowDialog();
        }

        private void BtnRerdact_Click(object sender, RoutedEventArgs e)
        {
            UserEntity user = (sender as Button).DataContext as UserEntity;
            AddRedUserWindow addRedUserWindow = new AddRedUserWindow(user);
            addRedUserWindow.IsVisibleChanged += AddRedUserWindow_IsVisibleChanged;
            addRedUserWindow.ShowDialog();            
        }

        private async void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            UserEntity user = (sender as Button).DataContext as UserEntity;
            MessageBoxResult result = MessageBox.Show($"Вы точно уверены, что хотите удалить запись? Вернуть данные будет невозможно.", "Внимание!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                UserRepository userRepository = new UserRepository();
                await userRepository.DeleteAsync(user.idUser);
                init();
            }            

        }
        
    }
}
