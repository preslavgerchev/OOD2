using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace ClassDiagram_Final
{ [Serializable]
    public class Merger : Component, ISplit , ISerializable
    {
        // PROPERTIES
        public Rectangle UpperHalf { get;  }
        public Rectangle LowerHalf { get;  }

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
