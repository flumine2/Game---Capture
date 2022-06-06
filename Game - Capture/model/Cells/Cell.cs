using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Game___Capture.model.Cells
{
    public abstract class Cell : GameObject
    {
        protected Point _position;

        public Point Position 
        {
            get => _position;
        }

        public Point CellsCenter
        {
            get => new(_position.X + Config.CELL_SIZE.Width / 2, _position.Y + Config.CELL_SIZE.Height / 2);
        }

        public Cell(Point position)
        {
            _position = position;
        }

        public override void Update(double deltaTime)
        {
            _position.Y += Config.FallingSpeed(deltaTime);
        }

        public bool IsBomb()
        {
            return this is BombCell;
        }

        public bool IsGift()
        {
            return this is GiftCell;
        }

        public bool IsInPolygon(Point[] p)
        {
            if (p is null)
            {
                return false;
            }

            bool result = false;
            int j = p.Length - 1;
            for (int i = 0; i < p.Length; i++)
            {
                if ((p[i].Y < CellsCenter.Y && p[j].Y >= CellsCenter.Y
                    || p[j].Y < CellsCenter.Y && p[i].Y >= CellsCenter.Y)
                    && (p[i].X + (CellsCenter.Y - p[i].Y) / (p[j].Y - p[i].Y) * (p[j].X - p[i].X) < CellsCenter.X))
                {
                    result = !result;
                }

                j = i;
            }

            return result;
        }
    }
}
