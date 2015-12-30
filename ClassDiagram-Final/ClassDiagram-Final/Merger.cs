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

        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }

        public Pipeline LowerIncomePipeline { get; private set; }
        public Pipeline UpperIncomePipeline { get; private set; }
        public Pipeline OutcomePipeline { get; private set; }

        public Merger(int locx, int locy) :
            base(locx, locy)
        {
            this.UpperHalf = CalculateLowerHalf();
            this.LowerHalf = CalculateUpperHalf();
            this.upperHalfPoint = CalculateUpperHalfPoint();
            this.lowerHalfPoint = CalculateLowerHalfPoint();
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

        private Point CalculateUpperHalfPoint()
        {
            return new Point(UpperHalf.Left + 4, UpperHalf.Top + UpperHalf.Width / 2);
        }

        private Point CalculateLowerHalfPoint()
        {
            return new Point(UpperHalf.Left + 4, LowerHalf.Bottom - LowerHalf.Width / 2);
        }
        #endregion

        public override Image GetImage()
        {
            return Properties.Resources.merger;
        }

        public void SetLowerIncomePipeline(Pipeline lowerPipeline)
        {
            this.LowerIncomePipeline = lowerPipeline;
        }

        public void SetUpperIncomePipeline(Pipeline upperPipeline)
        {
            this.UpperIncomePipeline = upperPipeline;
        }

        public void SetOutcomePipeline(Pipeline outcomePipeline)
        {
            this.OutcomePipeline = outcomePipeline;
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
            return new Point(0, 0);
        }

        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (UpperHalf.Contains(location))
            {
                SetUpperIncomePipeline(pipe);
            }
            else if (LowerHalf.Contains(location))
            {
                SetLowerIncomePipeline(pipe);
            }
        }

        public override void ClearPipelines()
        {
            this.UpperIncomePipeline = null;
            this.LowerIncomePipeline = null;
            this.OutcomePipeline = null;
        }

        public override IEnumerable<Pipeline> GetPipelines()
        {
            return new List<Pipeline>() { LowerIncomePipeline, UpperIncomePipeline, OutcomePipeline };
        }
    }
}
