using MyMinesweeper.Model;
using System.Windows;
using System.Windows.Controls;

namespace MyMinesweeper.ViewModel
{
    public class MineField : StackPanel
    {
        static MineField()
        {
            CellDataProviderProperty =
                DependencyProperty.Register(
                    nameof(CellDataProvider),
                    typeof(StackPanel),
                    typeof(MineField),
                    new FrameworkPropertyMetadata(
                        Map.GamePanel,
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        OnFillingChanged));
        }

        public static readonly DependencyProperty CellDataProviderProperty;

        public StackPanel CellDataProvider
        {
            get => (StackPanel) GetValue(CellDataProviderProperty);

            set => SetValue(CellDataProviderProperty, value);
        }

        private static void OnFillingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var stackPanel = (StackPanel) d;

            stackPanel.Children.Clear();

            stackPanel.Children.Add((StackPanel) e.NewValue);
        }
    }
}