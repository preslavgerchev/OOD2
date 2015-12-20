using System.Windows.Forms;
using System.Drawing;
using System;
namespace ClassDiagram_Final
{
    public partial class Form1 : Form
    {
        Graphics gr;
        ComponentType type;
        Component selectedComponent;
        int mouseX;
        int mouseY;
        Network myNetwork;
        public Form1()
        {
            InitializeComponent();
            myNetwork = new Network();
            gr = pictureBox1.CreateGraphics();
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
         
            Component c = myNetwork.CreateComponent(type, mouseX, mouseY);
            if (c == null)
            {
                return;
            }
            myNetwork.AddComponent(c);
            foreach (var v in myNetwork.MyComponents)
            {
                e.Graphics.DrawImage(v.GetImage(), v.GetLocation());
                e.Graphics.DrawRectangle(Pens.Red, v.ComponentBox);
            }
          
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
    }
}
