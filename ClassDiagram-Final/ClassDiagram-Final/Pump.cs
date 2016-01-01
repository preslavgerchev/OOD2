using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Pump : Component, IFlow
    {
        private Point pipelineLocation;

        public Pipeline OutcomePipeline { get; private set; }
        public int Flow { get; private set; }

        public Pump(int locx, int locy) :
            base(locx, locy)
        {
            this.pipelineLocation = CalculaltePipelineLocation();
        }
        public bool CheckAttachedPipeline()
        {
            if (OutcomePipeline == null)
                return false;
            else return true;
        }
        private Point CalculaltePipelineLocation()
        {
            return new Point(ComponentBox.Right - 5, ComponentBox.Top + ComponentBox.Height / 2);
        }

        public override Image GetImage()
        {
            return Properties.Resources.pump;
        }

        private void SetFlow(int newFlow)
        {
            this.Flow = newFlow;
        }

        public string GetFlow()
        {
            return Flow.ToString();
        }

        public Point GetTextLocation()
        {
            return new Point(GetLocation().X + GetImage().Width / 3, GetLocation().Y + GetImage().Height / 3);
        }

        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (ComponentBox.Contains(location))
            {
                this.OutcomePipeline = pipe;
            }
        }

        public override Point GetPipelineLocation(Point mouseClick)
        {
            if (ComponentBox.Contains(mouseClick))
            {
                return pipelineLocation;
            }
            return new Point(0, 0);
        }

        public override void ClearPipeline(Pipeline p)
        {
            if (this.OutcomePipeline == p)
            {
                this.OutcomePipeline = null;
            }
        }

        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (OutcomePipeline != null) { allPipelines.Add(OutcomePipeline); }
            return allPipelines;
        }
    }
}
