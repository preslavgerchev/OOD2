using Network_System.Interfaces;
using System.Drawing;
using System.Linq;

namespace Network_System.Extensions
{
    public static class GraphicsExtensions
    {
        private const int penWidth = 5;

        /// <summary>
        /// An extension method that is used for drawing pipelines.
        /// </summary>
        /// <param name="gr">The graphics that will draw the pipeline.</param>
        /// <param name="pipe">The pipeline that will be drawn.</param>
        public static void DrawPipeline(this Graphics gr, Pipeline pipe)
        {
            Pen pen = new Pen(pipe.PipelineColor, penWidth);
            if (pipe.InBetweenPoints.Count > 0)
            {
                gr.DrawLine(pen, pipe.StartPoint, pipe.InBetweenPoints.First());
                for (int i = 0; i < pipe.InBetweenPoints.Count - 1; i++)
                {
                    gr.DrawLine(pen, pipe.InBetweenPoints[i], pipe.InBetweenPoints[i + 1]);
                }
                gr.DrawLine(pen, pipe.InBetweenPoints.Last(), pipe.EndPoint);
            }
            else
            {
                gr.DrawLine(pen, pipe.StartPoint, pipe.EndPoint);
            }
            IFlow pipeFlow = pipe as IFlow;
            if (pipeFlow != null)
            {
                gr.DrawString(pipeFlow.GetFlow(), NetworkForm.font, Brushes.Black, pipeFlow.GetTextLocation());
            }
        }

        /// <summary>
        /// An extension method that is used for drawing the selected pipeline.
        /// </summary>
        /// <param name="gr">The graphics that will draw the selected pipeline.</param>
        /// <param name="pipe">The pipeline that will be drawn.</param>
        public static void DrawSelectedLine(this Graphics gr, Pipeline pipe)
        {
            Pen pen = new Pen(Color.Black, penWidth);
            if (pipe.InBetweenPoints.Count > 0)
            {
                gr.DrawLine(pen, pipe.StartPoint, pipe.InBetweenPoints.First());
                for (int i = 0; i < pipe.InBetweenPoints.Count - 1; i++)
                {
                    gr.DrawLine(pen, pipe.InBetweenPoints[i], pipe.InBetweenPoints[i + 1]);
                }
                gr.DrawLine(pen, pipe.InBetweenPoints.Last(), pipe.EndPoint);
            }
            else
            {
                gr.DrawLine(pen, pipe.StartPoint, pipe.EndPoint);
            }
        }
    }
}