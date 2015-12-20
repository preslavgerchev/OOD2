using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassDiagram_Final
{
   public class Network
    {
        // PROPERTIES
        public List<Component> MyComponents { get; private set; }
        public List<Pipeline> Pipelines { get; private  set; }

        public Network()
        {
            this.MyComponents = new List<Component>();
            this.Pipelines = new List<Pipeline>();
        }

        // METHODS 
        public bool AddComponent(Component comp)
        {
            foreach (Component c in MyComponents)
            {
                if (c.CheckOverlapComponent(comp))
                {
                    return false;
                }
            }
            MyComponents.Add(comp);
            return true;
        }

        public bool RemoveComponent(Component c)
        {
            if (MyComponents.Contains(c))
            {
                MyComponents.Remove(c);
                return true;
            }
            return false;
        }

        public Component GetComponent(Point p)
        {
            foreach (Component c in MyComponents)
            {
                if (c.ComponentBox.Contains(p))
                {
                    return c;
                }
            }
            return null;
        }

        public bool AddPipeline(Pipeline p)
        {
            //do some checking for intersecting pipelines - return false
            //otherwise true and add to list
            return true;
        }

        public bool RemovePipeline(Pipeline p)
        {   //same as above
            return false;
        }

        public Component CreateComponent(ComponentType type, int locx, int locy)
        {
            switch (type)
            {
                case ComponentType.MERGER:
                    return new Merger(locx, locy);
                case ComponentType.PUMP:
                    return new Pump(locx, locy);
                case ComponentType.SINK:
                    return new Sink(locx, locy);
                case ComponentType.ADJUSTABLE_SPLITTER:
                    return new Splitter(locx, locy, true);
                case ComponentType.SPLITTER:
                    return new Splitter(locx, locy);
                default:
                    return null;
            }
        }

        // baby playground  
        public bool Save(string filepath) { return false; }
        public bool SaveAs(string filepath) { return false; }
        public bool Load(string filepath) { return false; }
    }

}
