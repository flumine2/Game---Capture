using Game___Capture.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___Capture.util
{
    public static class RandomUtil
    {
        private static Random RANDOM = new Random();

        private static CellKind[] CELLKIND_VALUES = (CellKind[]) typeof(CellKind).GetEnumValues();

        public static int nextInt(int min, int max)
        {
            return RANDOM.Next(min, max);
        }

        public static double nextDouble(double min, double max)
        {
            return RANDOM.NextDouble() * (max - min) + min;
        }

        private static byte nextByte()
        {
            return (byte)nextInt(0, 255);
        }

        public static List<Cell> randomCell(int count)
        {
            return Enumerable.Range(0, count)
                .Select((x, index) => nextCell(index + 1))
                .ToList();
        }

        private static Cell nextCell(int startPosition)
        {
            return new Cell
                (
                    CELLKIND_VALUES[nextInt(0, 3)]
                );
        }

        
    }
}
