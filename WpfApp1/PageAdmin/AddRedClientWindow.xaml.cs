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
    /// Логика взаимодействия для AddRedClientWindow.xaml
    /// </summary>
    public partial class AddRedClientWindow : Window
    {
        public AddRedClientWindow(ClientEntity clientEntity)
        {
            InitializeComponent();
            init();
            entity = clientEntity;
        }

        private async void init()
        {
            var repository = new OrganizaciaRepository();
            cmbOrganiz.ItemsSource = await repository.GetAllAsync();
            var repositoryPred = new PredprinimatelRepository();
            cmbPredprim.ItemsSource = await repositoryPred.GetAllAsync();
            DataContext = entity;
        }

        public AddRedClientWindow() : this(new ClientEntity())
        {

        }
        private ClientEntity entity;

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var repository = new ClientRepository();
                entity.idOrganizacia = (cmbOrganiz.SelectedItem as OrganizaciaEntity).idOrganizacia;
                entity.idPredprinimatel = (cmbPredprim.SelectedItem as PredprinimatelEntity).idPredprinimatel;
                entity.Familia = TxbFamilia.Text;
                entity.Name = TxbName.Text;
                entity.Otchestvo = TxbOtchestvo.Text;
                entity.Phone = TxbPhone.Text;
                entity.Passport = TxbPassport.Text;
                if (entity.idClient == 0)
                {
                    await repository.PostAsync(entity);
                }
                else
                {
                    await repository.PutAsync(entity);
                }
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                throw;
            }
            
        }
    }
}
