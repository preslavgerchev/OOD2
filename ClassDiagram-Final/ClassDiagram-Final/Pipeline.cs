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
        public Pipeline(SerializationInfo info, StreamingContext context)
        {
            this.PipelineColor = (Color)info.GetValue("PipelineColor", PipelineColor.GetType());
            this.CurrentFlow = info.GetInt32("CurrentFlow");
            this.MaxFlow=info.GetInt32("MaxFlow");
            this.InBetweenPoints=(List<Point>)info.GetValue("InBetweenPoints", InBetweenPoints.GetType());
            this.StartComponent=(Component)info.GetValue("StartComponent", typeof(Component));
            this.EndComponent=(Component)info.GetValue("EndComponent", typeof(Component));
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
            info.AddValue("PipelineColor", PipelineColor);
            info.AddValue("CurrentFlow",CurrentFlow);
            info.AddValue("MaxFlow", MaxFlow);
            info.AddValue("InBetweenPoints", InBetweenPoints);
            info.AddValue("StartComponent", StartComponent);
            info.AddValue("EndComponent", EndComponent);

    }
}
}
