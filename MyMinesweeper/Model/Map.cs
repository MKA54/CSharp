using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyMinesweeper.Model
{
    public class Map
    {
        public const int _width = 6;
        public const int _height = 6;
        public const int cellSize = 35;
        private const int ButtonImageOffsetStep = 16;
        private const int cellsCount = _width * _height;
        private const int bombsCount = 2;

        public static readonly Uri ButtonTypeUri = new Uri("C:\\Users\\Админ\\source\\repos\\CSharp\\MyMinesweeper\\Images\\ButtonTypes.bmp", UriKind.Absolute);
        private static BitmapSource _buttonTypesImageSource;
        private static bool _isFirstStep;
        private static Point _firstCoord;
        private static int _currentPictureToSet;
        private static int _openCellsCount;
        private static StackPanel _gamePanel;

        public static int[,] map = new int[_height, _width];
        public static Button[,] Buttons = new Button[_height, _width];

        public static void Init(StackPanel gamePanel)
        {
            _gamePanel = gamePanel;
            _isFirstStep = true;
            _currentPictureToSet = 0;
            _openCellsCount = 0;
            _buttonTypesImageSource = new BitmapImage(ButtonTypeUri);

            InitMap();
            InitButtons();
        }

        private static void InitMap()
        {
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    map[i, j] = 0;
                }
            }
        }

        private static void InitButtons()
        {
            for (var i = 0; i < _height; i++)
            {
                var row = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Orientation = Orientation.Horizontal
                };

                for (var j = 0; j < _width; j++)
                {
                    var button = new Button
                    {
                        Width = cellSize,
                        Height = cellSize,

                        Content = FindNeededImage(0)
                    };

                    button.PreviewMouseLeftButtonDown += OnLeftButtonPressed;
                    button.MouseRightButtonDown += OnRightButtonPressed;
                    button.Tag = $"{i},{j}";

                    Buttons[i, j] = button;

                    row.Children.Add(button);
                }

                _gamePanel.Children.Add(row);
            }
        }

        private static void SeedMap()
        {
            var r = new Random();

            for (var i = 0; i < bombsCount; i++)
            {
                var posI = r.Next(0, _height - 1);
                var posJ = r.Next(0, _width - 1);

                while (map[posI, posJ] == -1 || (Math.Abs(posI - _firstCoord.Y) <= 1 && Math.Abs(posJ - _firstCoord.X) <= 1))
                {
                    posI = r.Next(0, _height - 1);
                    posJ = r.Next(0, _width - 1);
                }

                map[posI, posJ] = -1;
            }
        }

        private static void OnLeftButtonPressed(object v, RoutedEventArgs e)
        {
            var button = (Button)v;

            var tag = button.Tag.ToString();
            var tagSplitted = tag.Split(',');
            var state = new int[] { Convert.ToInt32(tagSplitted[0]), Convert.ToInt32(tagSplitted[1]) };

            if (_isFirstStep)
            {
                _firstCoord = new Point(state[0], state[1]);
                _isFirstStep = false;

                SeedMap();
                CountCellBomb();
            }

            OpenCells(state[0], state[1]);

            if (IsVictory())
            {
                ShowAllBombs(state[0], state[1]);
                MessageBox.Show("Победа!" + _openCellsCount);
                Restart();
            }

            if (map[state[0], state[1]] != -1)
            {
                return;
            }

            ShowAllBombs(state[0], state[1]);
            MessageBox.Show("Поражение!" + _openCellsCount);
            Restart();
        }

        public static void Restart()
        {
            _gamePanel.Children.Clear();
            Init(_gamePanel);
        }

        private static void OnRightButtonPressed(object v, RoutedEventArgs e)
        {
            var button = (Button)v;

            _currentPictureToSet++;
            _currentPictureToSet %= 3;

            switch (_currentPictureToSet)
            {
                case 0:
                    button.Content = FindNeededImage(0);
                    break;
                case 1:
                    button.Content = FindNeededImage(1);
                    break;
                case 2:
                    button.Content = FindNeededImage(2);
                    break;
            }
        }

        private static void OpenCell(int i, int j)
        {
            Buttons[i, j].IsEnabled = false;
            _openCellsCount++;

            switch (map[i, j])
            {
                case 1:
                    Buttons[i, j].Content = FindNeededImage(14);
                    break;
                case 2:
                    Buttons[i, j].Content = FindNeededImage(13);
                    break;
                case 3:
                    Buttons[i, j].Content = FindNeededImage(12);
                    break;
                case 4:
                    Buttons[i, j].Content = FindNeededImage(11);
                    break;
                case 5:
                    Buttons[i, j].Content = FindNeededImage(10);
                    break;
                case 6:
                    Buttons[i, j].Content = FindNeededImage(9);
                    break;
                case 7:
                    Buttons[i, j].Content = FindNeededImage(8);
                    break;
                case 8:
                    Buttons[i, j].Content = FindNeededImage(7);
                    break;
                case -1:
                    Buttons[i, j].Content = FindNeededImage(4);
                    break;
                case 0:
                    Buttons[i, j].Content = FindNeededImage(15);
                    break;
            }
        }

        private static void OpenCells(int i, int j)
        {
            OpenCell(i, j);

            if (map[i, j] > 0)
            {
                return;
            }

            for (var k = i - 1; k < i + 2; k++)
            {
                for (var l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k, l))
                    {
                        continue;
                    }

                    if (!Buttons[k, l].IsEnabled)
                    {
                        continue;
                    }

                    if (map[k, l] == 0)
                    {
                        OpenCells(k, l);
                    }

                    else if (map[k, l] > 0)
                    {
                        OpenCell(k, l);
                    }
                }
            }
        }

        private static void ShowAllBombs(int iBomb, int jBomb)
        {
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    if (i == iBomb && j == jBomb)
                    {
                        continue;
                    }

                    if (map[i, j] == -1)
                    {
                        Buttons[i, j].Content = FindNeededImage(3);
                    }
                }
            }
        }

        private static void CountCellBomb()
        {
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    if (map[i, j] != -1)
                    {
                        continue;
                    }

                    for (var k = i - 1; k < i + 2; k++)
                    {
                        for (var l = j - 1; l < j + 2; l++)
                        {
                            if (!IsInBorder(k, l) || map[k, l] == -1)
                            {
                                continue;
                            }

                            map[k, l] += 1;

                        }
                    }
                }
            }
        }

        private static bool IsInBorder(int i, int j)
        {
            return !(i < 0 || j < 0 || j > _width - 1 || i > _height - 1);
        }

        private static Image FindNeededImage(int typesNumber)
        {
            var bitmap = new CroppedBitmap(
                _buttonTypesImageSource,
                new Int32Rect(0, typesNumber * ButtonImageOffsetStep, ButtonImageOffsetStep, ButtonImageOffsetStep));

            return new Image { Source = bitmap };
        }

        private static bool IsVictory()
        {
            return _openCellsCount == cellsCount - bombsCount;
        }
    }
}
