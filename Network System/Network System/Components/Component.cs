using System.Drawing;
using System;
using System.Collections.Generic;

namespace Network_System.Components
{
    [Serializable]
    public abstract class Component
    {
        //Fields
        private readonly int locationX;
        private readonly int locationY;

        //Properties
        public Rectangle ComponentBox { get; }

        //Constructor
        public Component(int locx, int locy)
        {
            this.locationX = locx - GetImage().Width / 2;
            this.locationY = locy - GetImage().Height / 2;
            ComponentBox = new Rectangle(new Point(locationX - 1, locationY - 1), new Size(GetImage().Width + 1, GetImage().Height + 1));
        }

        /// <summary>
        /// Gets an image from Resources.
        /// </summary>
        /// <returns>An image,used for painting.</returns>
        public abstract Image GetImage();

        /// <summary>
        /// Deletes the pipeline and sets its corresponding outcome/income of the component to null.
        /// </summary>
        /// <param name="p">The pipeline that will be deleted.</param>
        public abstract void ClearPipeline(Pipeline p);

        /// <summary>
        /// Gets all the connected (those that are not equal to null) pipelines.
        /// </summary>
        /// <returns>A list holding all the connected pipelines.</returns>
        public abstract IEnumerable<Pipeline> GetPipelines();

        /// <summary>
        /// Assigns the pipeline that is being passed,based on the location.
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <param name="pipe">The pipeline that will be assigned.</param>
        public abstract void SetPipeline(Point location, Pipeline pipe);

        /// <summary>
        /// Gets a concrete point that is used for connecting pipelines based on where the mouse click has been made.
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <returns>A concrete prefixed point.</returns>
        public abstract Point? GetPipelineLocation(Point location);

        /// <summary>
        /// Checks if the pipeline where the mouse click has been made is not connected(null).
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <returns>True if the pipeline is null.Otherwise false.</returns>
        public abstract bool IsLocationEmpty(Point location);

        /// <summary>
        /// The location of the upper-left corner of the component.
        /// </summary>
        /// <returns>The coordinates of the component.</returns>
        public Point GetLocation()
        {
            return new Point(locationX, locationY);
        }

        /// <summary>
        /// Checks if the other component overlaps with this one.
        /// </summary>
        /// <param name="otherComponent">The component that is checked.</param>
        /// <returns>True if the two components overlap.Otherwise false.</returns>
        public bool CheckOverlapComponent(Component otherComponent)
        {
            return this.ComponentBox.IntersectsWith(otherComponent.ComponentBox);
        }
    }
}