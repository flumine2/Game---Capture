using Game___Capture.Resources;
using Game___Capture.util;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game___Capture.model.Cells
{
    class GiftCell : Cell
    {
        private static readonly BitmapImage _image = ConvertUtil.ToBitmapImage(Resource1.Gift);

        public GiftCell(Point position) : base(position) { }

        public override void Draw(DrawingContext drawingContext)
        {
            drawingContext.DrawRoundedRectangle(
                Brushes.Transparent, new Pen(Brushes.Green, 3),
                new Rect(_position, Config.CELL_SIZE),
                radiusX: 5, radiusY: 5);

            drawingContext.DrawImage(_image, new Rect(_position, Config.CELL_SIZE));
        }
    }
}
