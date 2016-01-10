using System.Drawing;

namespace Network_System.Interfaces
{
    interface ISplit
    {
        Rectangle UpperHalf { get; }
        Rectangle LowerHalf { get; }
    }
}