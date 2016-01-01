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
            return new Point(ComponentBox.Left + 5, ComponentBox.Top + ComponentBox.Height / 2);
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
                this.IncomePipeline = pipe;
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
            if (this.IncomePipeline == p)
            {
                this.IncomePipeline = null;
            }
        }
        public override bool CheckIfConnected(Point location)
        {
            if (IncomePipeline == null)
                return false;
            else return true;
        }
        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (IncomePipeline != null) { allPipelines.Add(IncomePipeline); }
            return allPipelines;
        }
    }
}
