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
using invoiceWPF2.BLL;
using invoiceWPF2.DAL;
using invoiceWPF2.UI;
using invoiceWPF2;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.VisualBasic;

namespace invoiceWPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void customersMenu(object sender, RoutedEventArgs e)
        {
            customers c = new customers();
            c.Show();
        }

        private void productsMenu(object sender, RoutedEventArgs e)
        {
            products p = new products();
            p.Show();
        }

        private void invoiceMenu(object sender, RoutedEventArgs e)
        {
            invoice i = new invoice();
            i.Show();
        }
    }
}
