using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            //TxbPhone.PreviewTextInput += TxbPhone_PreviewTextInput;
            TxbPhone.TextChanged += txbPhone_TextChanged;

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

        private void textPhone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxbPhone.Focus();
        }     

        private void txbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxbPhone.Text) && TxbPhone.Text.Length > 0)
            {
                textPhone.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPhone.Visibility = Visibility.Visible;
            }

            string phoneNumber = TxbPhone.Text;

            // Удаляем все символы, кроме цифр
            string numberOnly = "";
            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch))
                {
                    numberOnly += ch;
                }
            }

            // Проверяем и применяем маску
            if (numberOnly.Length > 0)
            {
                string maskedNumber = string.Format("{0:(###) ###-####}", double.Parse(numberOnly));
                TxbPhone.Text = maskedNumber;
                TxbPhone.CaretIndex = maskedNumber.Length;
            }
        }

        private void TxbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
