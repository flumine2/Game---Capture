using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game___Capture.view.CellView
{
    class EmptyCellView : CellView
    {
        public EmptyCellView(Point position) : base(position)
        {
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }
    }
}
