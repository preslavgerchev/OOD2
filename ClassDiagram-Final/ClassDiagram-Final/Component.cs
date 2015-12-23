using System.Drawing;

namespace ClassDiagram_Final
{
    public abstract class Component
    {

        // FIELDS
        private int locationX;
        private int locationY;

        // PROPERTIES
        public Rectangle ComponentBox { get; private set; }
        public Component(int locx, int locy)
        {

            this.locationX = locx - GetImage().Width / 2;//sets the X to the upper-left corner
            this.locationY = locy - GetImage().Height / 2; //sets the Y to the upper-left corner
            ComponentBox = new Rectangle(new Point(locationX - 5, locationY - 5), new Size(GetImage().Width, GetImage().Height));
        }
        // METHODS
        public abstract Image GetImage();

        public virtual Point GetLocation()
        {
            //sets it to the center of the image and rectangle
            //will be used when connecting pipelines  - so they can go straight to the center
            return new Point(locationX, locationY);
        }

        public bool CheckOverlapComponent(Component otherComponent)
        {
            return this.ComponentBox.IntersectsWith(otherComponent.ComponentBox);
        }
    }
}
