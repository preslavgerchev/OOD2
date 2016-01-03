using System.Drawing;
using System;
using System.Collections.Generic;

namespace ClassDiagram_Final
{
    [Serializable]
    public abstract class Component
    {
        //Fields
        private readonly int locationX;
        private readonly int locationY;

        //Properties
        public Rectangle ComponentBox { get; private set; }

        //Constructor
        public Component(int locx, int locy)
        {
            this.locationX = locx - GetImage().Width / 2;
            this.locationY = locy - GetImage().Height / 2;
            ComponentBox = new Rectangle(new Point(locationX - 5, locationY - 5), new Size(GetImage().Width, GetImage().Height));
        }
        //Abstract methods
        public abstract Image GetImage();

        public abstract void ClearPipeline(Pipeline p);

        public abstract IEnumerable<Pipeline> GetPipelines();

        public abstract void SetPipeline(Point location, Pipeline pipe);

        public abstract Point GetPipelineLocation(Point mouseClick);

        public abstract bool IsLocationEmpty(Point location);

        /// <summary>
        /// Return the coordonates of a point.
        /// </summary>
        /// <returns></returns>
        public Point GetLocation()
        {
            return new Point(locationX, locationY);
        }
        /// <summary>
        /// Checks if there is already a component in that same place and returns true if so.
        /// </summary>
        /// <param name="otherComponent"></param>
        /// <returns></returns>
        public bool CheckOverlapComponent(Component otherComponent)
        {
            return this.ComponentBox.IntersectsWith(otherComponent.ComponentBox);
        }
       


    }
}
