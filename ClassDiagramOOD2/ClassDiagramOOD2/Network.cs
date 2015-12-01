using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDiagramOOD2
{
    class Network
    {
        public bool AddComponent() { return false;  }

        public bool RemoveComponent() { return false; }

        public bool RemovePipeline() { return false; }

        public bool Save() { return false; }

        public bool SaveAs() { return false; }

        public bool Load() { return false; }

        public List<Pipeline> PipleLines;
        public List<Components> myComponents;

    }
}
