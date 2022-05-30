using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___Capture
{
    class Config
    {
        public static readonly double PIXELS_PER_DIP = 96;
        public static readonly int FPS = 50;
        public static readonly int GameFieldWidth = 850;
        public static readonly int GameFieldHeight = 720;
        public static readonly (int InRow, int InColumn) GAME_FIELD_CELL_COUNTS = (10, 10);

        public static readonly Size CellViewSize = new Size(800, 820);
    }
}
