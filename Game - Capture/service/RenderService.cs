using Game___Capture.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game___Capture.service
{
    public delegate Size ImageSize();
    class RenderService
    {
        private Image image;
        private List<Cell> cells;

        public RenderService(Image image, List<Cell> cells)
        {
            this.image = image;
            this.cells = cells;
        }

        public void RenderFrame() => image.Source = GetFrame();

        private BitmapSource GetFrame()
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap(
                Config.GameFieldWidth,
                Config.GameFieldHeight,
                Config.PIXELS_PER_DIP,
                Config.PIXELS_PER_DIP,
                PixelFormats.Pbgra32);

            DrawingVisual drawingVisual = new();

            using (DrawingContext dc = drawingVisual.RenderOpen())
            {
                Render(dc);
            }

            bitmap.Render(drawingVisual);

            return bitmap;
        }

        private void Render(DrawingContext drawingContext)
        {

        }
    }
}
