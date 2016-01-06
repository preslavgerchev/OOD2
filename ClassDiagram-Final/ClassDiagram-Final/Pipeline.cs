using System;
using System.Collections.Generic;
using System.Drawing;
namespace ClassDiagram_Final
{
    [Serializable]
    public class Pipeline :IFlow
    {
        //Properties
        public double CurrentFlow { get; private set; }
        public double MaxFlow { get; private set; } = 20;
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
            GetPipelineRetangle = GetLineRectange();
        }

        /// <summary>
        /// Changes the current flow of a pipeline if it does not exceed its capacity.
        /// </summary>
        /// <param name="newFlow">The new value for the current flow.</param>
        /// <returns>True if the current flow's value has been successfully changed.Otherwise false.</returns>
        public bool ChangeCurrentFlow(double newFlow)
        {
            if (newFlow <= MaxFlow)
            {
                this.CurrentFlow = newFlow;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes this pipeline from the start and end component's properties.
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
    
        //added
        public Rectangle GetLineRectange()
        {
            return new Rectangle(StartPoint.X, StartPoint.Y - 6, EndPoint.X - StartPoint.X, 10);
        }
    }
}