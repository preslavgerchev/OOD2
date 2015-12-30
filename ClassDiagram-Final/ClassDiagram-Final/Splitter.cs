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

        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }

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

        private Point CalculateUpperHalfPoint()
        {
            return new Point(UpperHalf.Right - 4, UpperHalf.Top + UpperHalf.Width / 4);
        }

        private Point CalculateLowerHalfPoint()
        {
            return new Point(UpperHalf.Right - 4, LowerHalf.Bottom - LowerHalf.Width / 4);
        }
        #endregion
        public void SetLowerOutcomePipeline(Pipeline lowerPipeline)
        {
            this.LowerOutcomePipeline = lowerPipeline;
        }

        public void SetUpperOutcomePipeline(Pipeline upperPipeline)
        {
            this.UpperOutcomePipeline = upperPipeline;
        }

        public void SetIncomePipeline(Pipeline incomePipeline)
        {
            this.IncomePipeline = incomePipeline;
        }

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
            return new Point(0, 0);
        }

        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (UpperHalf.Contains(location))
            {
                SetUpperOutcomePipeline(pipe);
            }
            else if (LowerHalf.Contains(location))
            {
                SetLowerOutcomePipeline(pipe);
            }
        }

        public override void ClearPipelines()
        {
            this.LowerOutcomePipeline = null;
            this.UpperOutcomePipeline = null;
            this.IncomePipeline = null;
        }

        public override IEnumerable<Pipeline> GetPipelines()
        {
            return new List<Pipeline>() { UpperOutcomePipeline, LowerOutcomePipeline, IncomePipeline };
        }
    }
}
