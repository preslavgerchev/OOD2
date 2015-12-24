using System.Drawing;

namespace ClassDiagram_Final
{
    public abstract class Component
    {
        private readonly int locationX;
        private readonly int locationY;

        public Rectangle ComponentBox { get; private set; }

        public Component(int locx, int locy)
        {

            this.locationX = locx - GetImage().Width / 2;//sets the X to the upper-left corner
            this.locationY = locy - GetImage().Height / 2; //sets the Y to the upper-left corner
            ComponentBox = new Rectangle(new Point(locationX - 5, locationY - 5), new Size(GetImage().Width, GetImage().Height));
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
    }
}
