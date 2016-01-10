using System;
using System.Collections.Generic;
using System.Drawing;
using Network_System.Components;
using Network_System.Interfaces;

namespace Network_System
{
    [Serializable]
    public class Pipeline : IFlow
    {
        //Properties
        public double CurrentFlow { get; private set; }
        public double MaxFlow { get; private set; }
        public IList<Point> InBetweenPoints { get; }
        public Component StartComponent { get; }
        public Component EndComponent { get; }
        public Point StartPoint { get; }
        public Point EndPoint { get; }
        public Rectangle GetPipelineRetangle { get; }
        public Color PipelineColor
        {
            get
            {
                if (CurrentFlow < MaxFlow)
                {
                    return Color.Orange;
                }
                return Color.Red;
            }
        }

        //Constructor
        public Pipeline(Component startComp, Component endComp, Point startCompLoc, Point endCompLoc, IList<Point> inbetweenPts)
        {
            this.InBetweenPoints = inbetweenPts;
            this.StartComponent = startComp;
            this.EndComponent = endComp;
            this.StartPoint = startCompLoc;
            this.EndPoint = endCompLoc;
        }

        /// <summary>
        /// Changes the current flow of a pipeline if it does not exceed its capacity.
        /// </summary>
        /// <param name="newFlow">The new value for the current flow.</param>
        public void ChangeCurrentFlow(double newFlow)
        {
            if (newFlow <= MaxFlow)
            {
                this.CurrentFlow = newFlow;
                return;
            }
            this.CurrentFlow = this.MaxFlow;
        }

        /// <summary>
        /// Changes the max flow of the pipeline if it is bigger than the current flow.
        /// </summary>
        /// <param name="newMaxFlow">The new value for the max flow.</param>
        public void ChangeMaxFlow(double newMaxFlow)
        {
            if (newMaxFlow >= CurrentFlow)
            {
                this.MaxFlow = newMaxFlow;
            }
            Pump p = StartComponent as Pump;
            if (p != null)
            {
                this.ChangeCurrentFlow(p.Flow);
            }
            IFlowHandler flowHandlerStart = StartComponent as IFlowHandler;
            if (flowHandlerStart != null)
            {
                flowHandlerStart.AdjustPipelineValues();
            }
            IFlowHandler flowHandlerEnd = EndComponent as IFlowHandler;
            if (flowHandlerEnd != null)
            {
                flowHandlerEnd.AdjustPipelineValues();
            }
        }

        /// <summary>
        /// Removes the pipeline from the components that it is attached to.
        /// </summary>
        public void ClearComponents()
        {
            this.StartComponent.ClearPipeline(this);
            this.EndComponent.ClearPipeline(this);
        }

        /// <summary>
        /// Returns a string with the current and max flow of the pipeline.
        /// </summary>
        /// <returns>A string with the current and max flow.</returns>
        public string GetFlow()
        {
            return string.Format("{0}/{1}", this.CurrentFlow, this.MaxFlow);
        }

        /// <summary>
        /// Gets the text location for the current and max flow string.
        /// </summary>
        /// <returns>A point used for drawing the text.</returns>
        public Point GetTextLocation()
        {
            if (InBetweenPoints.Count > 0)
            {
                return InBetweenPoints[InBetweenPoints.Count / 2];
            }
            else
            {
                int x = (this.StartPoint.X + this.EndPoint.X) / 2;
                int y = (this.StartPoint.Y + this.EndPoint.Y) / 2;
                return new Point(x, y);
            }
        }
    }
}