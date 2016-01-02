using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Network : ISerializable
    {
        public List<Component> MyComponents { get; private set; }
        public List<Pipeline> Pipelines { get; private set; }

        public Network()
        {
            this.MyComponents = new List<Component>();
            this.Pipelines = new List<Pipeline>();
        }

        public Network(SerializationInfo info, StreamingContext context)
        {
            this.MyComponents = (List<Component>)info.GetValue("MyComponents", typeof(List<Component>));
            this.Pipelines = (List<Pipeline>)info.GetValue("Pipelines", typeof(List<Pipeline>));
        }

        public static void SaveToFile(Network net, String path)
        {
            using (FileStream fl = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fl, net);
            }
        }

        public static Network LoadFromFile(String path)
        {
            FileStream fl = null;
            BinaryReader br;
            try
            {
                br = new BinaryReader(fl = new FileStream(path, FileMode.Open));
                BinaryFormatter binF = new BinaryFormatter();
                return (Network)binF.Deserialize(fl);
            }
            catch (Exception e)
            {
                String test = e.Message;
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

        private Pipeline CreatePipeline(Component startComp, Component endComp, Point startCompLoc, Point endCompLoc)
        {
            Pipeline p = new Pipeline(startComp, endComp, startComp.GetPipelineLocation(startCompLoc), endComp.GetPipelineLocation(endCompLoc));
            return p;
        }

        //good name plz
        public void CreateAndProcessPipeline(Component startComp, Component endComp, Point startCompLoc, Point endCompLoc)
        {
            if (!(startComp.IsLocationEmpty(startCompLoc) && endComp.IsLocationEmpty(endCompLoc)))
            {
                return;
            }
            Pipeline p = CreatePipeline(startComp, endComp, startCompLoc, endCompLoc);
            startComp.SetPipeline(startCompLoc, p);
            endComp.SetPipeline(endCompLoc, p);
            AddPipeline(p);
        }

        public void RemovePipeline(Component c)
        {
            foreach (var pipe in c.GetPipelines())
            {
                pipe.ClearComponents();
                this.Pipelines.Remove(pipe);
            }
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
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MyComponents", MyComponents);
            info.AddValue("Pipelines", Pipelines);
        }
        //public void SetFlow(Component c, int max, int current)
        //{
        //    if (c is Pump)
        //    {
        //        Pump p = c;
        //        p.Flow = max;
        //    }
        //    }
        }
    }

