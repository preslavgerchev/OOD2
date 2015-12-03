
using System.Drawing;

namespace OOD2WPF
{
    public class Splitter : Component
    {
        public int UpperFlow { get; private set; } = 0;
        public int LowerFlow { get; private set; } = 0;

        public Splitter(int locx, int locy, int currFlow, int maxFlow) :
            base(locx, locy, currFlow, maxFlow)
        {

        }

        public override Image GetImage()
        {
            return Properties.Resources.pump;
            //needs to be changed to a proper image of a splitter.
        }

        public void SetUpperFlow(int upperFlow)
        {
            this.UpperFlow = upperFlow;
        }

        public void SetLowerFlow(int lowerFlow)
        {
            this.LowerFlow = lowerFlow;
        }

        public int GetCurrentFlow()
        {
            return this.LowerFlow + this.UpperFlow;
        }
    }
}
