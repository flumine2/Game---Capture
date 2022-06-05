using Game___Capture.Resources;
using Game___Capture.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game___Capture.model.Cells
{
    class EmptyCell : Cell
    {
        public EmptyCell(Point position) : base(position)
        {

        }

        public override void Draw(DrawingContext drawingContext)
        {
            drawingContext.DrawRoundedRectangle(
                Brushes.Gray,
                new Pen(Brushes.Blue, 3),
                new Rect(
                    _position,
                    Config.CELL_SIZE),
                radiusX: 5,
                radiusY: 5);
        }
    }
}
