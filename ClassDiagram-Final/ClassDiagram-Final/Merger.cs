using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Merger : Component, ISplit, ISerializable
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
        public Merger() { }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            info.AddValue("LowerIncomePipeline",LowerIncomePipeline);
            info.AddValue("UpperIncomePipeline", UpperIncomePipeline);
            info.AddValue("OutcomePipeline", OutcomePipeline);
        }
        public Merger(SerializationInfo info, StreamingContext context): base(info,context)
        {
            this.LowerIncomePipeline = (Pipeline)info.GetValue("LowerIncomePipeline", typeof(Pipeline));
            this.UpperIncomePipeline = (Pipeline)info.GetValue("UpperIncomePipeline", typeof(Pipeline));
            this.OutcomePipeline = (Pipeline)info.GetValue("OutcomePipeline", typeof(Pipeline));
        }

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

        public Point GetPipelineLocation(Point mouseClick)
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
    }
}
