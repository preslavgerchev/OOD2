using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram_Final
{
   abstract class Pump : Component
    {
        // PROPERTIES
        public Pipeline OutcomePipeline { get; set; }
        public int Flow { get; set; }

        // METHODS
        public void SetOutcomePipeline(Pipeline p) {  }
        public void SetFlow(int newFlow) { }

    }

}
