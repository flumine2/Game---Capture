using Game___Capture.model;
using Game___Capture.model.Cells;
using Game___Capture.model.UserControl;
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
    class RenderService
    {
        private readonly Image _image;
        private readonly Game _game;
        private readonly PlayerActionService _actionService;
        private readonly TextBlock _scoreString;
        private readonly TextBlock _timeString;

        public RenderService(Image image, Game game, PlayerActionService actionService, TextBlock scoreString, TextBlock timeString)
        {
            _image = image;
            _game = game;
            _actionService = actionService;
            _scoreString = scoreString;
            _timeString = timeString;
        }

        public void RenderFrame()
        { 
            _image.Source = GetFrame();
        }

        private BitmapSource GetFrame()
        {
            RenderTargetBitmap bitmap = new(
                Config.GAME_FIELD_WIDTH,
                Config.GAME_FIELD_HEIGHT,
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
            _game.GameField.Draw(drawingContext);
            foreach (Segment segment in _game.GameField.Segments)
            {
                segment.Draw(drawingContext);
            }

            _scoreString.Text = _game.Score.ToString();
            _timeString.Text = _game.Timer.ToString();
        }
    }
}
