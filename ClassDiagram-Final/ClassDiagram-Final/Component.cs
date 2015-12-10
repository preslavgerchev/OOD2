using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassDiagram_Final
{
    abstract class Component
    {
        
        // FIELDS
        private int locationX;
        private int locationY;

        // PROPERTIES
        public Rectangle ComponentBox { get; private set; }

        // METHODS
        public abstract Image GetImage();
        public virtual Point GetLocation() { Point p = new Point(); return p; }
        public virtual Point GetTextLocation() { Point p = new Point(); return p; }
        public virtual bool CheckOverlapComponent(Component otherComponent ) { return false; }
        public void UpdateFlow() { }



         

    }
}
