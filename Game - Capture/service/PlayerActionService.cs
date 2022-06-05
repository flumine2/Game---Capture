using Game___Capture.model;
using Game___Capture.model.UserControl;
using Game___Capture.Updatable;
using Game___Capture.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game___Capture.service
{
    class PlayerActionService : IUpdatable
    {
        private readonly MousePositionDelegate _mousePosition;
        private readonly ScoreService _scoreService;
        private readonly GameField _gameField;
        private readonly List<Point> _points;
        private Point? _lastPoint;
        public bool IsMouseDown = false;

        public PlayerActionService(MousePositionDelegate mousePosition, ScoreService scoreService, GameField gameField)
        {
            _mousePosition = mousePosition;
            _scoreService = scoreService;
            _points = new List<Point>();
            _gameField = gameField;
        }

        public void AddPoint(Point point)
        {
            if (!(_lastPoint is null))
            {
                _gameField.Segments.Add(new Segment(_lastPoint.Value, point));
            }
            _lastPoint = point;
            _points.Add(point);
        }

        public void ProcessInput()
        {
            if (IsMouseDown)
            {
                if (_gameField.Segments.Count != 0 && (_gameField.Segments[0].Start.Y > 628
                    || _gameField.Segments[_gameField.Segments.Count - 1].End.Y > 628))
                {
                    Clear();
                }
            }
            else
            {
                Clear();
            }
            ProcessActionsResult();
        }

        private void ProcessActionsResult()
        {
            for (int i = 0; i < _gameField.Segments.Count - 2; i++)
            {
                if (IntersectionCheck.IsIntersected(_gameField.Segments[_gameField.Segments.Count - 1], _gameField.Segments[i]))
                {
                    Point cross = IntersectionCheck.GetPointOfIntersection(_gameField.Segments[_gameField.Segments.Count - 1], _gameField.Segments[i]);
                    _points[_points.Count - 1] = cross;
                    _scoreService.ChangeScore(_points.GetRange(i + 1, _points.Count - i - 1).ToArray());
                    Clear();
                    return;
                }
            }
        }

        public void Update(double deltaTime)
        {
            if (!(_lastPoint is null))
            {
                _lastPoint = new Point(
                    _lastPoint.GetValueOrDefault().X,
                    _lastPoint.GetValueOrDefault().Y + Config.FallingSpeed(deltaTime));
            }

            if (IsMouseDown)
            {
                AddPoint(_mousePosition());
            }
        }

        private void Clear()
        {
            _gameField.Segments.Clear();
            _points.Clear();
            _lastPoint = null;
        }
        
    }
}
