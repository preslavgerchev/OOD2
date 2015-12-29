using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace ClassDiagram_Final
{[Serializable]
    public class Pipeline:ISerializable
    {
        // PROPERTIES
        public Color PipelineColor { get; private set; }
        public int CurrentFlow { get; private set; }
        public int MaxFlow { get; private  set; }
        public List<Point> InBetweenPoints;
        public Component StartComponent { get; private set; }
        public Component EndComponent { get; private set; }
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }
        
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
        public void SetStartPoint(Point p)
        {
            this.StartPoint = p;
        }

        public void SetEndPoint(Point p)
        {
            this.EndPoint = p;
        }

        public void SetEndComponent(Component endComp)
        {
            this.EndComponent = endComp;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
