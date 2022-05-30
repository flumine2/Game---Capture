
using Game___Capture.Resources;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Game___Capture.view.CellView
{
    abstract class CellView
    {
        private Point Position { get; set; }

        public CellView(Point position)
        {
            Position = position;
        }

        public abstract void Render();
    }
}
