using System.Windows.Forms;
using System.Drawing;
using System;
using System.Runtime.Serialization;
namespace ClassDiagram_Final
{
    public partial class Form1 : Form
    {
        Font font;
        ComponentType type = ComponentType.NONE;
        Component selectedComponent;
        int mouseX;
        int mouseY;
        Network myNetwork;

        public Form1()
        {
            InitializeComponent();
            myNetwork = new Network();
            panel1.Paint += PictureBox1_Paint;
            panel1.MouseDown += PictureBox1_MouseDown;
            trackBar1.Visible = false;
            font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
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
            if (type != ComponentType.NONE)
            {
                Component c = myNetwork.CreateComponent(type, mouseX, mouseY);
                myNetwork.AddComponent(c);
            }
            RedrawImages(e.Graphics);
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
                selectedComponent = null;
                type = ComponentType.NONE;
                if (trackBar1.Visible)
                {
                    trackBar1.Visible = false;
                }
                panel1.Invalidate();
            }
        }

        private void RedrawImages(Graphics gr)
        {
            foreach (var comp in myNetwork.MyComponents)
            {
                gr.DrawImage(comp.GetImage(), comp.GetLocation());
                IFlow flowComp = comp as IFlow;
                if (flowComp != null)
                {
                    gr.DrawString(flowComp.GetFlow(), font, Brushes.Black, flowComp.GetTextLocation());
                }
                /*ISplit splitComp = comp as ISplit;
                if(splitComp != null)
                {
                    gr.DrawRectangle(Pens.Orange, splitComp.GetHalfOfComponent(new Point(mouseX, mouseY)));
                }*/
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

        private void button12_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Title = "Save netowork";
            myDialog.ShowDialog();
            if (myDialog.FileName != "")
            {
                myNetwork.SaveFileToSert(myNetwork, myDialog.FileName);
            }

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
