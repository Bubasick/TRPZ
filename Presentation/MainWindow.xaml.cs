using BusinessLogic;
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
using DataManagement;
namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
           Provider provider = new Provider(new GetData());
           var products = provider.SendProducts();
           var stores = provider.SendStores();
           InitializeComponent();
           ProductDataBinding.ItemsSource = products;
           StoreDataBinding.ItemsSource = stores;
        }

        
    }
}
