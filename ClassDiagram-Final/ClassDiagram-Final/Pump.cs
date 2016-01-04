﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Pump : Component, IFlow
    {
        //Fields
        private Point pipelineLocation;

        //Properties
        public Pipeline OutcomePipeline { get; private set; }
        public int Flow { get; private set; }
        public int Capacity { get; private set;  }

        //Constructor
        public Pump(int locx, int locy) :
            base(locx, locy)
        {
            this.pipelineLocation = CalculaltePipelineLocation();
        }
        //Methods
        /// <summary>
        /// Sets the flow of the pump if it does not exced its capacity.
        /// </summary>
        /// <param name="max"></param>
        /// <param name="current"></param>
        public void SetFlow(int max, int current)
        {
            if (current <= max)
            {
                this.Flow = current;
                this.Capacity = max;
                if (OutcomePipeline != null)
                {
                    this.OutcomePipeline.ChangeCurrentFlow(current);
                }
            }
        }
        /// <summary>
        /// Returns a point with the location of the pipeline.
        /// </summary>
        /// <returns></returns>
        private Point CalculaltePipelineLocation()
        {
            return new Point(ComponentBox.Right - 5, ComponentBox.Top + ComponentBox.Height / 2);
        }
        /// <summary>
        /// Returns pump's icon.
        /// </summary>
        /// <returns></returns>
        public override Image GetImage()
        {
            return Properties.Resources.pump;
        }
        
        /// <summary>
        /// Returns a string with the flow of the pump.
        /// </summary>
        /// <returns></returns>

        public string GetFlow()
        {
            return "("+Flow.ToString() + "/" + Capacity.ToString()+")" ;
        }
        /// <summary>
        /// Gets the text location for the flow string.
        /// </summary>
        /// <returns></returns>
        public Point GetTextLocation()
        {
            return new Point(GetLocation().X + GetImage().Width / 3, GetLocation().Y + GetImage().Height / 3);
        }

        /// <summary>
        /// Sets the outcoming pipeline.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="pipe"></param>
        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (ComponentBox.Contains(location))
            {
                this.OutcomePipeline = pipe;
                this.OutcomePipeline.ChangeCurrentFlow(Flow);
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
            if (this.OutcomePipeline == p)
            {
                this.OutcomePipeline = null;
            }
        }
        /// <summary>
        /// Returns all pipelines attached to the pump
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (OutcomePipeline != null) { allPipelines.Add(OutcomePipeline); }
            return allPipelines;
        }
        /// <summary>
        /// Checks if there is no component in that point
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public override bool IsLocationEmpty(Point location)
        {
            if (ComponentBox.Contains(location))
            {
                return this.OutcomePipeline == null;
            }
            return false;
        }
    }
}
