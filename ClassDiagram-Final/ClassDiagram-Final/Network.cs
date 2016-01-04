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
        //Properties
        public List<Component> MyComponents { get; private set; }
        public List<Pipeline> Pipelines { get; private set; }

        //Constructors
        public Network()
        {
            this.MyComponents = new List<Component>();
            this.Pipelines = new List<Pipeline>();
        }
        //Constructor used for deserialization
        public Network(SerializationInfo info, StreamingContext context)
        {
            this.MyComponents = (List<Component>)info.GetValue("MyComponents", typeof(List<Component>));
            this.Pipelines = (List<Pipeline>)info.GetValue("Pipelines", typeof(List<Pipeline>));
        }
        //Methods 

        /// <summary>
        /// Converts the file to binnary and saves it in .XML format.
        /// </summary>
        /// <param name="net"></param>
        /// <param name="path"></param>
        public static void SaveToFile(Network net, String path)
        {
            using (FileStream fl = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fl, net);
            }
        }
        /// <summary>
        /// Deserializing a saved file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
                String exc = e.Message;
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
        /// <summary>
        /// Adds a component to the list after checking if the compoent overlaps any other component.
        /// </summary>
        /// <param name="comp"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Removes a component from the compoents list.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool RemoveComponent(Component c)
        {
            if (MyComponents.Contains(c))
            {
                MyComponents.Remove(c);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Returns the component localized in that point on the screen.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Adds a piepline to the pipeline list.
        /// </summary>
        /// <param name="p"></param>
        public void AddPipeline(Pipeline p)
        {
            this.Pipelines.Add(p);
        }
        /// <summary>
        /// Creates a pipeline between on the starting and ending component based on their locatin.
        /// </summary>
        /// <param name="startComp"></param>
        /// <param name="endComp"></param>
        /// <param name="startCompLoc"></param>
        /// <param name="endCompLoc"></param>
        /// <returns></returns>
        private Pipeline CreatePipeline(Component startComp, Component endComp, Point startCompLoc, Point endCompLoc)
        {
            Pipeline p = null;
            //this takes care of the case in which the user clicks first on a merger/splitter and then on a pump/sink 
            //- the places are simply switched 
            if (startComp is Sink || endComp is Pump)
            {
                p = new Pipeline(endComp, startComp, endComp.GetPipelineLocation(endCompLoc), startComp.GetPipelineLocation(startCompLoc));
            }
            else
            {
                p = new Pipeline(startComp, endComp, startComp.GetPipelineLocation(startCompLoc), endComp.GetPipelineLocation(endCompLoc));
            }
            return p;
        }

        /// <summary>
        /// Processes a pipeline ??
        /// </summary>
        /// <param name="startComp"></param>
        /// <param name="endComp"></param>
        /// <param name="startCompLoc"></param>
        /// <param name="endCompLoc"></param>
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
        /// <summary>
        /// Removes a pipeline from the pipeline list.
        /// </summary>
        /// <param name="c"></param>
        public void RemovePipeline(Component c)
        {
            foreach (var pipe in c.GetPipelines())
            {
                pipe.ClearComponents();
                this.Pipelines.Remove(pipe);
            }
        }
        /// <summary>
        /// Creates a component in the specified location depending on its type.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="locx"></param>
        /// <param name="locy"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Objects to be serialized
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MyComponents", MyComponents);
            info.AddValue("Pipelines", Pipelines);
        }
       
        }
    }

