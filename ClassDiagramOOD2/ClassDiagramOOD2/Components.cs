using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramOOD2
{
    class Components
    {
        public int LocationX;
        public int LocationY;
        public bool AttachPipeLine;

        public virtual bool IsInFigure() { return false ; }


    }
}
