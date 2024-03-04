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
        private List<UserEntity> _users = new List<UserEntity>();
        public UserPage()
        {
            InitializeComponent();
            GridUser.LoadingRow += GridUser_LoadingRow;
            init();
        }
        private async void init()
        {
            var repository = new UserRepository();
            var users = await repository.GetAllAsync();

            TxbNaideno.Text = users.Count().ToString();
            TxbVsego.Text = users.Count().ToString();

            GridUser.ItemsSource = users;
            _users.AddRange(users);
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
        private void IconTextBox_ChangedEvent(object sender, EventArgs e)
        {
            string text = txbPoisk.Finder.Text.ToLower();
            List<UserEntity> clients = _users.Where(x => x.Familia.ToLower().Contains(text)).ToList();
            GridUser.ItemsSource = clients;
            TxbNaideno.Text = clients.Count.ToString();
        }

        private void GridUser_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.GetIndex() % 2 == 1)
            {
                e.Row.Background = new SolidColorBrush(Colors.AliceBlue);
            }
        }
    }
}
