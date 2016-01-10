using System;
using System.Collections.Generic;
using System.Drawing;
using Network_System.Interfaces;

namespace Network_System.Components
{
    [Serializable]
    public class Merger : Component, ISplit, IFlowHandler
    {
        //Fields
        private Point lowerHalfPoint;
        private Point upperHalfPoint;
        private Point outcomingHalfPoint;

        public event Action PipelineValueChanged;

        //Properties
        public Rectangle UpperHalf { get; }
        public Rectangle LowerHalf { get; }
        public Rectangle OutcomeHalf { get; }

        public Pipeline LowerIncomePipeline { get; private set; }
        public Pipeline UpperIncomePipeline { get; private set; }
        public Pipeline OutcomePipeline { get; private set; }

        //Constructor
        public Merger(int locx, int locy) :
            base(locx, locy)
        {
            this.UpperHalf = CalculateLowerHalf();
            this.LowerHalf = CalculateUpperHalf();
            this.OutcomeHalf = CalculateOutcomeHalf();

            this.upperHalfPoint = CalculateUpperHalfPoint();
            this.lowerHalfPoint = CalculateLowerHalfPoint();
            this.outcomingHalfPoint = CalculateOutcomingHalfPoint();

            this.PipelineValueChanged += AdjustPipelineValues;
        }

        #region Calculating Methods

        /// <summary>
        /// Calculates the upper half incoming rectangle.
        /// </summary>
        /// <returns>The rectangle of the upper half.</returns>
        private Rectangle CalculateUpperHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top), new Size(25, ComponentBox.Height / 2));
        }

        /// <summary>
        /// Calculates the lower half incoming rectangle.
        /// </summary>
        /// <returns>The rectangle of the lower half.</returns>
        private Rectangle CalculateLowerHalf()
        {
            return new Rectangle(new Point(ComponentBox.Left, ComponentBox.Top + ComponentBox.Height / 2), new Size(25, ComponentBox.Height / 2));
        }

        /// <summary>
        /// Calculates the outcoming half rectangle.
        /// </summary>
        /// <returns>The rectangle of the outcoming half.</returns>
        private Rectangle CalculateOutcomeHalf()
        {
            return new Rectangle(new Point(ComponentBox.Right - ComponentBox.Width / 2, ComponentBox.Top + ComponentBox.Height / 3), new Size(25, ComponentBox.Height / 2));
        }

        /// <summary>
        /// Calculates the point that will be used for pipeline connection of the upper half.
        /// </summary>
        /// <returns>The point that will be used for pipelines connection.</returns>
        private Point CalculateUpperHalfPoint()
        {
            return new Point(UpperHalf.Left + 5, UpperHalf.Top + UpperHalf.Width / 2);
        }

        /// <summary>
        /// Calculates the point that will be used for pipeline connection of the lower half.
        /// </summary>
        /// <returns>The point that will be used for pipelines connection.</returns>
        private Point CalculateLowerHalfPoint()
        {
            return new Point(UpperHalf.Left + 5, LowerHalf.Bottom - LowerHalf.Width / 2);
        }

        /// <summary>
        /// Calculates the point that will be used for pipeline connection of the outcoming half.
        /// </summary>
        /// <returns>The point that will be used for pipelines connection.</returns>
        private Point CalculateOutcomingHalfPoint()
        {
            return new Point(OutcomeHalf.Right - 5, OutcomeHalf.Top + OutcomeHalf.Width / 4);
        }
        #endregion

        /// <summary>
        /// The Merger's image that is used for painting.
        /// </summary>
        /// <returns>The Merger's image.</returns>
        public override Image GetImage()
        {
            return Properties.Resources.merger;
        }

        /// <summary>
        /// Gets a concrete point that is used for connecting pipelines based on where the mouse click has been made.
        /// </summary>
        /// <param name="location">The location of the mouse click.</param>
        /// <returns>A concrete prefixed point.</returns>
        public override Point? GetPipelineLocation(Point mouseClick)
        {
            if (UpperHalf.Contains(mouseClick))
            {
                return upperHalfPoint;
            }
            else if (LowerHalf.Contains(mouseClick))
            {
                return lowerHalfPoint;
            }
            else if (OutcomeHalf.Contains(mouseClick))
            {
                return outcomingHalfPoint;
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
                this.UpperIncomePipeline = pipe;
            }
            else if (pipeLoc == lowerHalfPoint)
            {
                this.LowerIncomePipeline = pipe;
            }
            else if (pipeLoc == outcomingHalfPoint)
            {
                this.OutcomePipeline = pipe;
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
            if (this.UpperIncomePipeline == p)
            {
                this.UpperIncomePipeline = null;
            }
            if (this.LowerIncomePipeline == p)
            {
                this.LowerIncomePipeline = null;
            }
            if (this.OutcomePipeline == p)
            {
                this.OutcomePipeline = null;
            }
            if (PipelineValueChanged != null)
            {
                PipelineValueChanged();
            }
        }

        /// <summary>
        /// Gets all the connected (those that are not equal to null) pipelines.
        /// </summary>
        /// <returns>A list holding all the connected pipelines.</returns>
        public override IEnumerable<Pipeline> GetPipelines()
        {
            List<Pipeline> allPipelines = new List<Pipeline>();
            if (LowerIncomePipeline != null) { allPipelines.Add(LowerIncomePipeline); }
            if (UpperIncomePipeline != null) { allPipelines.Add(UpperIncomePipeline); }
            if (OutcomePipeline != null) { allPipelines.Add(OutcomePipeline); }
            return allPipelines;
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
                return this.UpperIncomePipeline == null;
            }
            else if (LowerHalf.Contains(location))
            {
                return this.LowerIncomePipeline == null;
            }
            else if (OutcomeHalf.Contains(location))
            {
                return this.OutcomePipeline == null;
            }
            return false;
        }

        /// <summary>
        /// Part of the IFlowHandler interface. Called when the PipeLineValue is raised.
        /// Updates all the values of the connected pipelines.
        /// </summary>
        public void AdjustPipelineValues()
        {
            if (OutcomePipeline == null)
            {
                return;
            }
            double upperFlow = 0;
            double lowerFlow = 0;
            if (this.UpperIncomePipeline != null)
            {
                upperFlow = this.UpperIncomePipeline.CurrentFlow;
            }
            if (this.LowerIncomePipeline != null)
            {
                lowerFlow = this.LowerIncomePipeline.CurrentFlow;
            }
            this.OutcomePipeline.ChangeCurrentFlow(upperFlow + lowerFlow);
            IFlowHandler outcomeElement = OutcomePipeline.EndComponent as IFlowHandler;
            if (outcomeElement != null && OutcomePipeline.EndComponent != this)
            {
                outcomeElement.AdjustPipelineValues();
            }
        }
    }
}