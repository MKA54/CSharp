using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.View;

namespace Minesweeper.Model
{
    public static class MinesweeperModel
    {
        private static MainWindow _mainWindow;
        private static int _width;
        private static int _height;

        public static void Init(int level, MainWindow form)
        {
            switch (level)
            {
                case 0:
                    _width = 9;
                    _height = 9;
                    break;

                case 1:
                    _width = 16;
                    _height = 16;
                    break;

                case 2:
                    _width = 30;
                    _height = 16;
                    break;
            }

            _mainWindow = form;
        }
    }
}
