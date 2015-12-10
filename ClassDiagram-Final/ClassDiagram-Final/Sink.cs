using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram_Final
{
     public class Sink : Component
    {
        public Pipeline IncomePipeline { get;private set; }
        public void SetIncomePipeline(Pipeline pipeLine) {  }

    }
}
