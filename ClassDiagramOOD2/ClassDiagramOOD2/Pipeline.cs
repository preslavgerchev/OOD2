using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassDiagramOOD2
{
    class Pipeline 
    {
        public int StartPoint, EndPoint;
        public List<Point> Points; // for now
        public double CurrentFlow, MaxFlow;
        public Color Color; //for now

        public double ChangeFlow()
        { return 0; }

        public double CheckFlow() {
            return 0;
        }
        public string ToTheString()
        {
            return "";
        }


        

    }
}
