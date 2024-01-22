﻿using System;
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
            init();
        }
        private async void init()
        {
            _product.Clear();
            var repository = new ProductReposirory();
           var product = await repository.GetAllAsync();

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
            foreach (var item in product)
            {
                item.Categoria = (CategoriaEntity)hashtable[item.idСategory];
                item.Razreshenie = (RazreshenieEntity)hashtable1[item.idRazreshenie];
            }
            ProductGrid.ItemsSource = product;

            TxbNaideno.Text = product.Count().ToString();
            TxbVsego.Text = product.Count().ToString();
            _product.AddRange(product);
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
            AddRedProductWindow add = new AddRedProductWindow(null);
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

        
    }
}