using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products;

        public MainWindow()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>();

            Products.Add(new Product()
            {
                Name = "Burger",
                Price = 450,
                Image = "Data/Burger.jpg",
                Category = Category.Food
            });
            Products.Add(new Product()
            {
                Name = "Microwave",
                Price = 2700,
                Image = "Data/Microwave.jpg",
                Category = Category.Appliances
            });
            Products.Add(new Product()
            {
                Name = "Fridge",
                Price = 41000,
                Image = "Data/Fridge.jpg",
                Category = Category.Food
            });
            Products.Add(new Product()
            {
                Name = "Cheeseburger",
                Price = 430,
                Image = "Data/Cheeseburger.jpg",
                Category = Category.Appliances
            });

            lstBox.ItemsSource = Products;
        }
    }
}
