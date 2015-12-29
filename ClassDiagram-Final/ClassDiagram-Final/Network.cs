using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Network : ISerializable
    {
        private static readonly string _FILE_PATH = "Network.DAT";
        // PROPERTIES
        
        public List<Component> MyComponents { get; private set; }
        public List<Pipeline> Pipelines { get; private set; }

        public Network()
        {
            this.MyComponents = new List<Component>();
            this.Pipelines = new List<Pipeline>();
        }
        public Network(SerializationInfo info, StreamingContext context)
        {
            this.MyComponents = (List<Component>)info.GetValue("MyComponents", MyComponents.GetType());
            this.Pipelines = (List<Pipeline>)info.GetValue("Pipelines", Pipelines.GetType());
        }
        // METHODS 
        public static void SaveToFile(Network net)
        {
            using (FileStream fl = new FileStream(_FILE_PATH, FileMode.OpenOrCreate))
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fl,net );
            }
        }
        public static Network LoadFromFile()
        {
            FileStream fl = null;
            try
            {
                fl = new FileStream(_FILE_PATH, FileMode.Open);
                BinaryFormatter binF = new BinaryFormatter();
                if (fl != null)

                    return (Network)binF.Deserialize(fl);
                else return new Network();
            }
            catch
            {
                return new Network();
            }
            finally
            {
                if (fl != null)
                {
                    fl.Close();
                }
            }
        }
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

        public void AddPipeline(Pipeline p)
        {
            this.Pipelines.Add(p);
        }

        public bool RemovePipeline(Pipeline p, Component c)
        {
            Splitter splitter = c as Splitter;
            if (splitter != null)
            {
                splitter.SetIncomePipeline(null);
                splitter.SetLowerOutcomePipeline(null);
                splitter.SetUpperOutcomePipeline(null);
                return true;
            }
            Merger merger = c as Merger;
            if (merger != null)
            {
                merger.SetLowerIncomePipeline(null);
                merger.SetOutcomePipeline(null);
                merger.SetUpperIncomePipeline(null);
                return true;
            }
            Sink sink = c as Sink;
            if(splitter!=nul)
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            // i need to add the values of the things that need to be saved. idk how to add everythng
            //info.AddValue(value, type);
            //foreach (Component c in MyComponents)
            //{
            info.AddValue("MyComponents", MyComponents);
            //}
            //foreach (Pipeline p in Pipelines)
            //{ 
            info.AddValue("Pipelines", Pipelines);
            //}
        }

    }
}
