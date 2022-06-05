using Game___Capture.model;
using Game___Capture.model.Cells;
using Game___Capture.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game___Capture.service
{
    class ScoreService
    {
        private readonly Game _game;

        public ScoreService(Game game)
        {
            _game = game;
        }

        public void ChangeScore(Point[] polygonPoints)
        {
            int scoreSum = CalcScoreSum(polygonPoints);
            double polygonArea = CalcPolygonArea(polygonPoints);

            _game.AddScore((int)(scoreSum * polygonArea / 100));
        }

        private int CalcScoreSum(Point[] polygonPoints)
        {
            int scoreSum = 0;

            for (int i = 0; i < _game.GameField.Cells.Length; i++)
            {
                for (int j= 0; j < _game.GameField.Cells[i].Length; j++)
                {
                    if (_game.GameField.Cells[i][j].IsInPolygon(polygonPoints))
                    {
                        if (_game.GameField.Cells[i][j].IsBomb())
                        {
                            return 0;
                        }
                        if (_game.GameField.Cells[i][j].IsGift())
                        {
                            scoreSum += Config.GIFT_POINTS;
                            _game.GameField.Cells[i][j] = new EmptyCell(_game.GameField.Cells[i][j].Position);
                        }
                    }
                }
            }

            return scoreSum;
        }

        private double CalcPolygonArea(Point[] polygonPoints)
        {
            // Shoelace formula
            double area = 0;

            for (int i = 0; i < polygonPoints.Length - 1; i++)
            {
                double xi = polygonPoints[i].X;
                double xi_1 = polygonPoints[i + 1].X;
                double yi = polygonPoints[i].Y;
                double yi_1 = polygonPoints[i + 1].Y;

                area += 0.5 * Math.Abs(xi * yi_1 - xi_1 * yi);
            }

            return area;
        }
    }
}
