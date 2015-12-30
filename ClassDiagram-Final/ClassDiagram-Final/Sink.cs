using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Sink : Component, IFlow
    {
        private Point pipelineLocation;

        public Pipeline IncomePipeline { get; private set; }

        public Sink(int locx, int locy) :
            base(locx, locy)
        {
            this.pipelineLocation = CalculatePipelineLocation();
        }

        private Point CalculatePipelineLocation()
        {
            return new Point(ComponentBox.Left + 4, ComponentBox.Top + ComponentBox.Height / 2);
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

        public Point GetTextLocation()
        {
            return new Point(GetLocation().X + GetImage().Width / 3, GetLocation().Y + GetImage().Height / 3);
        }

        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (ComponentBox.Contains(location))
            {
                SetIncomePipeline(pipe);
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

        public override void ClearPipelines()
        {
            this.IncomePipeline = null;
        }

        public override IEnumerable<Pipeline> GetPipelines()
        {
            return new List<Pipeline>() { IncomePipeline };
        }
    }
}
