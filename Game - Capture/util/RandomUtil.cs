using Game___Capture.model;
using Game___Capture.model.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game___Capture.util
{
    public static class RandomUtil
    {
        private static readonly Random RANDOM = new();

        public static int NextInt(int min, int max)
        {
            return RANDOM.Next(min, max);
        }

        public static double NextDouble(double min, double max)
        {
            return RANDOM.NextDouble() * (max - min) + min;
        }

        public static Cell[] RandomCellArray(int index)
        {
            Cell[] cells = new Cell[Config.GAME_FIELD_CELL_COUNTS.InRow];

            for (int i = 0; i < cells.Length; i++)
            {
                if (RANDOM.NextDouble() < 0.07)
                {
                    if (RANDOM.NextDouble() < 0.5)
                    {
                        cells[i] = new GiftCell(GetPosition(i, index));
                    }
                    else
                    {
                        cells[i] = new BombCell(GetPosition(i, index));
                    }
                }
                else
                {
                    cells[i] = new EmptyCell(GetPosition(i, index));
                }
            }

            return cells;
        }

        public static Point GetPosition(int fieldCoordinateX, int fieldCoordinateY)
        {
            double singleSegmentLength = Config.GAME_FIELD_WIDTH / Config.GAME_FIELD_CELL_COUNTS.InRow;

            return new Point(fieldCoordinateX * singleSegmentLength + 5, (fieldCoordinateY - 1) * singleSegmentLength);
        }
    }
}
