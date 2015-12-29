using System.Drawing;

namespace ClassDiagram_Final
{
    public interface ISplit
    {
        Rectangle GetHalfOfComponent(Point p);
        Rectangle UpperHalf { get; }
        Rectangle LowerHalf { get; }
        Point GetPipelineLocation(Point mouseClick);
    }
}
