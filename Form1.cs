
// 1. Создайте программу, показывающую пульсирующее сердце. 

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    public partial class Form1 : Form
    {

        private Timer timer = new Timer() 
        { 
            Interval = 600 
        };
        bool beat = false;

        public Form1()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            SolidBrush peg = new SolidBrush(Color.Red);
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            gp.AddEllipse(80, 120, 200, 300);
            gp.AddEllipse(250, 120, 200, 300);
            gp.AddPolygon(new Point[] { new Point(96, 352), new Point(436, 352), new Point(280, 560) });
            if (beat) g.ScaleTransform(0.95f, 0.95f);
            g.FillPath(peg, gp);
            g.ResetTransform();
            beat = !beat;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
