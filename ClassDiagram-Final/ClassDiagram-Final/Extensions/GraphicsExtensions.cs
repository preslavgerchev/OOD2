using System.Drawing;
using System.Linq;

namespace ClassDiagram_Final
{
    public static class GraphicsExtensions
    {
        public static void DrawPipeline(this Graphics gr, Pipeline pipe)
        {
            Pen pen = new Pen(pipe.PipelineColor, 5);
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
