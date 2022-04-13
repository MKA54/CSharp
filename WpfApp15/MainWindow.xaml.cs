using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace WpfApp15
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

        private void Clear (object sender, RoutedEventArgs e)
        {
            docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }

        private void Save (object sender, RoutedEventArgs e)
        {
            using (var fs= File.Open("1.xaml", FileMode.Create))
            {
                XamlWriter.Save(docViewer.Document, fs);
            }
        }

        private void Open (object sender, RoutedEventArgs e)
        {
            using (var fs = File.Open("1.xaml", FileMode.Open))
            {
                docViewer.Document = XamlReader.Load(fs) as FlowDocument;
            }
        }
    }
}
