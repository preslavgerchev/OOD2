using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOD2WPF
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Component c;
        int classType;
        
        List<Component> componentsList;
        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            componentsList = new List<Component>();
            classType = -1;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            switch (classType)
            {
                case 0:
                    c = new Pump(mea.X, mea.Y,25,25);
                    break;
                case 1:
                    c = new Sink(mea.X, mea.Y,25,25);
                    break;
            }
            bool found = false;
            foreach (Component comp in componentsList)
            {
                if (comp.IsInFigure(c))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                componentsList.Add(c);
                graphics.DrawImage(c.GetImage(), c.GetLocation());
                graphics.DrawRectangle(Pens.Blue, c.GetComponentBox());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            classType = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            classType = 1;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
          
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           //
        }
    }
}
