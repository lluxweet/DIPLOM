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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.Repositories;
using Word = Microsoft.Office.Interop.Word;

namespace WpfApp1.PageManager
{
    /// <summary>
    /// Логика взаимодействия для ProdajaPage.xaml
    /// </summary>
    public partial class ProdajaPage : Page
    {
        private List<ProdajaEntity> _prodaja = new List<ProdajaEntity>();   
        public ProdajaPage()
        {
            InitializeComponent();
            init();
        }

        private async void init()
        {
            _prodaja.Clear();          
           
            var repository = new ProdajaRepository();
            var prodaja = await repository.GetAllAsync();

            var repositoryProduct = new ProductReposirory();
            var product = await repositoryProduct.GetAllAsync();

            var repositoryClient = new ClientRepository();
            var client = await repositoryClient.GetAllAsync();

            var repositoryStatus = new StatusRepository();
            var status = await repositoryStatus.GetAllAsync();

            var repositoryStatusOplata = new StatusOIplataRepository();
            var statusoplata = await repositoryStatusOplata.GetAllAsync();

            var repositoryTypeOplata = new TypeOplataRepository();
            var typeOplata = await repositoryTypeOplata.GetAllAsync();

            Hashtable hashtable = new Hashtable();       
            foreach (var item in product)
            {
                hashtable.Add(item.idProduct, item);
            }

            Hashtable hashtable1 = new Hashtable();
            foreach (var item in client)
            {
                hashtable1.Add(item.idClient, item);
            }

            Hashtable hashtable2 = new Hashtable();
            foreach (var item in status)
            {
                hashtable2.Add(item.idstatus, item);
            }
            Hashtable hashtable3 = new Hashtable();
            foreach (var item in statusoplata)
            {
                hashtable3.Add(item.idStatus, item);
            }
            Hashtable hashtable4 = new Hashtable();
            foreach (var item in typeOplata)
            {
                hashtable4.Add(item.idTypeOplata, item);
            }
            foreach (var item in prodaja)
            {
                item.Product = (ProductEntity)hashtable[item.idProduct];
                item.Client = (ClientEntity)hashtable1[item.idClient];
                item.Status = (StatusEntity)hashtable2[item.idStatus];
                item.StatusOplata = (StatusoplataEntity)hashtable3[item.idStatusOplata];
                item.Typeoplata = (TypeoplataEntity)hashtable4[item.idTipOplata];
            }

            GridProdaja.ItemsSource = prodaja;

            TxbNaideno.Text = prodaja.Count().ToString();
            TxbVsego.Text = prodaja.Count().ToString();
            _prodaja.AddRange(prodaja);
            txbSumma.Text = prodaja.Sum(x => x.Stoimost).ToString("C2");            
        }

        private void txbPoisk_ChangedEvent(object sender, EventArgs e)
        {
            string text = txbPoisk.Finder.Text.ToLower();
            List<ProdajaEntity> product = _prodaja.Where(x => x.Product.Name.ToLower().Contains(text)).ToList();
            GridProdaja.ItemsSource = product;
            TxbNaideno.Text = product.Count.ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddRedProdajaWindow prodaja = new AddRedProdajaWindow();
            prodaja.IsVisibleChanged += Prodaja_IsVisibleChanged;
            prodaja.ShowDialog();        
        }

        private void Prodaja_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           if(Visibility == Visibility.Visible)
           {
                init();
           }
        }

        private void BtnRerdact_Click(object sender, RoutedEventArgs e)
        {
            AddRedProdajaWindow prodaja = new AddRedProdajaWindow((sender as Button).DataContext as ProdajaEntity);
            prodaja.IsVisibleChanged += Prodaja_IsVisibleChanged;
            prodaja.ShowDialog();
        }

        private void ReplaceWordStub(string stubReplaceplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubReplaceplace, ReplaceWith: text);
        }

        private void BtnOtchet_Click(object sender, RoutedEventArgs e)
        {           
            ProdajaEntity prodaja = (sender as Button).DataContext as ProdajaEntity;
            ClientEntity client = (sender as Button).DataContext as ClientEntity;

            var wordApp = new Word.Application();
            Word.Document document = wordApp.Documents.Open(@"C:\Users\мыших\Desktop\отчет.docx");

            ReplaceWordStub("{ID}", prodaja.id.ToString(), document);

            ReplaceWordStub("{TOVAR}", prodaja.Product.Name.ToString(), document);
            ReplaceWordStub("{PRICE}", prodaja.Product.Price.ToString(), document);
           
            ReplaceWordStub("{FAMILIA}", prodaja.Client.Familia.ToString(), document);
            ReplaceWordStub("{NAME}", prodaja.Client.Name.ToString(), document);
            ReplaceWordStub("{OTCHESTVO}", prodaja.Client.Otchestvo.ToString(), document);
            ReplaceWordStub("{PASSPORT}", prodaja.Client.Passport.ToString(), document);

            ReplaceWordStub("{FAMILIA1}", prodaja.Client.Familia.ToString(), document);
            ReplaceWordStub("{NAME1}", prodaja.Client.Name.ToString(), document);
            ReplaceWordStub("{OTCHESTVO1}", prodaja.Client.Otchestvo.ToString(), document);
            ReplaceWordStub("{PASSPORT1}", prodaja.Client.Passport.ToString(), document);

            ReplaceWordStub("{COLVO}", prodaja.Colichestvo.ToString(), document);            
            ReplaceWordStub("{SUMMA}", prodaja.Stoimost.ToString(), document);
            wordApp.Visible = true;            
        }
    }
}
