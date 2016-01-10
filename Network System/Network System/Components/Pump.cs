using System;
using System.Collections.Generic;
using System.Drawing;
using Network_System.Interfaces;

namespace Network_System.Components
{
    [Serializable]
    public class Pump : Component, IFlow
    {
        //Fields
        private Point pipelineLocation;

        //Properties
        public Pipeline OutcomePipeline { get; private set; }
        public double Flow { get; private set; }
        public double Capacity { get; private set; }

        //Constructor
        public Pump(int locx, int locy) :
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
            return new Point(ComponentBox.Right - 3, ComponentBox.Top + ComponentBox.Height / 2);
        }

        #endregion

        /// <summary>
        /// Sets the flow of the pump if it does not exceed its capacity.
        /// </summary>
        /// <param name="max">The capacity of the pump.</param>
        /// <param name="current">The current flow of the pump.</param>
        public void SetFlow(double max, double current)
        {
            if (current <= max)
            {
                this.Flow = current;
                this.Capacity = max;
                if (OutcomePipeline != null)
                {
                    this.OutcomePipeline.ChangeCurrentFlow(current);
                    IFlowHandler flowHandler = OutcomePipeline.EndComponent as IFlowHandler;
                    if (flowHandler != null)
                    {
                        flowHandler.AdjustPipelineValues();
                    }
                }
            }
        }

        /// <summary>
        /// The Pump's image that is used for painting.
        /// </summary>
        /// <returns>The Pump's image.</returns>
        public override Image GetImage()
        {
            return Properties.Resources.pump;
        }

        /// <summary>
        /// Returns a string with the flow and the capacity of the pump.
        /// </summary>
        /// <returns>A string with the current flow and the capacity.</returns>
        public string GetFlow()
        {
            return string.Format("{0}/{1}", Math.Round(Flow, 1), Capacity);
        }

        /// <summary>
        /// Gets the text location for the flow and the capacity string.
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
                this.OutcomePipeline = pipe;
                this.OutcomePipeline.ChangeCurrentFlow(Flow);
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
            if (this.OutcomePipeline == p)
            {
                this.OutcomePipeline = null;
                this.Flow = 0;
            }
        }

        /// <summary>
        /// Gets all the connected (those that are not equal to null) pipelines.
        /// </summary>
        /// <returns>A list holding all the connected pipelines.</returns>
        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (OutcomePipeline != null) { allPipelines.Add(OutcomePipeline); }
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
                return this.OutcomePipeline == null;
            }
            return false;
        }
    }
}