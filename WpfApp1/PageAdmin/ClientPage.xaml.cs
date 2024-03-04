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
    public partial class ClientPage : Page
    {
        private List<ClientEntity> _clients = new List<ClientEntity>();
        public ClientPage()
        {
            InitializeComponent();
            GridClient.LoadingRow += GridClient_LoadingRow;
            init();            
        }

        private async void init()
        {
            _clients.Clear();
            var repository = new ClientRepository();            
            var clients = await repository.GetAllAsync();

            var repositoryOrganizacia = new OrganizaciaRepository();
            var roles = await repositoryOrganizacia.GetAllAsync();

            var repositoryPredprinimatel = new PredprinimatelRepository();
            var predprinimatels = await repositoryPredprinimatel.GetAllAsync();

            Hashtable hashtable = new Hashtable();
            Hashtable hashtable1 = new Hashtable();

            foreach (var item in roles)
            {
                hashtable.Add(item.idOrganizacia, item);

            }
            foreach (var item in predprinimatels)
            {
                hashtable1.Add(item.idPredprinimatel, item);
            }
            foreach (var item in clients)
            {
                item.Organizacia = (OrganizaciaEntity)hashtable[item.idOrganizacia];
                item.Predprinimatel = (PredprinimatelEntity)hashtable1[item.idPredprinimatel];
            }          
            GridClient.ItemsSource = clients;

            TxbNaideno.Text = clients.Count().ToString();
            TxbVsego.Text = clients.Count().ToString();
            _clients.AddRange(clients);

        }
        private void AddRedClientWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                init();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddRedClientWindow addRedClientWindow = new AddRedClientWindow();
            addRedClientWindow.IsVisibleChanged += AddRedClientWindow_IsVisibleChanged;
            addRedClientWindow.ShowDialog();
        }
        private void BtnRerdact_Click(object sender, RoutedEventArgs e)
        {
            ClientEntity client = (sender as Button).DataContext as ClientEntity;
            AddRedClientWindow addRedClientWindow = new AddRedClientWindow(client);
            addRedClientWindow.IsVisibleChanged += AddRedClientWindow_IsVisibleChanged;
            addRedClientWindow.ShowDialog();
        }

        private async void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            ClientEntity client = (sender as Button).DataContext as ClientEntity;
            MessageBoxResult result = MessageBox.Show($"Вы точно уверены, что хотите удалить запись? Вернуть данные будет невозможно.", "Внимание!", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                ClientRepository clientRepository = new ClientRepository();
                await clientRepository.DeleteAsync(client.idClient);
                init();
            }
        }       

        private void IconTextBox_ChangedEvent(object sender, EventArgs e)
        {
            string text = txbPoisk.Finder.Text.ToLower();
            List<ClientEntity> clients = _clients.Where(x => x.Familia.ToLower().Contains(text)).ToList();
            GridClient.ItemsSource = clients;
            TxbNaideno.Text = clients.Count.ToString();
        }

        private void GridClient_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.GetIndex() % 2 == 1)
            {
                e.Row.Background = new SolidColorBrush(Colors.AliceBlue);
            }
        }
    }
}
