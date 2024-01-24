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

namespace WpfApp1.PageManager
{
    /// <summary>
    /// Логика взаимодействия для AddRedProdajaWindow.xaml
    /// </summary>
    public partial class AddRedProdajaWindow : Window
    {
        public AddRedProdajaWindow(ProdajaEntity prodaja)
        {
            InitializeComponent();
            entity = prodaja;
            init();
        }
        private async void init()
        {
            var product = new ProductReposirory();
            cmbName.ItemsSource = await product.GetAllAsync();

            var client = new ClientRepository();
            cmbClient.ItemsSource = await client.GetAllAsync();

            var statusOplata = new StatusOIplataRepository();
            cmbStatusOplata.ItemsSource = await statusOplata.GetAllAsync();

            var typeplata = new TypeOplataRepository();
            cmbTip.ItemsSource = await typeplata.GetAllAsync();

            var status = new StatusRepository();
            cmbStatus.ItemsSource = await status.GetAllAsync();

            DataContext = entity;
        }

        public AddRedProdajaWindow(): this(new ProdajaEntity())
        { 

        }
        private ProdajaEntity entity;

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var repository = new ProdajaRepository();
        
            entity.Colichestvo = Convert.ToInt32(TxbColichestvo.FinderText.Text);

            if (entity.id == 0)
            {
                await repository.PostAsync(entity);
            }
            else
            {
                await repository.PutAsync(entity);
            }
            Close();
        }
    }
}
