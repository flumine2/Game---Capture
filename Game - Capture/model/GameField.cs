using Game___Capture.model.Cells;
using Game___Capture.model.UserControl;
using Game___Capture.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game___Capture.model
{
    class GameField : GameObject
    {
        private Cell[][] _cells;
        public List<Segment> Segments;

        public Cell[][] Cells
        {
            get => _cells;
            set => _cells = value;
        }

        public GameField()
        {
            Segments = new List<Segment>();
            _cells = new Cell[Config.GAME_FIELD_CELL_COUNTS.InColumn + 1][];
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = RandomUtil.RandomCellArray(i);
            }
        }

        public override void Draw(DrawingContext drawingContext)
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                for (int j = 0; j < _cells[i].Length; j++)
                {
                    _cells[i][j].Draw(drawingContext);
                }
            }

        }

        public override void Update(double deltaTime)
        {
            foreach (Cell cell in _cells.SelectMany(cells => cells))
                cell.Update(deltaTime);

            foreach (Segment segment in Segments)
                segment.Update(deltaTime);
        }

        public void OffsetField()
        {
            for (int i = _cells.Length - 1; i > 0; i--)
            {
                _cells[i] = _cells[i - 1];
            }
            _cells[0] = RandomUtil.RandomCellArray(0);
        }
    }
}
