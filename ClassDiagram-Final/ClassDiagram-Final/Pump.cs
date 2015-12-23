using System;
using System.Drawing;

namespace ClassDiagram_Final
{
    public class Pump : Component, IFlow
    {
        // PROPERTIES
        public Pipeline OutcomePipeline { get; private set; }
        public int Flow { get; private set; }

        public Pump(int locx, int locy) :
            base(locx, locy)
        {

        }
        // METHODS
        /// <summary>
        /// Updates the flow only if the connected pipeline has the max flow bigger or equal to the new flow of the pump
        /// The method returns true if the update is done - Monica
        /// </summary>
        /// <param name="newFlow"></param>
        /// <returns></returns>

        public override Image GetImage()
        {
            return Properties.Resources.pump;
        }

        public void SetOutcomePipeline(Pipeline outcomePipeline)
        {
            this.OutcomePipeline = outcomePipeline;
        }

        public void SetFlow(int newFlow)
        {
            this.Flow = newFlow;
        }

        public string GetFlow()
        {
            return Flow.ToString();
        }

        public  Point GetTextLocation()
        {
            return new Point(GetLocation().X + GetImage().Width / 3, GetLocation().Y + GetImage().Height / 3);
        }
    }
}
