using System;
using System.Drawing;
using System.Runtime.Serialization;
namespace ClassDiagram_Final
{ 
    [Serializable]
    public class Sink : Component, IFlow
    {
        public Pipeline IncomePipeline { get; private set; }

        public Sink(int locx, int locy) :
            base(locx, locy)
        {

        }
        
        public void SetIncomePipeline(Pipeline incomePipeline)
        {
            this.IncomePipeline = incomePipeline;
        }

        public override Image GetImage()
        {
            return Properties.Resources.sink;
        }

        public string GetFlow()
        {
            if (this.IncomePipeline == null)
            {
                return "0";
            }
            return this.IncomePipeline.CurrentFlow.ToString();
        }

        public  Point GetTextLocation()
        {
            return new Point(GetLocation().X + GetImage().Width / 3, GetLocation().Y + GetImage().Height / 3);
        }
    }
}
