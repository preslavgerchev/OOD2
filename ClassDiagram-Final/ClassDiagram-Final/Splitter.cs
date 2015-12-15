using System;
using System.Drawing;

namespace ClassDiagram_Final
{
    public class Splitter : Component
    {
        // FIELDS
        private Rectangle upperHalf;
        private Rectangle lowerHalf;

        // PROPERTIES
        public bool IsAdjustable { get; private set; }
        public Pipeline LowerOutcomePipeline { get; private set; }
        public Pipeline UpperOutcomePipeline { get; private set; }
        public Pipeline IncomePipeline { get; private set; }

        public Splitter(int locx, int locy, bool isAdjustable = false) :// <- default - if skipped,sets to false automatically
            base(locx, locy)
        {
            this.IsAdjustable = isAdjustable;
            this.lowerHalf = CalculateLowerHalf();
            this.upperHalf = CalculateUpperHalf();
        }

        //same deal
        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(GetLocation(), new Size(this.ComponentBox.Height / 2, this.ComponentBox.Width));
        }

        private Rectangle CalculateUpperHalf()
        {
            Point point = new Point(GetLocation().X, GetLocation().Y - this.ComponentBox.Height / 2);
            return new Rectangle(point, new Size(this.ComponentBox.Height / 2, this.ComponentBox.Width));
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
            throw new NotImplementedException();
        }

        public override void UpdateFlow()
        {
            throw new NotImplementedException();
        }

        public Rectangle GetHalfOfRectangle(Point myPoint)
        {
            if (upperHalf.Contains(myPoint))
            {
                return upperHalf;
            }
            return lowerHalf;
        }
    }
}
