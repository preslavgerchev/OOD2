﻿using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    public class Pipeline
    {
        // PROPERTIES
        public Color PipelineColor { get; private set; }
        public int CurrentFlow { get; private set; }
        public int MaxFlow { get; private  set; }
        public List<Point> InBetweenPoints;
        public Component StartComponent { get; private set; }
        public Component EndComponent { get; private set; }

        
        public Pipeline()
        {
            this.InBetweenPoints = new List<Point>();
        }

        // METHODS
        public bool ChangeCurrentFlow(int newFlow)
        {
            if (newFlow < MaxFlow)
            {
                this.CurrentFlow = newFlow;
                return true;
            }
            return false;
        }

        public bool CheckFlow()
        {    //if this is for color changing -makes more sense to add another method where we call this one 
            //and based on the return boolean we change the color or we don't
            return this.CurrentFlow <= this.MaxFlow;
        }

        public override string ToString()
        {   
            //have to see what else we might return here
            return CurrentFlow.ToString();
        }

        public void SetStartComponent(Component startComp)
        {
            this.StartComponent = startComp;
        }

        public void SetEndComponent(Component endComp)
        {
            this.EndComponent = endComp;
        }
    }
}
