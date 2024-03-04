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
using WpfApp1.Models;
using WpfApp1.Repositories;

namespace WpfApp1.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для AddRedUserWindow.xaml
    /// </summary>
    public partial class AddRedUserWindow : Window
    {
        public AddRedUserWindow(UserEntity user)
        {
            InitializeComponent();
            init();
            entity = user;
           
            cmbRole.SelectionChanged += cmbRole_SelectionChanged;
                      
        }
        private async void init()
        {
            var repository = new RoleRepository();
            cmbRole.ItemsSource = await repository.GetAllAsync();
            DataContext = entity;
        }

        public AddRedUserWindow():this(new UserEntity())
        {

        }

        private UserEntity entity;       
        
        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var repository = new UserRepository();
            entity.idRole = (cmbRole.SelectedItem as RoleEntity).idRole;
            entity.Familia = TxbFamilia.Text;
            entity.Name = TxbName.Text;
            entity.Otchestvo = TxbOtchestvo.Text;
            entity.Login = TxbLogin.Text;
            entity.Password = TxbPssword.Text;
           if(entity.idUser == 0)
            {
                await repository.PostAsync(entity);
            }
            else
            {
                await repository.PutAsync(entity);
            }
            Close();
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserEntity user = new UserEntity();
            if (user.idUser == 1)
            {
                cmbRole.SelectionChanged -= cmbRole_SelectionChanged; // Удаляем обработчик события, чтобы предотвратить изменение значения

                // Возвращаем предыдущее выбранное значение, чтобы ComboBox оставался неизменным
                if (cmbRole.Items.Count > 1)
                {
                    cmbRole.SelectedIndex = 1; // Можно выбрать любое другое доступное значение
                }

                cmbRole.SelectionChanged += cmbRole_SelectionChanged; // Восстанавливаем обработчик события
            }

        }
        
    }
}
