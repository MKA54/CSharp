using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper.ViewModel
{
    public static class MapController
    {
        private static int MapSize = 8;
        private static int CellSize = 50;
        private static int bombsCount = 2;
        private static int _cellsOpened;
        private static readonly int CellsCount = MapSize * MapSize;

        private static int _currentPictureToSet;

        private static readonly int[,] Map = new int[MapSize, MapSize];
        private static readonly Button[,] Buttons = new Button[MapSize, MapSize];

        private static Image _spriteSet;

        private static bool _isFirstSteep;

        private static Point _firstCoord;

        private static Form _form;

        public static void Init(Form current)
        {
            _form = current;
            _cellsOpened = 0;
            _currentPictureToSet = 0;
            _isFirstSteep = true;
            _spriteSet = new Bitmap("C:\\Users\\Админ\\source\\repos\\CSharp\\Sapper\\Sprites\\tiles.png");

            ConfigureMapSize(current);
            InitMap();
            InitButtons(current);
        }

        private static Image FindNeededImage(int xPos, int yPos)
        {
            var image = new Bitmap(CellSize, CellSize);
            var g = Graphics.FromImage(image);
            g.DrawImage(_spriteSet, new Rectangle(new Point(0, 0), new Size(CellSize, CellSize)), 0 + 32 * xPos, 0 + 32 * yPos, 33, 33, GraphicsUnit.Pixel);

            return image;
        }

        private static void ConfigureMapSize(Control current)
        {
            current.Width = MapSize * CellSize + 20;
            current.Height = (MapSize + 1) * CellSize;
        }

        private static void InitMap()
        {
            for (var i = 0; i < MapSize; i++)
            {
                for (var j = 0; j < MapSize; j++)
                {
                    Map[i, j] = 0;
                }
            }
        }

        private static void InitButtons(Control current)
        {
            for (var i = 0; i < MapSize; i++)
            {
                for (var j = 0; j < MapSize; j++)
                {
                    var button = new Button
                    {
                        Location = new Point(j * CellSize, i * CellSize),
                        Size = new Size(CellSize, CellSize),
                        Image = FindNeededImage(0, 0)
                    };

                    button.MouseUp += OnButtonPressedMouse;
                    current.Controls.Add(button);

                    Buttons[i, j] = button;
                }
            }
        }

        private static void OnButtonPressedMouse(object sender, MouseEventArgs e)
        {
            var pressedButton = sender as Button;

            switch (e.Button.ToString())
            {
                case "Right":
                    OnRightButtonPressed(pressedButton);
                    break;
                case "Left":
                    OnLeftButtonPressed(pressedButton);
                    break;
            }
        }

        private static void OnRightButtonPressed(ButtonBase pressedButton)
        {
            _currentPictureToSet++;
            _currentPictureToSet %= 3;

            var posX = 0;
            var posY = 0;

            switch (_currentPictureToSet)
            {
                case 0:
                    posX = 0;
                    posY = 0;
                    break;
                case 1:
                    posX = 0;
                    posY = 2;
                    break;
                case 2:
                    posX = 2;
                    posY = 2;
                    break;
            }

            pressedButton.Image = FindNeededImage(posX, posY);
        }

        private static void OnLeftButtonPressed(Control pressedButton)
        {
            pressedButton.Enabled = false;

            var iButton = pressedButton.Location.Y / CellSize;
            var jButton = pressedButton.Location.X / CellSize;

            if (_isFirstSteep)
            {
                _firstCoord = new Point(jButton, iButton);
                _cellsOpened++;
                SeedMap();
                CountCellBomb();
                _isFirstSteep = false;
            }

            if (_cellsOpened == CellsCount - bombsCount)
            {
                MessageBox.Show("Вы победили!" + _cellsOpened);
                _form.Controls.Clear();
                Init(_form);
            }

            OpenCells(iButton, jButton);

            if (Map[iButton, jButton] == -1)
            {
                ShowAllBox(iButton, jButton);
                MessageBox.Show("Вы проиграли!" + _cellsOpened);
                _form.Controls.Clear();
                Init(_form);
            }
        }

        private static void SeedMap()
        {
            var r = new Random();

            for (var i = 0; i < bombsCount; i++)
            {
                var posI = r.Next(0, MapSize - 1);
                var posJ = r.Next(0, MapSize - 1);

                while (Map[posI, posJ] == -1 || Math.Abs(posI - _firstCoord.Y) <= 1 && Math.Abs(posJ - _firstCoord.X) <= 1)
                {
                    posI = r.Next(0, MapSize - 1);
                    posJ = r.Next(0, MapSize - 1);
                }

                Map[posI, posJ] = -1;
            }
        }

        private static void CountCellBomb()
        {
            for (var i = 0; i < MapSize; i++)
            {
                for (var j = 0; j < MapSize; j++)
                {
                    if (Map[i, j] != -1)
                    {
                        continue;
                    }

                    for (var k = i - 1; k < i + 2; k++)
                    {
                        for (var l = j - 1; l < j + 2; l++)
                        {
                            if (!IsInBorder(k, l) || Map[k, l] == -1)
                            {
                                continue;
                            }

                            Map[k, l] += 1;
                        }
                    }

                }
            }
        }

        private static bool IsInBorder(int i, int j)
        {
            return !(i < 0 || j < 0 || j > MapSize - 1 || i > MapSize - 1);
        }

        private static void OpenCell(int i, int j)
        {
            Buttons[i, j].Enabled = false;

            switch (Map[i, j])
            {
                case 1:
                    Buttons[i, j].Image = FindNeededImage(1, 0);
                    break;
                case 2:
                    Buttons[i, j].Image = FindNeededImage(2, 0);
                    break;
                case 3:
                    Buttons[i, j].Image = FindNeededImage(3, 0);
                    break;
                case 4:
                    Buttons[i, j].Image = FindNeededImage(4, 0);
                    break;
                case 5:
                    Buttons[i, j].Image = FindNeededImage(0, 1);
                    break;
                case 6:
                    Buttons[i, j].Image = FindNeededImage(1, 1);
                    break;
                case 7:
                    Buttons[i, j].Image = FindNeededImage(2, 1);
                    break;
                case 8:
                    Buttons[i, j].Image = FindNeededImage(3, 1);
                    break;
                case -1:
                    Buttons[i, j].Image = FindNeededImage(1, 2);
                    break;
                case 0:
                    Buttons[i, j].Image = FindNeededImage(0, 0);
                    break;
            }

            _cellsOpened++;
        }

        private static void OpenCells(int i, int j)
        {
            OpenCell(i, j);

            if (Map[i, j] > 0)
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

                    if (!Buttons[k, l].Enabled)
                    {
                        continue;
                    }

                    if (Map[k, l] == 0)
                    {
                        OpenCells(k, l);
                    }

                    else if (Map[k, l] > 0)
                    {
                        OpenCell(k, l);
                    }
                }
            }
        }

        private static void ShowAllBox(int iBomb, int jBomb)
        {
            for (var i = 0; i < MapSize; i++)
            {
                for (var j = 0; j < MapSize; j++)
                {
                    if (i == iBomb && j == jBomb)
                    {
                        continue;
                    }

                    if (Map[i, j] == -1)
                    {
                        Buttons[i, j].Image = FindNeededImage(3, 2);
                    }
                }
            }
        }
    }
}