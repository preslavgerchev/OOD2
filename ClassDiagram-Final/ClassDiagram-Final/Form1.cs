using System.Windows.Forms;
using System.Drawing;
using System;

namespace ClassDiagram_Final
{
    public partial class Form1 : Form
    {
        Font font;
        Network myNetwork;

        ComponentType type = ComponentType.NONE;
        Component selectedComponent;

        Component startComp;
        Component endComp;
        Point startCompLoc;
        Point endCompLoc;

        int mouseX;
        int mouseY;
        string FILE_PATH = "Network.XML";
        bool saved;

        public Form1()
        {
            InitializeComponent();
            myNetwork = new Network();
            panel1.Paint += PictureBox1_Paint;
            panel1.MouseDown += PictureBox1_MouseDown;
            trackBar1.Visible = false;
            font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            saved = false;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            panel1.Invalidate();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (selectedComponent != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, selectedComponent.ComponentBox);
            }
            if (type != ComponentType.NONE && type != ComponentType.PIPELINE)
            {
                Component c = myNetwork.CreateComponent(type, mouseX, mouseY);
                myNetwork.AddComponent(c);
            }
            DrawImages(e.Graphics);
            DrawPipelines(e.Graphics);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = ComponentType.PUMP;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            type = ComponentType.SINK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            type = ComponentType.SPLITTER;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            type = ComponentType.MERGER;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            type = ComponentType.ADJUSTABLE_SPLITTER;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (selectedComponent != null)
            {
                myNetwork.RemoveComponent(selectedComponent);
                myNetwork.RemovePipeline(selectedComponent);
                selectedComponent = null;
                type = ComponentType.NONE;
                if (trackBar1.Visible)
                {
                    trackBar1.Visible = false;
                }
                panel1.Invalidate();
            }
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
                Merger m = comp as Merger;
                if (m != null)
                {
                    gr.DrawRectangle(Pens.Red, m.UpperHalf);
                    gr.DrawRectangle(Pens.Red, m.LowerHalf);
                    gr.DrawRectangle(Pens.Red, m.OutcomeHalf);
                }
                Splitter sp = comp as Splitter;
                if (sp != null)
                {
                    gr.DrawRectangle(Pens.Red, sp.LowerHalf);
                    gr.DrawRectangle(Pens.Red, sp.UpperHalf);
                    gr.DrawRectangle(Pens.Red, sp.IncomeHalf);
                }
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectedComponent = myNetwork.GetComponent(e.Location);
            Splitter splitterComp = selectedComponent as Splitter;
            if (splitterComp != null && splitterComp.IsAdjustable)
            {
                trackBar1.Visible = true;
            }
            else
            {
                trackBar1.Visible = false;
            }
            panel1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ((Splitter)selectedComponent).AdjustPercentages(trackBar1.Value);
            panel1.Invalidate();
        }

        private void DrawPipelines(Graphics gr)
        {
            foreach (Pipeline p in myNetwork.Pipelines)
            {
                
                gr.DrawLine(new Pen(Color.Red, 5), p.StartPoint, p.EndPoint);
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
                    myNetwork = Network.LoadFromFile(load.FileName);
                    panel1.Invalidate();
                }
            }
            else if (dialog == DialogResult.No)
            {
                OpenFileDialog load = new OpenFileDialog();
                if (load.ShowDialog() == DialogResult.OK)
                {
                    load.Title = "Load from file";
                    myNetwork = Network.LoadFromFile(load.FileName);
                    panel1.Invalidate();
                }
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to save it?", "Save?", MessageBoxButtons.YesNoCancel);
            if (dialog == DialogResult.Yes && saved == true)
            {
                Network.SaveToFile(myNetwork, FILE_PATH);
                base.OnClosed(e);
            }
            else
            {
                if (dialog == DialogResult.Yes && saved == false)
                {
                    btnSaveAs.PerformClick();
                }
                else
                if (dialog == DialogResult.Cancel)
                {
                    //it should cancel the exit and close the dialog
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Network.SaveToFile(myNetwork, FILE_PATH);
            saved = true;
            lblInfo.Text = "Your file has been saved! " + DateTime.Now;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (type == ComponentType.PIPELINE)
            {
                if (startComp == null)
                {
                    startComp = myNetwork.GetComponent(e.Location);
                    startCompLoc = startComp.GetPipelineLocation(e.Location);
                    return;
                }
                endComp = myNetwork.GetComponent(e.Location);
                if (endComp == null)
                {
                    return;
                }
                endCompLoc = endComp.GetPipelineLocation(e.Location);
                myNetwork.CreateAndProcessPipeline(startComp, endComp, startCompLoc, endCompLoc);
                ClearVariables();
                type = ComponentType.NONE;
                panel1.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            type = ComponentType.PIPELINE;
        }

        private void ClearVariables()
        {
            this.startComp = null;
            this.endComp = null;
        }
    }
}
