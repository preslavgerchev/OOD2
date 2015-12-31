using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Merger : Component, ISplit
    {
        private Point lowerHalfPoint;
        private Point upperHalfPoint;
        private Point outcomingHalf;

        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }
        public Rectangle OutcomingHalf { get; }

        public Pipeline LowerIncomePipeline { get; private set; }
        public Pipeline UpperIncomePipeline { get; private set; }
        public Pipeline OutcomePipeline { get; private set; }

        public Merger(int locx, int locy) :
            base(locx, locy)
        {
            this.UpperHalf = CalculateLowerHalf();
            this.LowerHalf = CalculateUpperHalf();
            this.OutcomingHalf = CalculateOutcomingHalf();
            this.upperHalfPoint = CalculateUpperHalfPoint();
            this.lowerHalfPoint = CalculateLowerHalfPoint();
            this.outcomingHalf = CalculateOutcomingHalfPoint();
            
        }

        #region Calculating Methods
        private Rectangle CalculateUpperHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top), new Size(25, ComponentBox.Height / 2));
        }

        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top + ComponentBox.Height / 2), new Size(25, ComponentBox.Height / 2));
        }
        //this
        private Rectangle CalculateOutcomingHalf()
        {
            return new Rectangle(new Point(ComponentBox.Right, ComponentBox.Top + (ComponentBox.Height / 3) * 2), new Size(25, ComponentBox.Height / 3 * 2));
        }
        private Point CalculateUpperHalfPoint()
        {
            return new Point(UpperHalf.Left + 4, UpperHalf.Top + UpperHalf.Width / 2);
        }

        private Point CalculateLowerHalfPoint()
        {
            return new Point(UpperHalf.Left + 4, LowerHalf.Bottom - LowerHalf.Width / 2);
        }
        //this
        private Point CalculateOutcomingHalfPoint()
        {
            return new Point(UpperHalf.Right + OutcomingHalf.Width/3, OutcomingHalf.Width/3 + OutcomingHalf.Width /3*2);
        }
        #endregion

        public override Image GetImage()
        {
            return Properties.Resources.merger;
        }
        
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
            
            else if (OutcomingHalf.Contains(mouseClick))
            {
                return outcomingHalf;
            }
            return new Point(0, 0);
        }

        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (UpperHalf.Contains(location))
            {
                this.UpperIncomePipeline = pipe;
            }
            else if (LowerHalf.Contains(location))
            {
                this.LowerIncomePipeline = pipe;
            }
            else if (OutcomingHalf.Contains(location))
            {
                this.OutcomePipeline = pipe;
            }
        }


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

        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (LowerIncomePipeline != null) { allPipelines.Add(LowerIncomePipeline); }
            if (UpperIncomePipeline != null) { allPipelines.Add(UpperIncomePipeline); }
            if (OutcomePipeline != null) { allPipelines.Add(OutcomePipeline); }
            return allPipelines;
        }
    }
}
