using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using Network_System.Enums;
using Network_System.Components;
using Network_System.Extensions;
using Network_System.Interfaces;

namespace Network_System
{
    public partial class NetworkForm : Form
    {
        //Fields
        public static Font font;
        Network myNetwork;

        ComponentType type = ComponentType.NONE;
        Component selectedComponent;
        Pipeline selectedPipeline;
        List<Point> inbetweenPts;
        Component startComp;
        Component endComp;
        Point startCompLoc;
        Point endCompLoc;

        Point selectedPipelineLoc = new Point(0, 0);

        string FILE_PATH = "";
        bool saved;

        public NetworkForm()
        {
            //intialization of the fields.
            InitializeComponent();
            myNetwork = new Network();
            panel1.Paint += panel1_Paint;
            splitterTrackBar.Visible = false;
            AdjSplitLb.Visible = false;
            AdjSplitLb1.Visible = false;
            inbetweenPts = new List<Point>();
            font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            saved = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (selectedComponent != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, selectedComponent.ComponentBox);

            }
            SelectALine(e.Graphics, selectedPipelineLoc);
            DrawImages(e.Graphics);
            DrawPipelines(e.Graphics);
            if (selectedPipeline != null)
            {
                e.Graphics.DrawSelectedLine(selectedPipeline);
                this.tbCurrentFlow.Text = selectedPipeline.CurrentFlow.ToString();
                this.tbCapacity.Text = selectedPipeline.MaxFlow.ToString();
            }
        }

        private void btnPump_Click(object sender, EventArgs e)
        {
            type = ComponentType.PUMP;
            ClearVariables();
        }

        private void SelectALine(Graphics gr, Point mouseClick)
        {
            using (var path = new GraphicsPath())
            {
                foreach (var p in myNetwork.Pipelines)
                {
                    Point[] pts = new Point[p.InBetweenPoints.Count + 2];
                    pts[0] = p.StartPoint;
                    for (int i = 0; i < p.InBetweenPoints.Count; i++)
                    {
                        pts[i + 1] = p.InBetweenPoints[i];
                    }
                    pts[p.InBetweenPoints.Count + 1] = p.EndPoint;
                    path.AddLines(pts);
                    if (path.IsOutlineVisible(mouseClick, new Pen(Color.Orange, 8), gr))
                    {
                        selectedPipeline = p;
                        break;
                    }
                }
            }
        }

        private void btnSink_Click(object sender, EventArgs e)
        {
            type = ComponentType.SINK;
            ClearVariables();
        }

        private void btnSplitter_Click(object sender, EventArgs e)
        {
            type = ComponentType.SPLITTER;
            ClearVariables();
        }

        private void btnMerger_Click(object sender, EventArgs e)
        {
            type = ComponentType.MERGER;
            ClearVariables();
        }

