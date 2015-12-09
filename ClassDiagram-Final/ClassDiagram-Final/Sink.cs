using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram_Final
{
    abstract class Sink : Component
    {
        public Pipeline IncomePipeline { get; set; }
        public void SetIncomePipeline(Pipeline pipeLine) {  }

    }
}
