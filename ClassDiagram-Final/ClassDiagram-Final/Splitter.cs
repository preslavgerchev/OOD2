using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassDiagram_Final
{
    abstract  class Splitter : Component
    {
        // FIELDS
        private Rectangle upperHalf;
        private Rectangle lowerHalf;
        
        // PROPERTIES
        public bool IsAdjustable { get; set; }
        public Pipeline LowerOutcomePipeline { get; set; }
        public Pipeline UpperOutcomePipeline { get; set; }
        public Pipeline IncomePipeline { get; set; }

        // METHODS

        public Rectangle GetHalfsOfRectangle(Point myPoint) { return upperHalf; }
        public void SetLowerIncome(Pipeline p) { }
        public void SetUpperIncome(Pipeline p) { }
        public void SetIncomePipeline(Pipeline p) { }

        

    }
}
