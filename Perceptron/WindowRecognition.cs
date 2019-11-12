using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class WindowRecognition : Form
    {
        bool paint = false;
        SolidBrush color;
        int numberToDraw = 0;

        public WindowRecognition()
        {
            InitializeComponent();

            labelShowMessage.Text = "Tu dibujo es: ";
            labelShowMessage.ForeColor = Color.Blue;
        }

        private void panelToDraw_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelToDraw_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
        }

        private void panelToDraw_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
        }

        private void panelToDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                color = new SolidBrush(Color.Black);
                //-----drawing graphics
                using (Graphics g = panelToDraw.CreateGraphics())
                {
                    //-----fill ellipse with color which e is mouse, e.X is mouse click at the current X position
                    g.FillEllipse(color, e.X, e.Y, 10, 10);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearScreen();
        }

        private void clearScreen()
        {
            clearPanel();
         
        }

        private void clearPanel()
        {
            Graphics g1 = panelToDraw.CreateGraphics();
            g1.Clear(panelToDraw.BackColor);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        


    }
}
