using System;
using System.Drawing;

namespace ClassDiagram_Final
{
    public class Pump : Component
    {
        // PROPERTIES
        public Pipeline OutcomePipeline { get; private set; }
        public int Flow { get; private set; }

        public Pump(int locx, int locy) :
            base(locx, locy)
        {

        }
        // METHODS
        public override void UpdateFlow()
        {
            throw new NotImplementedException();
        }

        public override Image GetImage()
        {
            throw new NotImplementedException();
        }

        public void SetOutcomePipeline(Pipeline outcomePipeline)
        {
            this.OutcomePipeline = outcomePipeline;
        }

        public void SetFlow(int newFlow)
        {
            this.Flow = newFlow;
        }
    }
}
