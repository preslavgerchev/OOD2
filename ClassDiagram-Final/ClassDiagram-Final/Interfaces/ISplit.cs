using System.Drawing;

namespace ClassDiagram_Final
{
    public interface ISplit
    {
        Rectangle UpperHalf { get; }
        Rectangle LowerHalf { get; }
    }
}