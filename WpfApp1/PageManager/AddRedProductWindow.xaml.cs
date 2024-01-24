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
using System.Xml.Linq;
using WpfApp1.Models;
using WpfApp1.Repositories;

namespace WpfApp1.PageManager
{
    public partial class AddRedProductWindow : Window
    {
        public AddRedProductWindow(ProductEntity product)
        {
            InitializeComponent();
            entity = product;
            init();
           
        }
        private async void init()
        {
            var repository = new CategoriaRepository();
            cmbCategoria.ItemsSource = await repository.GetAllAsync();
            var repositoryPred = new RazreshenieRepository();
            cmbRazreshinie.ItemsSource = await repositoryPred.GetAllAsync();
            DateDelet.SelectedDate = DateTime.Now;
            DataContext = entity;
        }

        public AddRedProductWindow() : this(new ProductEntity())
        {

        }

        private ProductEntity entity;

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var repository = new ProductReposirory();
            entity.idСategory = (cmbCategoria.SelectedItem as CategoriaEntity).idCategoria;
            entity.idRazreshenie = (cmbRazreshinie.SelectedItem as RazreshenieEntity).idRazreshenie;

            entity.Partia = Convert.ToInt32(TxbPartia.FinderText.Text);
            entity.Name = TxbName.FinderText.Text;
            entity.Price = Convert.ToInt32(TxbPrice.FinderText.Text);

            entity.Date_delete = DateDelet.SelectedDate;
           
            if (entity.idProduct == 0)
            {
                await repository.PostAsync(entity);
            }
            else
            {
                await repository.PutAsync(entity);
            }
            Close();
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            DateDelet.SelectedDate = null;
        }
    }
}
