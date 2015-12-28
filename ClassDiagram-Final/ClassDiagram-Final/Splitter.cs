using System;
using System.Drawing;
using System.Runtime.Serialization;
namespace ClassDiagram_Final
{ [Serializable]
    public class Splitter : Component, IFlow, ISplit, ISerializable
    {
        // PROPERTIES
        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }

        public bool IsAdjustable { get; private set; }
        public int UpperOutComePercentage { get; private set; } = 50;
        public int LowerOutComePercentage { get; private set; } = 50;
        public Pipeline LowerOutcomePipeline { get; private set; }
        public Pipeline UpperOutcomePipeline { get; private set; }
        public Pipeline IncomePipeline { get; private set; }

      

        public Splitter(int locx, int locy, bool isAdjustable = false) :// <- default - if skipped,sets to false automatically
            base(locx, locy)
        {
            this.IsAdjustable = isAdjustable;
            this.LowerHalf = CalculateLowerHalf();
            this.UpperHalf = CalculateUpperHalf();
        }

        //same deal
        private Rectangle CalculateUpperHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left+ComponentBox.Width/2, ComponentBox.Top), new Size(25, ComponentBox.Height / 2));
        }

        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left+ComponentBox.Width/2, ComponentBox.Top + ComponentBox.Height / 2), new Size(25, ComponentBox.Height / 2));
        }

        // METHODS

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


        public Rectangle GetHalfOfComponent(Point myPoint)
        {
            if (UpperHalf.Contains(myPoint))
            {
                return UpperHalf;
            }
            else if (LowerHalf.Contains(myPoint))
            {
                return LowerHalf;
            }
            return new Rectangle();
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
    }
}
