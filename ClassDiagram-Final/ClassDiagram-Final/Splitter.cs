using System;
using System.Collections.Generic;
using System.Drawing;

namespace ClassDiagram_Final
{
    [Serializable]
    public class Splitter : Component, IFlow, ISplit
    {
        //Fields
        private Point upperHalfPoint;
        private Point lowerHalfPoint;
        private Point incomeHalfPoint;

        //Properties
        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }
        public Rectangle IncomeHalf { get; }

        public bool IsAdjustable { get; private set; }
        public int UpperOutComePercentage { get; private set; } = 50;
        public int LowerOutComePercentage { get; private set; } = 50;
        public Pipeline LowerOutcomePipeline { get; private set; }
        public Pipeline UpperOutcomePipeline { get; private set; }
        public Pipeline IncomePipeline { get; private set; }

        //Constructor
        public Splitter(int locx, int locy, bool isAdjustable = false) :
            base(locx, locy)
        {
            this.IsAdjustable = isAdjustable;
            this.LowerHalf = CalculateLowerHalf();
            this.UpperHalf = CalculateUpperHalf();
            this.IncomeHalf = CalculateIncomeHalf();

            this.upperHalfPoint = CalculateUpperHalfPoint();
            this.lowerHalfPoint = CalculateLowerHalfPoint();
            this.incomeHalfPoint = CalculateIncomeHalfPoint();
        }
        //Methods
        #region Calculating Methods
        /// <summary>
        /// Calculates the upper half outcoming rectangle.
        /// </summary>
        /// <returns></returns>
        private Rectangle CalculateUpperHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left + ComponentBox.Width / 2, ComponentBox.Top), new Size(25, ComponentBox.Height / 2));
        }
        /// <summary>
        /// Calculates the lower half outcoming rectangle.
        /// </summary>
        /// <returns></returns>
        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left + ComponentBox.Width / 2, ComponentBox.Top + ComponentBox.Height / 2), new Size(25, ComponentBox.Height / 2));
        }
        
        /// <summary>
        /// Calculates the incoming rectangle.
        /// </summary>
        /// <returns></returns>
        private Rectangle CalculateIncomeHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top + ComponentBox.Height / 3), new Size(25, ComponentBox.Height / 2));
        }
        /// <summary>
        /// ??
        /// </summary>
        /// <returns></returns>
        private Point CalculateUpperHalfPoint()
        {
            return new Point(UpperHalf.Right - 5, UpperHalf.Top + UpperHalf.Width / 4);
        }
        
        private Point CalculateLowerHalfPoint()
        {
            return new Point(UpperHalf.Right - 5, LowerHalf.Bottom - LowerHalf.Width / 4);
        }
        
        private Point CalculateIncomeHalfPoint()
        {
            return new Point(IncomeHalf.Left + 5, IncomeHalf.Top + IncomeHalf.Width / 4);
        }

        #endregion
        /// <summary>
        /// Returns splitter's icon.
        /// </summary>
        /// <returns></returns>
        public override Image GetImage()
        {
            if (IsAdjustable)
            {
                return Properties.Resources.adjustable_splitter;
            }
            return Properties.Resources.splitter;
        }
        /// <summary>
        /// Returns the upper flow of a splitter.
        /// </summary>
        /// <returns></returns>
        public string GetFlow()
        {
            return string.Format("{0} %", UpperOutComePercentage);
        }
        /// <summary>
        /// Sets the percentage of an adjustable splitter
        /// </summary>
        /// <param name="newPercentage"></param>
        public void AdjustPercentages(int newPercentage)
        {
            if (!IsAdjustable || newPercentage < 0 || newPercentage > 100)
            {
                return;
            }
            this.UpperOutComePercentage = newPercentage;
        }

        /// <summary>
        ///  Gets the text location for the flow string.
        /// </summary>
        /// <returns></returns>
        public Point GetTextLocation()
        {
            return new Point(ComponentBox.Left, ComponentBox.Bottom - 10);
        }

        /// <summary>
        /// Returns the pipeline based on the given point.
        /// </summary>
        /// <param name="mouseClick"></param>
        /// <returns></returns>
        public override Point GetPipelineLocation(Point mouseClick)
        {
            if (IncomePipeline == null)
            {
                return incomeHalfPoint;
            }
            else if (UpperHalf.Contains(mouseClick))
            {
                return upperHalfPoint;
            }
            else if (LowerHalf.Contains(mouseClick))
            {
                return lowerHalfPoint;
            }
            else if (IncomeHalf.Contains(mouseClick))
            {
                return incomeHalfPoint;
            }
            return new Point(0, 0);
        }
        /// <summary>
        /// Sets the pipeline depending on the location.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="pipe"></param>
        public override void SetPipeline(Point location, Pipeline pipe)
        {
            if (IncomePipeline == null)
            {
                this.IncomePipeline = pipe;
            }
            if (UpperHalf.Contains(location))
            {
                this.UpperOutcomePipeline = pipe;
            }
            else if (LowerHalf.Contains(location))
            {
                this.LowerOutcomePipeline = pipe;
            }
            else if (IncomeHalf.Contains(location))
            {
                this.IncomePipeline = pipe;
            }
        }
        /// <summary>
        /// Clears all the pipelines connected to the splitter.
        /// </summary>
        /// <param name="p"></param>
        public override void ClearPipeline(Pipeline p)
        {
            if (this.LowerOutcomePipeline == p)
            {
                this.LowerOutcomePipeline = null;
            }
            if (this.UpperOutcomePipeline == p)
            {
                this.UpperOutcomePipeline = null;
            }
            if (this.IncomePipeline == p)
            {
                this.IncomePipeline = null;
            }
        }
        /// <summary>
        ///  Checks if there is no component in that point
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public override bool IsLocationEmpty(Point location)
        {
            if (UpperHalf.Contains(location))
            {
                return this.UpperOutcomePipeline == null;
            }
            else if (LowerHalf.Contains(location))
            {
                return this.LowerOutcomePipeline == null;
            }
            else if (IncomeHalf.Contains(location))
            {
                return this.IncomePipeline == null;
            }
            return false;
        }
        /// <summary>
        /// Returns all the pipelines connected to the splitter.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (IncomePipeline != null) { allPipelines.Add(IncomePipeline); }
            if (LowerOutcomePipeline != null) { allPipelines.Add(LowerOutcomePipeline); }
            if (UpperOutcomePipeline != null) { allPipelines.Add(UpperOutcomePipeline); }
            return allPipelines;
        }
    }
}
