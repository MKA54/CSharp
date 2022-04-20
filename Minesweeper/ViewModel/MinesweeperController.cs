using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using Minesweeper.View;

namespace Minesweeper.ViewModel
{
    public class MinesweeperController
    {
        public MinesweeperController(int level, MainWindow form)
        {
            MinesweeperModel.Init(level, form);
        }
    }
}
