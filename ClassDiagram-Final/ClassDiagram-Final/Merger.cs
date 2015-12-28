using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram_Final
{
    public class Merger : Component, ISplit
    {
        // PROPERTIES
        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }

        public Pipeline LowerIncomePipeline { get; private set; }
        public Pipeline UpperIncomePipeline { get; private set; }
        public Pipeline OutcomePipeline { get; private set; }
        public Merger(int locx, int locy) :
            base(locx, locy)
        {
            //not tested
            this.UpperHalf = CalculateLowerHalf();
            this.LowerHalf = CalculateUpperHalf();

        }
        //private stuff guys (and girl)
        private Rectangle CalculateUpperHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top), new Size(25, ComponentBox.Height / 2));
        }

        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top + ComponentBox.Height / 2), new Size(25, ComponentBox.Height / 2));
        }
        // METHODS
        public override Image GetImage()
        { //to be done -put images and return
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
    }
}
