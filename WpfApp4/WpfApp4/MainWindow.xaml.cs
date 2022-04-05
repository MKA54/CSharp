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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rate = Convert.ToDouble(rateDollar.Text);
            var sumDollar = Convert.ToDouble(sumD.Text);

            var resultat = rate * sumDollar;

            resSumD.Text = resultat.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var rate = Convert.ToDouble(rateEuro.Text);
            var sumEuro = Convert.ToDouble(sumE.Text);

            var resultat = rate * sumEuro;

            resSumE.Text = resultat.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var rate = Convert.ToDouble(rateGR.Text);
            var sumEuro = Convert.ToDouble(sumG.Text);

            var resultat = rate * sumEuro;

            resSumG.Text = resultat.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var rate = Convert.ToDouble(rateDr.Text);
            var sumDollar = Convert.ToDouble(sumDr.Text);

            var resultat = rate * sumDollar;

            resSumDr.Text = resultat.ToString();
        }
    }
}