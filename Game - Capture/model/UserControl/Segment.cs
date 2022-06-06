using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Game___Capture.model.UserControl
{
    public class Segment : GameObject
    {
        private Point _point1;
        private Point _point2;

        public Point Start
        {
            get => _point1;
        }

        public Point End
        {
            get => _point2;
        }

        public Segment(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        public override void Draw(DrawingContext drawingContext)
        {
            drawingContext.DrawLine(new Pen(Brushes.Cyan, 2), _point1, _point2);
        }

        public override void Update(double deltaTime)
        {
            _point1.Y += Config.FallingSpeed(deltaTime);
            _point2.Y += Config.FallingSpeed(deltaTime);
        }
    }
}
