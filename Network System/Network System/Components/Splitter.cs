using System;
using System.Collections.Generic;
using System.Drawing;
using Network_System.Interfaces;

namespace Network_System.Components
{
    [Serializable]
    public class Splitter : Component, IFlow, ISplit, IFlowHandler
    {
        //Fields
        private Point upperHalfPoint;
        private Point lowerHalfPoint;
        private Point incomeHalfPoint;

        public event Action PipelineValueChanged;

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

            PipelineValueChanged += AdjustPipelineValues;
        }

        #region Calculating Methods

        /// <summary>
        /// Calculates the upper half outcoming rectangle.
        /// </summary>
        /// <returns>The rectangle of the upper half.</returns>
        private Rectangle CalculateUpperHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left + ComponentBox.Width / 2, ComponentBox.Top), new Size(25, ComponentBox.Height / 2));
        }

        /// <summary>
        /// Calculates the lower half outgoing rectangle.
        /// </summary>
        /// <returns>The rectangle of the lower half.</returns>
        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left + ComponentBox.Width / 2, ComponentBox.Top + ComponentBox.Height / 2), new Size(25, ComponentBox.Height / 2));
        }

        /// <summary>
        /// Calculates the incoming half rectangle.
        /// </summary>
        /// <returns>The rectangle of the incoming half.</returns>
        private Rectangle CalculateIncomeHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top + ComponentBox.Height / 3), new Size(25, ComponentBox.Height / 2));
        }

        /// <summary>
        /// Calculates the point that will be used for pipeline connection of the upper half.
        /// </summary>
        /// <returns>The point that will be used for pipelines connection.</returns>
        private Point CalculateUpperHalfPoint()
        {
            return new Point(UpperHalf.Right - 5, UpperHalf.Top + UpperHalf.Width / 4);
        }

        /// <summary>
        /// Calculates the point that will be used for pipeline connection of the lower half.
        /// </summary>
        /// <returns>The point that will be used for pipelines connection.</returns>
        private Point CalculateLowerHalfPoint()
        {
            return new Point(UpperHalf.Right - 5, LowerHalf.Bottom - LowerHalf.Width / 4);
        }

        /// <summary>
        /// Calculates the point that will be used for pipeline connection of the incoming half.
        /// </summary>
        /// <returns>The point that will be used for pipelines connection.</returns>
        private Point CalculateIncomeHalfPoint()
        {
            return new Point(IncomeHalf.Left + 5, IncomeHalf.Top + IncomeHalf.Width / 4);
        }

        #endregion

        /// <summary>
        /// The Splitter's image that is used for painting.
        /// </summary>
        /// <returns>The Splitter's image.</returns>
        public override Image GetImage()
        {
            if (IsAdjustable)
            {
                return Properties.Resources.adjustable_splitter;
            }
            return Properties.Resources.splitter;
        }

        /// <summary>
        /// Returns a string with the percentage of the upper outcoming pipeline.
        /// </summary>
        /// <returns>A string with the current upper outcoming percentage.</returns>
        public string GetFlow()
        {
            return string.Format("{0} %", UpperOutComePercentage);
        }

        /// <summary>
        /// Sets the percentage of the upper outcoming pipeline of an adjustable splitter.
        /// </summary>
        /// <param name="newPercentage">The new value for  the percentage.</param>
        public void AdjustPercentages(int newPercentage)
        {
            if (!IsAdjustable || newPercentage < 0 || newPercentage > 100)
            {
                return;
            }
            this.UpperOutComePercentage = newPercentage;
            this.LowerOutComePercentage = 100 - this.UpperOutComePercentage;
            if (PipelineValueChanged != null)
            {
                PipelineValueChanged();
            }
        }

        /// <summary>
        /// Part of the IFlowHandler interface. Called when the PipeLineValue is raised.
        /// Updates all the values of the connected pipelines.
        /// </summary>
        public void AdjustPipelineValues()
        {
            if (this.UpperOutcomePipeline != null)
            {
                double currentPercentage = ((double)UpperOutComePercentage) / 100;
                double newFlow = 0;
                if (IncomePipeline != null)
                {
                    newFlow = IncomePipeline.CurrentFlow * currentPercentage;
                }
                this.UpperOutcomePipeline.ChangeCurrentFlow(newFlow);
                IFlowHandler flowHandler = UpperOutcomePipeline.EndComponent as IFlowHandler;
                if (flowHandler != null && UpperOutcomePipeline.EndComponent != this)
                {
                    flowHandler.AdjustPipelineValues();
                }
            }
            if (this.LowerOutcomePipeline != null)
            {
                double currentPercentage = ((double)LowerOutComePercentage) / 100;
                double newFlow = 0;
                if (IncomePipeline != null)
                {
                    newFlow = IncomePipeline.CurrentFlow * currentPercentage;
                }
                this.LowerOutcomePipeline.ChangeCurrentFlow(newFlow);
                IFlowHandler flowHandler = LowerOutcomePipeline.EndComponent as IFlowHandler;
                if (flowHandler != null && LowerOutcomePipeline.EndComponent != this)
                {
                    flowHandler.AdjustPipelineValues();
                }
            }
        }

        /// <summary>
        /// Gets the text location for the upper outcoming pipeline's percentage.
        /// </summary>
        /// <returns>A point used for drawing the text.</returns>
        public Point GetTextLocation()
        {
            return new Point(ComponentBox.Left, ComponentBox.Bottom - 10);
        }

        /// <summary>
        /// Gets a concrete point that is used for connecting pipelines based on where the mouse click has been made.
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <returns>A concrete prefixed point.</returns>
        public override Point? GetPipelineLocation(Point location)
        {
            if (UpperHalf.Contains(location))
            {
                return upperHalfPoint;
            }
            else if (LowerHalf.Contains(location))
            {
                return lowerHalfPoint;
            }
            else if (IncomeHalf.Contains(location))
            {
                return incomeHalfPoint;
            }
            return null;
        }

        /// <summary>
        /// Assigns the pipeline that is being passed,based on the location.
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <param name="pipe">The pipeline that will be assigned.</param>
        public override void SetPipeline(Point location, Pipeline pipe)
        {
            Point? pipeLoc = GetPipelineLocation(location);
            if (pipeLoc == upperHalfPoint)
            {
                this.UpperOutcomePipeline = pipe;
            }
            else if (pipeLoc == lowerHalfPoint)
            {
                this.LowerOutcomePipeline = pipe;
            }
            else if (pipeLoc == incomeHalfPoint)
            {
                this.IncomePipeline = pipe;
            }
            if (PipelineValueChanged != null)
            {
                PipelineValueChanged();
            }
        }

        /// <summary>
        /// Deletes the pipeline and sets its corresponding property to null.
        /// </summary>
        /// <param name="p">The pipeline that will be deleted.</param>
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
        /// Checks if the pipeline where the mouse click has been made is not connected(null).
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <returns>True if the pipeline is null.Otherwise false.</returns>
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
        /// Gets all the connected (those that are not equal to null) pipelines.
        /// </summary>
        /// <returns>A list holding all the connected pipelines.</returns>
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