﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassDiagram_Final
{
    class Network
    {
        // PROPERTIES
        public List<Component> MyComponents { get; }
        public List<Pipeline> Pipelines { get; }
        
        
        // METHODS 
        public bool AddComponent(Component c) { return false; }
        public bool RemoveComponent(Component c) { return false; }
        public Component GetComponent(Point p) { return null; }

        public bool AddPipeline(Pipeline p) { return false; }
        public bool RemovePipeline(Pipeline p) { return p; }

        public bool Save(string filepath) { return false; }
        public bool SaveAs(string filepath) { return false; }
        public bool Load(string filepath) { return false; }
        

        


    }
}
