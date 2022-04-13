using System;
using System.Windows;

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
            resSumD.Text = Result(Convert.ToDouble(rateDollar.Text), Convert.ToDouble(sumD.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            resSumE.Text = Result(Convert.ToDouble(rateEuro.Text), Convert.ToDouble(sumE.Text));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            resSumG.Text = Result(Convert.ToDouble(rateGR.Text), Convert.ToDouble(sumG.Text));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            resSumDr.Text = Result(Convert.ToDouble(rateDr.Text), Convert.ToDouble(sumDr.Text));
        }

        private static string Result(double rate, double sum) => (rate * sum).ToString();
    }
}