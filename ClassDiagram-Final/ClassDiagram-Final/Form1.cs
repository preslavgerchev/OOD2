using System.Windows.Forms;
using System.Drawing;
using System;
namespace ClassDiagram_Final
{
    public partial class Form1 : Form
    {
        
        ComponentType type = ComponentType.NONE;
        Component selectedComponent;
        int mouseX;
        int mouseY;
        Network myNetwork;
        public Form1()
        {
            InitializeComponent();
            myNetwork = new Network();
            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            pictureBox1.Invalidate();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (selectedComponent != null)
            {
                e.Graphics.DrawRectangle(Pens.Red, selectedComponent.ComponentBox);
            }
            else if(type != ComponentType.NONE)
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

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectedComponent = myNetwork.GetComponent(e.Location);
            pictureBox1.Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (selectedComponent != null)
            {
                myNetwork.RemoveComponent(selectedComponent);
                selectedComponent = null;
                type = ComponentType.NONE;
                pictureBox1.Invalidate();
            }
        }

        private void RedrawImages(Graphics gr)
        {
            foreach (var comp in myNetwork.MyComponents)
            {
                gr.DrawImage(comp.GetImage(), comp.GetLocation());
                gr.DrawString(comp.TestFlow().ToString(), Font, Brushes.Red, comp.GetTextLocation());
            }
        }
    }
}
