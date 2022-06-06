using Game___Capture.Updatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game___Capture
{
    public abstract class GameObject : IUpdatable
    {
        public virtual void Update(double deltaTime) { }
        public abstract void Draw(DrawingContext drawingContext);
    }
}
