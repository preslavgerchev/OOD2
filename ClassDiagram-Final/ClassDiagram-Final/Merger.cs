using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagram_Final
{
        public  class Merger : Component
    {
        // FIELDS
        private Rectangle upperHalf;
        private Rectangle lowerHalf;
        
        // PROPERTIES

        public Pipeline LowerIncomePipeline { get; private set; }
        public Pipeline UpperIncomePipeline { get; private  set; }
        public Pipeline OutcomePipeline { get; private  set; }
        
        // METHODS

        public void SetLowerIncomePipeline(Pipeline p) { }
        public void SetUpperIncomePipeline(Pipeline p) { }
        public void SetOutcomePipeline(Pipeline p) { }
        public Rectangle GetHalfOfComponent(Point myPoint) { return upperHalf; }
        

    }
}
