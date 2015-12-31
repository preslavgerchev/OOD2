using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Splitter : Component, IFlow, ISplit
    {
        private Point upperHalfPoint;
        private Point lowerHalfPoint;
        private Point incomingHalfPoint;

        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }
        public Rectangle IncomingHalf { get; }

        public bool IsAdjustable { get; private set; }
        public int UpperOutComePercentage { get; private set; } = 50;
        public int LowerOutComePercentage { get; private set; } = 50;
        public Pipeline LowerOutcomePipeline { get; private set; }
        public Pipeline UpperOutcomePipeline { get; private set; }
        public Pipeline IncomePipeline { get; private set; }

        public Splitter(int locx, int locy, bool isAdjustable = false) :
            base(locx, locy)
        {
            this.IsAdjustable = isAdjustable;
            this.LowerHalf = CalculateLowerHalf();
            this.UpperHalf = CalculateUpperHalf();
            this.upperHalfPoint = CalculateUpperHalfPoint();
            this.lowerHalfPoint = CalculateLowerHalfPoint();
        }
        #region Calculating Methods
        private Rectangle CalculateUpperHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left + ComponentBox.Width / 2, ComponentBox.Top), new Size(25, ComponentBox.Height / 2));
        }

        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left + ComponentBox.Width / 2, ComponentBox.Top + ComponentBox.Height / 2), new Size(25, ComponentBox.Height / 2));
        }
        //
        private Rectangle CalculateIncomingHalf()
        {
            return new Rectangle(new Point(ComponentBox.Right, ComponentBox.Top + (ComponentBox.Height / 3) * 2), new Size(25, ComponentBox.Height / 3 * 2));
        }
        private Point CalculateUpperHalfPoint()
        {
            return new Point(UpperHalf.Right - 4, UpperHalf.Top + UpperHalf.Width / 4);
        }
        
        private Point CalculateLowerHalfPoint()
        {
            return new Point(UpperHalf.Right - 4, LowerHalf.Bottom - LowerHalf.Width / 4);
        }
        //
        private Point CalculateOutcomingHalfPoint()
        {
            return new Point(UpperHalf.Right + IncomingHalf.Width / 3, IncomingHalf.Width / 3 + IncomingHalf.Width / 3 * 2);
        }

        #endregion

        public override Image GetImage()
        {
            if (IsAdjustable)
            {
                return Properties.Resources.adjustable_splitter;
            }
            return Properties.Resources.splitter;
        }

        public string GetFlow()
        {
            return string.Format("{0} %", UpperOutComePercentage);
        }

        public void AdjustPercentages(int newPercentage)
        {
            if (!IsAdjustable || newPercentage < 0 || newPercentage > 100)
            {
                return;
            }
            this.UpperOutComePercentage = newPercentage;
        }

        public Point GetTextLocation()
        {
            return new Point(ComponentBox.Left, ComponentBox.Bottom - 10);
        }

        public override Point GetPipelineLocation(Point mouseClick)
        {
            if (UpperHalf.Contains(mouseClick))
            {
                return upperHalfPoint;
            }
            else if (LowerHalf.Contains(mouseClick))
            {
                return lowerHalfPoint;
            }
            else if (IncomingHalf.Contains(mouseClick))
            {
                return upperHalfPoint;
            }
            return new Point(0, 0);
        }

        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (UpperHalf.Contains(location))
            {
                this.UpperOutcomePipeline = pipe;
            }
            else if (LowerHalf.Contains(location))
            {
                this.LowerOutcomePipeline = pipe;
            }
            else if (UpperHalf.Contains(location))
            {
                this.IncomePipeline = pipe;
            }
        }

        public override void ClearPipeline(Pipeline p)
        {
            if (this.LowerOutcomePipeline == p)
            {
                this.LowerOutcomePipeline = null;
            }
            if (this.UpperOutcomePipeline == p)
            {
                this.UpperOutcomePipeline = null;
            }
            if (this.IncomePipeline == p)
            {
                this.IncomePipeline = null;
            }
        }

        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (IncomePipeline != null) { allPipelines.Add(IncomePipeline); }
            if (LowerOutcomePipeline != null) { allPipelines.Add(LowerOutcomePipeline); }
            if (UpperOutcomePipeline != null) { allPipelines.Add(UpperOutcomePipeline); }
            return allPipelines;
        }
    }
}
