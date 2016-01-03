﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Pipeline
    {
        //Properties
        public Color PipelineColor { get; private set; }
        public int CurrentFlow { get; private set; }
        public int MaxFlow { get; private set; }
        public List<Point> InBetweenPoints;
        public Component StartComponent { get; private set; }
        public Component EndComponent { get; private set; }
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }

        //Constructors
        public Pipeline(Component startComp,Component endComp,Point startCompLoc,Point endCompLoc)
        {
            this.InBetweenPoints = new List<Point>();
            this.StartComponent = startComp;
            this.EndComponent = endComp;
            this.StartPoint = startCompLoc;
            this.EndPoint = endCompLoc;
        }

        //Methods
        /// <summary>
        /// Changes the current flow of a pipeline if it does not execed its capacity.
        /// </summary>
        /// <param name="newFlow"></param>
        /// <returns></returns>
        public bool ChangeCurrentFlow(int newFlow)
        {
            if (newFlow < MaxFlow)
            {
                this.CurrentFlow = newFlow;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if the flow excedes the capacity.
        /// Returns a boolean
        /// </summary>
        /// <returns></returns>
        public bool CheckFlow()
        {    //if this is for color changing -makes more sense to add another method where we call this one 
            //and based on the return boolean we change the color or we don't
            return this.CurrentFlow <= this.MaxFlow;
        }
        /// <summary>
        /// Returns a sting with information about the pipeline.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //have to see what else we might return here
            return CurrentFlow.ToString();
        }
        /// <summary>
        /// Clears the pipelines.
        /// </summary>
        public void ClearComponents()
        {
            this.StartComponent.ClearPipeline(this);
            this.EndComponent.ClearPipeline(this);
        }
    }
}
