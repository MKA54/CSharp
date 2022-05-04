using System.Windows;
using MyMinesweeper.Model;
using MyMinesweeper.ViewModel;

namespace MyMinesweeper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(ParentWindow);
        }
    }
}
