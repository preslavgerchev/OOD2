using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2WPF
{
    public class Pump : Component
    {   
      
        public Pump(int locX, int locY,int maxFlow)
            : base(locX, locY,maxFlow)
        {

        }
        public override Image GetImage()
        {
            return Properties.Resources.pump;
        }
    }
}