        private void btnAdjSplitter_Click(object sender, EventArgs e)
        {
            type = ComponentType.ADJUSTABLE_SPLITTER;
            ClearVariables();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedComponent != null)
            {
                myNetwork.RemoveComponent(selectedComponent);
                myNetwork.RemovePipeline(selectedComponent);
                selectedComponent = null;
                type = ComponentType.NONE;
                if (splitterTrackBar.Visible)
                {
                    splitterTrackBar.Visible = false;
                    AdjSplitLb1.Visible = false;
                    AdjSplitLb.Visible = false;
                }
            }
            if (selectedPipeline != null)
            {
                myNetwork.RemovePipeline(selectedPipeline);
                selectedPipeline = null;
                selectedPipelineLoc = new Point(0, 0);
                type = ComponentType.NONE;
            }
            this.tbCapacity.Text = "";
            this.tbCurrentFlow.Text = "";
            panel1.Invalidate();
        }

        private void DrawImages(Graphics gr)
        {
            foreach (var comp in myNetwork.MyComponents)
            {
                gr.DrawImage(comp.GetImage(), comp.GetLocation());
                IFlow flowComp = comp as IFlow;
                if (flowComp != null)
                {
                    gr.DrawString(flowComp.GetFlow(), font, Brushes.Black, flowComp.GetTextLocation());
                }
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectedComponent = myNetwork.GetComponent(e.Location);

            Pump p = selectedComponent as Pump;
            if (p != null)
            {
                this.tbCurrentFlow.Text = p.Flow.ToString();
                this.tbCapacity.Text = p.Capacity.ToString();
            }

            Components.Splitter splitterComp = selectedComponent as Components.Splitter;
            if (splitterComp != null && splitterComp.IsAdjustable)
            {
                splitterTrackBar.Visible = true;
                AdjSplitLb.Visible = true;
                AdjSplitLb1.Visible = true;
            }
            else
            {
                splitterTrackBar.Visible = false;
                AdjSplitLb.Visible = false;
                AdjSplitLb1.Visible = false;
            }
            if (selectedComponent != null)
            {
                selectedPipeline = null;
                selectedPipelineLoc = new Point(0, 0);
            }
            else
            {
                selectedPipelineLoc = e.Location;
            }
            panel1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ((Components.Splitter)selectedComponent).AdjustPercentages(splitterTrackBar.Value);
            panel1.Invalidate();
        }

        private void DrawPipelines(Graphics gr)
        {
            foreach (Pipeline p in myNetwork.Pipelines)
            {
                gr.DrawPipeline(p);
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Title = "Save netowork";
            myDialog.DefaultExt = ".XML";
            if (myDialog.ShowDialog() == DialogResult.OK & myDialog.FileName != null)
            {
                Network.SaveToFile(myNetwork, myDialog.FileName);
                FILE_PATH = myDialog.FileName;
                saved = true;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to save your changes?", "Save?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                btnSaveAs.PerformClick();
                OpenFileDialog load = new OpenFileDialog();
                if (load.ShowDialog() == DialogResult.OK)
                {
                    load.Title = "Load from file";
                    FILE_PATH = load.FileName;
                    myNetwork = Network.LoadFromFile(load.FileName);
                    panel1.Invalidate();
                }
            }
            else if (dialog == DialogResult.No)
            {
                OpenFileDialog load = new OpenFileDialog();
                if (load.ShowDialog() == DialogResult.OK)
                {
                    FILE_PATH = load.FileName;
                    load.Title = "Load from file";
                    myNetwork = Network.LoadFromFile(load.FileName);
                    panel1.Invalidate();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to save it?", "Save?", MessageBoxButtons.YesNoCancel);
            if (dialog == DialogResult.Yes)
            {
                if (saved)
                {
                    Network.SaveToFile(myNetwork, FILE_PATH);
                    base.OnFormClosing(e);
                }
                else
                {
                    btnSaveAs.PerformClick();
                }
            }
            else if (dialog == DialogResult.No)
            {
                base.OnFormClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FILE_PATH == "")
            {
                btnSaveAs.PerformClick();
            }
            else
            {
                Network.SaveToFile(myNetwork, FILE_PATH);
                saved = true;
                lblInfo.Text = "Your file has been saved! " + DateTime.Now;
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (type != ComponentType.NONE && type != ComponentType.PIPELINE)
            {
                Component c = myNetwork.CreateComponent(type, e.X, e.Y);
                if (panel1.DisplayRectangle.Contains(c.ComponentBox))
                {
                    myNetwork.AddComponent(c);
                }
            }
            if (type == ComponentType.PIPELINE)
            {
                if (startComp == null)
                {
                    startComp = myNetwork.GetComponent(e.Location);
                    startCompLoc = e.Location;
                    return;
                }
                endComp = myNetwork.GetComponent(e.Location);
                if (endComp == null)
                {
                    inbetweenPts.Add(e.Location);
                    return;
                }
                endCompLoc = e.Location;
                myNetwork.RegisterPipeline(startComp, endComp, startCompLoc, endCompLoc, inbetweenPts);
                ClearVariables();
                type = ComponentType.NONE;
            }
            panel1.Invalidate();
        }

        private void btnPipe_Click(object sender, EventArgs e)
        {
            type = ComponentType.PIPELINE;
            ClearVariables();
        }

        private void ClearVariables()
        {
            this.startComp = null;
            this.endComp = null;
            this.inbetweenPts = new List<Point>();
        }

        private void btnUpdateFlow_Click(object sender, EventArgs e)
        {
            if (selectedComponent != null)
            {
                if (selectedComponent is Pump)
                {
                    Pump p = (Pump)selectedComponent;
                    double capacity;
                    double flow;
                    if (double.TryParse(tbCapacity.Text, out capacity) &&
                        double.TryParse(tbCurrentFlow.Text, out flow))
                    {
                        p.SetFlow(capacity, flow);
                    }
                    else
                    {
                        MessageBox.Show("Invalid values!");
                    }
                }
                selectedComponent = null;
                this.tbCurrentFlow.Text = "";
                this.tbCapacity.Text = "";
                panel1.Invalidate();
            }
            else if (selectedPipeline != null)
            {
                double maxFlow;
                if (double.TryParse(tbCapacity.Text, out maxFlow))
                {
                    selectedPipeline.ChangeMaxFlow(maxFlow);
                }
                else
                {
                    MessageBox.Show("Invalid max value!");
                }
                selectedPipeline = null;
                this.tbCurrentFlow.Text = "";
                this.tbCapacity.Text = "";
                panel1.Invalidate();
            }
        }
    }
}