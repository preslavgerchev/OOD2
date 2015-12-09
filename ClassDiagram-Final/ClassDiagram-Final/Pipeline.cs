using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassDiagram_Final
{
    class Pipeline
    {
        // PROPERTIES
        public Color PipelineColor;
        public int CurrentFlow { get; set; }
        public int MaxFlow { get; set; }
        public List<Point> InBetweenPoints;
        public Component StartComponent { get; set; }
        public Component EndComponent { get; set; }

        // METHODS

        public int ChangeCurrentFlow(int newFlow) { return 0; }
        public bool CheckFlow() { return false; }
        public override string ToString()
        {
            return base.ToString();
        }
        public void SetStartComponent(Component c) { }
        public void SetEndComponent(Component c) { }
        
    }
}
