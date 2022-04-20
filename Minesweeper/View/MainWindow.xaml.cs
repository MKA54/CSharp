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
using System.Windows.Shapes;
using Minesweeper.ViewModel;

namespace Minesweeper.View
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            controller = new MinesweeperController(_level, this);
        }

        private int _level;
        private MinesweeperController controller;

        public void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            _level = comboBox.SelectedIndex;
        }
    }
}
