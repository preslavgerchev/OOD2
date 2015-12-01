using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramOOD2
{
    class Splitter : Components
    {
        public bool IsAdjustable;
        public bool UpdateFlow;

        public override bool IsInFigure()
        {
            return false;
        }


    }
}
