using System.Drawing;
using System.Runtime.Serialization;
using System;

namespace ClassDiagram_Final
{
    [Serializable]
    public abstract class Component:ISerializable
    {
        private readonly int locationX;
        private readonly int locationY;

        public Rectangle ComponentBox { get; private set; }
        public Component() { }
        public Component(int locx, int locy)
        {

            this.locationX = locx - GetImage().Width / 2;//sets the X to the upper-left corner
            this.locationY = locy - GetImage().Height / 2; //sets the Y to the upper-left corner
            ComponentBox = new Rectangle(new Point(locationX - 5, locationY - 5), new Size(GetImage().Width, GetImage().Height));
        }
        public Component(SerializationInfo info, StreamingContext context)
        {
            
            this.locationX = info.GetInt32("locationX");
            this.locationY = info.GetInt32("locationY");
            this.ComponentBox = (Rectangle)info.GetValue("ComponentBox", ComponentBox.GetType());
        }
        public abstract Image GetImage();

        public virtual Point GetLocation()
        {
            return new Point(locationX, locationY);
        }

        public bool CheckOverlapComponent(Component otherComponent)
        {
            return this.ComponentBox.IntersectsWith(otherComponent.ComponentBox);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ComponentBox", ComponentBox);
            info.AddValue("locationX",locationX);
            info.AddValue("locationY", locationY);
        }
    }
}
