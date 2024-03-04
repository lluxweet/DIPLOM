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

namespace WpfApp1.PageManager
{   
    public partial class ProductPage : Page
    {
        private List<ProductEntity> _product = new List<ProductEntity>();       
        
        public ProductPage()
        {
            InitializeComponent();
            ProductGrid.LoadingRow += ProductGrid_LoadingRow;
            init();
        }
        private async void init()
        {
            _product.Clear();
            var repository = new ProductReposirory();
           var products = await repository.GetAllAsync();

            var repositoryCategoria = new CategoriaRepository();
            var categoria = await repositoryCategoria.GetAllAsync();

            var repositoryRazreshenie = new RazreshenieRepository();
            var razreshenie = await repositoryRazreshenie.GetAllAsync();            

            Hashtable hashtable = new Hashtable();
            Hashtable hashtable1 = new Hashtable();

            foreach (var item in categoria)
            {
                hashtable.Add(item.idCategoria, item);

            }
            foreach (var item in razreshenie)
            {
                hashtable1.Add(item.idRazreshenie, item);
            }
            foreach (var item in products)
            {
                item.Categoria = (CategoriaEntity)hashtable[item.idСategory];
                item.Razreshenie = (RazreshenieEntity)hashtable1[item.idRazreshenie];
            }
            ProductGrid.ItemsSource = products.OrderBy(x=> x.Date_delete);
            
            TxbNaideno.Text = products.Count().ToString();
            TxbVsego.Text = products.Count().ToString();
                      
            _product.AddRange(products);
        }       

        private void txbPoisk_ChangedEvent(object sender, EventArgs e)
        {
            string text = txbPoisk.Finder.Text.ToLower();
            List <ProductEntity> product = _product.Where(x => x.Name.ToLower().Contains(text)).ToList();
            ProductGrid.ItemsSource = product;
            TxbNaideno.Text = product.Count.ToString();
        }
       
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddRedProductWindow add = new AddRedProductWindow();
            add.IsVisibleChanged += Add_IsVisibleChanged;
            add.Show();
        }

        private void Add_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           if (Visibility == Visibility.Visible)
           {
                init();
           }
        }

        private void BtnRerdact_Click(object sender, RoutedEventArgs e)
        {
            AddRedProductWindow add = new AddRedProductWindow((sender as Button).DataContext as ProductEntity);
            add.IsVisibleChanged += Add_IsVisibleChanged;
            add.ShowDialog();
        }               

        private void ProductGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGridRow row = e.Row;
            var product = row.DataContext as ProductEntity;
            if (product.Date_delete != null)
            {
                row.Foreground = new SolidColorBrush(Colors.Gray);                
            }

            if (e.Row.GetIndex() % 2 == 1)
            {
                e.Row.Background = new SolidColorBrush(Colors.AliceBlue);
            }
        }        
        
    }
}
