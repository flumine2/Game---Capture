using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___Capture.model
{
    public enum CellKind
    { 
        Empty = 0,
        Gift = 1,
        Bomb = 2
    }

    public class Cell
    {
        private CellKind kind;

        public CellKind Kind
        {
            get => kind;
            set { kind = value; }
        }

        public Cell(CellKind kind)
        {
            this.kind = kind;
        }
    }
}
