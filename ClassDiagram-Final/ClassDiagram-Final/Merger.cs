using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram_Final
{
    public class Merger : Component
    {
        // FIELDS
        private Rectangle upperHalf;
        private Rectangle lowerHalf;

        // PROPERTIES

        public Pipeline LowerIncomePipeline { get; private set; }
        public Pipeline UpperIncomePipeline { get; private set; }
        public Pipeline OutcomePipeline { get; private set; }
        public Merger(int locx, int locy) :
            base(locx, locy)
        {
            //not tested
            this.upperHalf = CalculateLowerHalf();
            this.lowerHalf = CalculateUpperHalf();

        }
        //private stuff guys (and girl)
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
        public override Image GetImage()
        { //to be done -put images and return
            return Properties.Resources.merger;
        }

        public override void UpdateFlow()
        {  //to be discussed
            throw new NotImplementedException();
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

        public Rectangle GetHalfOfComponent(Point myPoint)
        {
            if (upperHalf.Contains(myPoint))
            {
                return upperHalf;
            }
            return lowerHalf;
        }

    }
}
