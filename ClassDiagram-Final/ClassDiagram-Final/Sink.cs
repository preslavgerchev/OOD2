using System;
using System.Drawing;

namespace ClassDiagram_Final
{
     public class Sink : Component
    {
        public Pipeline IncomePipeline { get;private set; }

        public Sink(int locx,int locy):
            base(locx,locy)
        {

        }

        public void SetIncomePipeline(Pipeline incomePipeline)
        {
            this.IncomePipeline = incomePipeline;
        }

        public override void UpdateFlow()
        {
            throw new NotImplementedException();
        }

        public override Image GetImage()
        {
            return Properties.Resources.sink;
        }
    }
}
