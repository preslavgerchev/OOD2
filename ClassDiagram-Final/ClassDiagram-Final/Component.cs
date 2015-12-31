using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassDiagram_Final
{
    [Serializable]
    public abstract class Component
    {
        private readonly int locationX;
        private readonly int locationY;

        public Rectangle ComponentBox { get; private set; }

        public Component(int locx, int locy)
        {
            this.locationX = locx - GetImage().Width / 2;
            this.locationY = locy - GetImage().Height / 2;
            ComponentBox = new Rectangle(new Point(locationX - 5, locationY - 5), new Size(GetImage().Width, GetImage().Height));
        }

        public abstract Image GetImage();

        public abstract void ClearPipeline(Pipeline p);

        public abstract IEnumerable<Pipeline> GetPipelines();

        public abstract void SetPipeline(Point location, Pipeline pipe);

        public abstract Point GetPipelineLocation(Point mouseClick);

        public Point GetLocation()
        {
            return new Point(locationX, locationY);
        }

        public bool CheckOverlapComponent(Component otherComponent)
        {
            return this.ComponentBox.IntersectsWith(otherComponent.ComponentBox);
        }
    }
}
