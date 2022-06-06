using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___Capture
{
    class Config
    {
        public static readonly double PIXELS_PER_DIP = 96;
        public static readonly int GAME_FIELD_WIDTH = 600;
        public static readonly int GAME_FIELD_HEIGHT = 628;
        public static readonly int MS_PER_FRAME = 20;
        public static readonly int GAME_TIME = 20;
        public static readonly int GIFT_POINTS = 50;
        public static readonly (int InRow, int InColumn) GAME_FIELD_CELL_COUNTS = (10, 13);
        public static readonly Size CELL_SIZE = new(
            GAME_FIELD_WIDTH / GAME_FIELD_CELL_COUNTS.InRow - 10,
            GAME_FIELD_WIDTH / GAME_FIELD_CELL_COUNTS.InRow - 10);

        
        
        public static readonly Func<double, double> FallingSpeed = (deltaTime) => deltaTime / 1000 * 50;

    }
}
