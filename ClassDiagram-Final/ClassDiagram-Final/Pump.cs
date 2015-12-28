using System;
using System.Drawing;
using System.Runtime.Serialization;
namespace ClassDiagram_Final
{
    [Serializable]
    public class Pump : Component, IFlow, ISerializable
    {
        // PROPERTIES
        public Pipeline OutcomePipeline { get; private set; }
        public int Flow { get; private set; }

        public Pump(int locx, int locy) :
            base(locx, locy)
        {

        }
        // METHODS
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("Flow", Flow);
            info.AddValue("OutcomePipeline", OutcomePipeline);
        }
        public Pump(SerializationInfo info, StreamingContext context): base(info,context)
        {
            this.Flow = info.GetInt32("Flow");
            this.OutcomePipeline = (Pipeline)info.GetValue("OutcomePipeline", typeof(Pipeline));
        }
        public override Image GetImage()
        {
            return Properties.Resources.pump;
        }

        public void SetOutcomePipeline(Pipeline outcomePipeline)
        {
            this.OutcomePipeline = outcomePipeline;
            SetFlow(OutcomePipeline.CurrentFlow);
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
    }
}
