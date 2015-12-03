using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD2WPF
{
    public class Sink : Component
    {
      
        public Sink(int locX, int locY,int currFlow,int maxFlow) :
            base(locX, locY,currFlow,maxFlow)
        {

        }

        public override Image GetImage()
        {
            return Properties.Resources.sink;
        }
    }
}
