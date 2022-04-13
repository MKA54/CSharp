using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var styles = new List<string>() {"Светлая тема", "Тёмная тема"};
            styleBox.ItemsSource = styles;
            styleBox.SelectionChanged += ThemeChange;
            styleBox.SelectedIndex = 0;
        }

        private const string FileFormat = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            var styleIndex = styleBox.SelectedIndex;

            var uriStyle = new Uri("LightStyle.xaml", UriKind.Relative);

            if (styleIndex == 1)
            {
                uriStyle = new Uri("DarkStyle.xaml", UriKind.Relative);
            }

            var listsResource = Application.LoadComponent(new Uri("Lists.xaml", UriKind.Relative)) as ResourceDictionary;
            var styleResource = Application.LoadComponent(uriStyle) as ResourceDictionary;

            Application.Current.Resources.Clear();

            Application.Current.Resources.MergedDictionaries.Add(listsResource);
            Application.Current.Resources.MergedDictionaries.Add(styleResource);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight.Equals(FontWeights.Bold))
            {
                textBox.FontWeight = FontWeights.Normal;

                return;
            }

            textBox.FontWeight = FontWeights.Bold;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle.Equals(FontStyles.Italic))
            {
                textBox.FontStyle = FontStyles.Normal;

                return;
            }

            textBox.FontStyle = FontStyles.Italic;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations == null)
            {
                textBox.TextDecorations = TextDecorations.Baseline;

                return;
            }

            textBox.TextDecorations = null;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox == null)
            {
                return;
            }

            textBox.Foreground = Brushes.Black;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Red;
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FileFormat;

            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = FileFormat;

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}