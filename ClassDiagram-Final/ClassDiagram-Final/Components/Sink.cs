using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Sink : Component, IFlow
    {
        //Fields
        private Point pipelineLocation;
        //Properties
        public Pipeline IncomePipeline { get; private set; }

        //Constructor
        public Sink(int locx, int locy) :
            base(locx, locy)
        {
            this.pipelineLocation = CalculatePipelineLocation();
        }
        
        /// <summary>
        ///  Returns a point with the location of the pipeline.
        /// </summary>
        /// <returns></returns>
        private Point CalculatePipelineLocation()
        {
            return new Point(ComponentBox.Left + 5, ComponentBox.Top + ComponentBox.Height / 2);
        }
        /// <summary>
        /// Returns sink's icon.
        /// </summary>
        /// <returns></returns>
        public override Image GetImage()
        {
            return Properties.Resources.sink;
        }
        /// <summary>
        /// Returns a string with the inming flow in the sink.
        /// </summary>
        /// <returns></returns>
        public string GetFlow()
        {
            if (this.IncomePipeline == null)
            {
                return "0.0";
            }
            return Math.Round(this.IncomePipeline.CurrentFlow, 1).ToString();
        }
        /// <summary>
        ///  Gets the text location for the flow string.
        /// </summary>
        /// <returns></returns>
        public Point GetTextLocation()
        {
            return new Point(GetLocation().X + GetImage().Width / 3, GetLocation().Y + GetImage().Height / 3);
        }
        /// <summary>
        /// Sets the incoming pipeline.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="pipe"></param>
        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (ComponentBox.Contains(location))
            {
                this.IncomePipeline = pipe;
            }
        }
        /// <summary>
        /// Returns the pipeline localized in that point.
        /// </summary>
        /// <param name="mouseClick"></param>
        /// <returns></returns>
        public override Point GetPipelineLocation(Point mouseClick)
        {
            if (ComponentBox.Contains(mouseClick))
            {
                return pipelineLocation;
            }
            return new Point(0, 0);
        }

        /// <summary>
        /// Clears the pipeline.
        /// </summary>
        /// <param name="p"></param>
        public override void ClearPipeline(Pipeline p)
        {
            if (this.IncomePipeline == p)
            {
                this.IncomePipeline = null;
            }
        }
        /// <summary>
        /// Returns all the pipelines attached to the sink.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (IncomePipeline != null) { allPipelines.Add(IncomePipeline); }
            return allPipelines;
        }
        /// <summary>
        ///  Checks if there is no component in that point
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public override bool IsLocationEmpty(Point location)
        {
            if (ComponentBox.Contains(location))
            {
                return this.IncomePipeline == null;
            }
            return false;
        }
    }
}
