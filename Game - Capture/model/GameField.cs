using Game___Capture.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___Capture.model
{
    class GameField
    {
        private Cell[][] cells;

        public GameField()
        {
            cells = new Cell[Config.GAME_FIELD_CELL_COUNTS.InColumn][];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = RandomUtil.randomCell(Config.GAME_FIELD_CELL_COUNTS.InRow).ToArray();
            }
        }
    }
}
