using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WpfApp1.Avtorizacia;
using WpfApp1.PageAdmin;

namespace WpfApp1
{    
    public partial class MainWindow : Window
    {
        private Hashtable hashtable = new Hashtable();
        public MainWindow()
        {
            InitializeComponent();
            hashtable.Add(Pages.PageAvtoriz,new PageAvtoriz());
            OpenPage(Pages.PageAvtoriz);
        }

        public enum Pages
        {
            PageAvtoriz
        }

        void OpenPage(Pages page)
        {
            frame.Navigate(hashtable[page]);

        }

        
    }

        
}
