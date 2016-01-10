using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Network_System.Components;
using Network_System.Enums;

namespace Network_System
{
    [Serializable]
    public class Network : ISerializable
    {
        //Properties
        public List<Component> MyComponents { get; }
        public List<Pipeline> Pipelines { get; }

        //Default constructor
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

        /// <summary>
        /// Converts the file to binary and saves it in .XML format.
        /// </summary>
        /// <param name="net">The network that will be saved.</param>
        /// <param name="path">The location where the network will be saved.</param>
        public static void SaveToFile(Network net, String path)
        {
            using (FileStream fl = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fl, net);
            }
        }

        /// <summary>
        /// Deserialize a saved file.
        /// </summary>
        /// <param name="path">The path where the serialized file is located.</param>
        /// <returns>A deserialized network.</returns>
        public static Network LoadFromFile(String path)
        {
            using (FileStream fl = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fl))
                {
                    BinaryFormatter binF = new BinaryFormatter();
                    return (Network)binF.Deserialize(fl);
                }
            }
        }

        /// <summary>
        /// Adds a component to the list after checking if the component overlaps with any  of the other components.
        /// </summary>
        /// <param name="comp">The component that must be added.</param>
        /// <returns>True if the component has been added,otherwise-false.</returns>
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
        /// Removes a component from the list.
        /// </summary>
        /// <param name="c">The component that has to be removed.</param>
        public void RemoveComponent(Component c)
        {
            MyComponents.Remove(c);
        }

        /// <summary>
        /// Returns the component localized on that point of the screen.
        /// </summary>
        /// <param name="p">The location of the mouse click. </param>
        /// <returns>A component if there is one on that point.Otherwise this methods returns null.</returns>
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
        /// Adds a pipeline to the pipeline list.
        /// </summary>
        /// <param name="p">The pipeline that will be added.</param>
        public void AddPipeline(Pipeline p)
        {
            this.Pipelines.Add(p);
        }

        /// <summary>
        /// Creates a pipeline between  the starting and ending component based on their location.
        /// </summary>
        /// <param name="startComp">The starting component of the pipeline.</param>
        /// <param name="endComp">The ending component of the pipeline.</param>
        /// <param name="startCompLoc">The location of the starting component.</param>
        /// <param name="endCompLoc">The location of the ending component.</param>
        /// <param name="inbetweenPts">The list of points that the pipeline consists of.</param>
        /// <returns>A newly created pipeline.</returns>
        private Pipeline CreatePipeline(Component startComp, Component endComp, Point startCompLoc, Point endCompLoc, IList<Point> inbetweenPts)
        {
            Point startPoint = (Point)startComp.GetPipelineLocation(startCompLoc);
            Point endPoint = (Point)endComp.GetPipelineLocation(endCompLoc);
            return new Pipeline(startComp, endComp, startPoint,
                endPoint, inbetweenPts);
        }

        /// <summary>
        /// Creates a pipeline using the private <see cref="CreatePipeline(Component, Component, Point, Point, List{Point})"/> method.
        /// Then the pipeline is added to the list. 
        /// </summary>
        /// <param name="startComp">The starting component of the pipeline.</param>
        /// <param name="endComp">The ending component of the pipeline.</param>
        /// <param name="startCompLoc">The location of the starting component.</param>
        /// <param name="endCompLoc">The location of the ending component.</param>
        /// <param name="inBetweenPts">The list of points that the pipeline consists of.</param>
        public void RegisterPipeline(Component startComp, Component endComp, Point startCompLoc, Point endCompLoc, List<Point> inBetweenPts)
        {
            if (ValidatePipeline(startComp, endComp, startCompLoc, endCompLoc))
            {
                Pipeline p = CreatePipeline(startComp, endComp, startCompLoc, endCompLoc, inBetweenPts);
                startComp.SetPipeline(startCompLoc, p);
                endComp.SetPipeline(endCompLoc, p);
                AddPipeline(p);

            }
        }

        /// <summary>
        /// Validates whether the pipeline is eligible and should be created.
        /// </summary>
        /// <param name="startComp">The starting comp of the pipeline.</param>
        /// <param name="endComp">The ending comp of the pipeline.</param>
        /// <param name="startCompLoc">The location of the starting comp.</param>
        /// <param name="endCompLoc">The location of the ending comp.</param>
        /// <remarks>The following criterias must be met
        /// 1. The location for both starting and ending point must be empty/
        /// 2. The starting comp can't be Sink.The ending comp can't be Pump.
        /// 3. The starting and ending comp must be different.</remarks>
        /// <returns>A boolean indicating whether the pipeline is eligible.</returns>
        private bool ValidatePipeline(Component startComp, Component endComp, Point startCompLoc, Point endCompLoc)
        {
            if (!(startComp.IsLocationEmpty(startCompLoc) && endComp.IsLocationEmpty(endCompLoc)))
            {
                return false;
            }
            if (startComp == endComp)
            {
                return false;
            }
            if (startComp is Sink || endComp is Pump)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Removes a pipeline from the pipeline list and sets its starting and ending component to null.
        /// </summary>
        /// <param name="c">The component for which all the pipelines will removed.</param>
        public void RemovePipeline(Component c)
        {
            foreach (var pipe in c.GetPipelines())
            {
                pipe.ClearComponents();
                this.Pipelines.Remove(pipe);
            }
        }

        /// <summary>
        /// Removes a pipeline from the list and clears its starting and ending point.
        /// </summary>
        /// <param name="p">The pipeline that will be removed.</param>
        public void RemovePipeline(Pipeline p)
        {
            p.ClearComponents();
            this.Pipelines.Remove(p);
        }

        /// <summary>
        /// Creates a component in the specified location depending on the <see cref="ComponentType"/>.
        /// </summary>
        /// <param name="type">The type of the component.</param>
        /// <param name="locx">The X location of the mouse click where the component will be created.</param>
        /// <param name="locy">The Y location of the mouse click where the component will be created.</param>
        /// <returns>A newly created component if the type matches any of those in the switch case.Otherwise-null.</returns>
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
        /// Objects to be serialized and added to the Serialization Info.
        /// </summary>
        /// <param name="info">Serialization Info.</param>
        /// <param name="context">Streaming context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MyComponents", MyComponents);
            info.AddValue("Pipelines", Pipelines);
        }
    }
}