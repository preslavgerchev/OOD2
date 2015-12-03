using System.Drawing;

namespace OOD2WPF
{
    class Merger : Component
    {
        public int UpperFlow { get; private set; } = 0;
        public int /*Downer*/ LowerFlow { get; private set; } = 0;
        private const int DefaultCurrentFlow = 0;

        public Merger(int locX, int locY, int maxFlow)
            : base(locX, locY, DefaultCurrentFlow, maxFlow)
        {

        }

        public override Image GetImage()
        {
            return Properties.Resources.pump;
            //needs to be changed to a proper image of a merger.
        }

        public void SetUpperFlow(int upperFlow)
        {
            this.UpperFlow = upperFlow;
        }

        public void SetLowerFlow(int lowerFlow)
        {
            this.LowerFlow = lowerFlow;
        }

        public int GetTotalFLow()
        {
            return this.LowerFlow + this.UpperFlow;
        }
    }
}
