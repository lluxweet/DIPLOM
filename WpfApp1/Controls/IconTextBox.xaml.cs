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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Controls
{
    /// <summary>
    /// Логика взаимодействия для IconTextBox.xaml
    /// </summary>
    public partial class IconTextBox : UserControl
    {
        public event EventHandler ChangedEvent;
        public IconTextBox()
        {
            InitializeComponent();   
        }



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(IconTextBox), new PropertyMetadata(""));



        public string TextHint
        {
            get { return (string)GetValue(TextHintProperty); }
            set { SetValue(TextHintProperty, value); }
            
        }


        // Using a DependencyProperty as the backing store for TextHint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextHintProperty =
            DependencyProperty.Register("TextHint", typeof(string), typeof(IconTextBox), new PropertyMetadata(""));



        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(IconTextBox), new PropertyMetadata(null));

        private void textPoisk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Finder.Focus();
        }

        private void txbPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Finder.Text) && Finder.Text.Length > 0)
            {
                HintText.Visibility = Visibility.Collapsed;
            }
            else
            {
                HintText.Visibility = Visibility.Visible;
            }
            ChangedEvent?.Invoke(this, e);

        }
    }
}
