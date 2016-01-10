using System;
using System.Collections.Generic;
using System.Drawing;
using Network_System.Interfaces;

namespace Network_System.Components
{
    [Serializable]
    public class Sink : Component, IFlow
    {
        //Fields
        private Point pipelineLocation;

        //Properties
        public Pipeline IncomePipeline { get; private set; }

        //Constructor
        public Sink(int locx, int locy) :
            base(locx, locy)
        {
            this.pipelineLocation = CalculatePipelineLocation();
        }

        #region Calculating Methods

        /// <summary>
        /// Returns a point that will be used for connecting pipelines.
        /// </summary>
        /// <returns>A point used for connecting pipelines.</returns>
        private Point CalculatePipelineLocation()
        {
            return new Point(ComponentBox.Left + 5, ComponentBox.Top + ComponentBox.Height / 2);
        }

        #endregion

        /// <summary>
        /// The Sink's image that is used for painting.
        /// </summary>
        /// <returns>The Sink's image.</returns>
        public override Image GetImage()
        {
            return Properties.Resources.sink;
        }

        /// <summary>
        /// Returns a string with the flow of the sink.
        /// </summary>
        /// <returns>A string with the current incoming flow.</returns>
        public string GetFlow()
        {
            if (this.IncomePipeline == null)
            {
                return "0.0";
            }
            return Math.Round(this.IncomePipeline.CurrentFlow, 1).ToString();
        }

        /// <summary>
        /// Gets the text location for the flow string.
        /// </summary>
        /// <returns>A point used for drawing the text.</returns>
        public Point GetTextLocation()
        {
            return new Point(GetLocation().X + GetImage().Width / 3, GetLocation().Y + GetImage().Height / 3);
        }

        /// <summary>
        /// Assigns the pipeline that is being passed,based on the location.
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <param name="pipe">The pipeline that will be assigned.</param>
        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (ComponentBox.Contains(location))
            {
                this.IncomePipeline = pipe;
            }
        }

        /// <summary>
        /// Gets a concrete point that is used for connecting pipelines based on where the mouse click has been made.
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <returns>A concrete prefixed point.</returns>
        public override Point? GetPipelineLocation(Point mouseClick)
        {
            if (ComponentBox.Contains(mouseClick))
            {
                return pipelineLocation;
            }
            return null;
        }

        /// <summary>
        /// Deletes the pipeline and sets its corresponding property to null.
        /// </summary>
        /// <param name="p">The pipeline that will be deleted.</param>
        public override void ClearPipeline(Pipeline p)
        {
            if (this.IncomePipeline == p)
            {
                this.IncomePipeline = null;
            }
        }

        /// <summary>
        /// Gets all the connected (those that are not equal to null) pipelines.
        /// </summary>
        /// <returns>A list holding all the connected pipelines.</returns>
        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (IncomePipeline != null) { allPipelines.Add(IncomePipeline); }
            return allPipelines;
        }

        /// <summary>
        /// Checks if the pipeline where the mouse click has been made is not connected(null).
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <returns>True if the pipeline is null.Otherwise false.</returns>
        public override bool IsLocationEmpty(Point location)
        {
            if (ComponentBox.Contains(location))
            {
                return this.IncomePipeline == null;
            }
            return false;
        }
    }
}