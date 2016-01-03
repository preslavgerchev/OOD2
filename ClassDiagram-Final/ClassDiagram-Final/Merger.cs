using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Merger : Component, ISplit
    {
        //Fields
        private Point lowerHalfPoint;
        private Point upperHalfPoint;
        private Point outcomingHalfPoint;

        //Properties
        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }
        public Rectangle OutcomeHalf { get; }

        public Pipeline LowerIncomePipeline { get; private set; }
        public Pipeline UpperIncomePipeline { get; private set; }
        public Pipeline OutcomePipeline { get; private set; }

        //Constructor
        public Merger(int locx, int locy) :
            base(locx, locy)
        {
            this.UpperHalf = CalculateLowerHalf();
            this.LowerHalf = CalculateUpperHalf();
            this.OutcomeHalf = CalculateOutcomeHalf();

            this.upperHalfPoint = CalculateUpperHalfPoint();
            this.lowerHalfPoint = CalculateLowerHalfPoint();
            this.outcomingHalfPoint = CalculateOutcomingHalfPoint();
        }

        //Methods
        #region Calculating Methods
            /// <summary>
            /// Calculates the upper half incoming rectangle.
            /// </summary>
            /// <returns></returns>
        private Rectangle CalculateUpperHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top), new Size(25, ComponentBox.Height / 2));
        }
            /// <summary>
            /// Calculates the lower half incoming rectangle.
            /// </summary>
            /// <returns></returns>
        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top + ComponentBox.Height / 2), new Size(25, ComponentBox.Height / 2));
        }
        /// <summary>
       /// Calculates the outcoming half rectangle.
       /// </summary>
       /// <returns></returns>
        private Rectangle CalculateOutcomeHalf()
        {
            return new Rectangle(new Point(ComponentBox.Right - ComponentBox.Width / 2, ComponentBox.Top + ComponentBox.Height / 3), new Size(25, ComponentBox.Height / 2));
        }
        /// <summary>
        /// ???
        /// </summary>
        /// <returns></returns>
        private Point CalculateUpperHalfPoint()
        {
            return new Point(UpperHalf.Left + 5, UpperHalf.Top + UpperHalf.Width / 2);
        }

        private Point CalculateLowerHalfPoint()
        {
            return new Point(UpperHalf.Left + 5, LowerHalf.Bottom - LowerHalf.Width / 2);
        }

        private Point CalculateOutcomingHalfPoint()
        {
            return new Point(OutcomeHalf.Right - 5, OutcomeHalf.Top + OutcomeHalf.Width / 4);
        }
        #endregion
        /// <summary>
        /// Returns merger's icon.
        /// </summary>
        /// <returns></returns>
        public override Image GetImage()
        {
            return Properties.Resources.merger;
        }
        /// <summary>
        /// Checks in which rectagle the mosue click was and returns that point.
        /// </summary>
        /// <param name="mouseClick"></param>
        /// <returns></returns>
        public override  Point GetPipelineLocation(Point mouseClick)
        {
            if (UpperHalf.Contains(mouseClick))
            {
                return upperHalfPoint;
            }
            else if (LowerHalf.Contains(mouseClick))
            {
                return lowerHalfPoint;
            }
            
            else if (OutcomeHalf.Contains(mouseClick))
            {
                return outcomingHalfPoint;
            }
            return new Point(0, 0);
        }
        /// <summary>
        /// Sets the pipeline depending on the location.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="pipe"></param>
        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (OutcomeHalf == null)
            {
                this.OutcomePipeline = pipe;
            }
            if (UpperHalf.Contains(location))
            {
                this.UpperIncomePipeline = pipe;
            }
            else if (LowerHalf.Contains(location))
            {
                this.LowerIncomePipeline = pipe;
            }
            else if (OutcomeHalf.Contains(location))
            {
                this.OutcomePipeline = pipe;
            }
        }
        /// <summary>
        /// Deletes the pipeline.
        /// </summary>
        /// <param name="p"></param>
        public override void ClearPipeline(Pipeline p)
        {
            if (this.UpperIncomePipeline == p)
            {
                this.UpperIncomePipeline = null;
            }
            if (this.LowerIncomePipeline == p)
            {
                this.LowerIncomePipeline = null;
            }
            if (this.OutcomePipeline == p)
            {
                this.OutcomePipeline = null;
            }
        }
        /// <summary>
        /// Returns all connected pipelines.
        /// </summary>
        /// <returns></returns>

        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (LowerIncomePipeline != null) { allPipelines.Add(LowerIncomePipeline); }
            if (UpperIncomePipeline != null) { allPipelines.Add(UpperIncomePipeline); }
            if (OutcomePipeline != null) { allPipelines.Add(OutcomePipeline); }
            return allPipelines;
        }

        /// <summary>
        /// Checks if there is no pipeline connected to that location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public override bool IsLocationEmpty(Point location)
        {
            if (UpperHalf.Contains(location))
            {
                return this.UpperIncomePipeline == null;
            }
            else if (LowerHalf.Contains(location))
            {
                return this.LowerIncomePipeline == null;
            }
            else if(OutcomeHalf.Contains(location))
            {
                return this.OutcomePipeline == null;
            }
            return false;
        }
    }
}
