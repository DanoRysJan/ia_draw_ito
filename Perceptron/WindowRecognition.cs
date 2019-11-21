using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Perceptron
{
    public partial class WindowRecognition : Form
    {
        bool paint = false;
        SolidBrush color;
        int numberToDraw = 0;
        int histZero, histOne;
        int typeOutput = 13;
        string drawToDraw = "ventana";
        int posXRight, posYRigth, posXLeft, posYLeft, posXUp,posYUp, posXDown,posYDown;
        int posYU, posYR,posYD;

        public WindowRecognition()
        {
            InitializeComponent();
            Training.Checked = true;
            guessDraw.Visible = false;
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
                    g.FillEllipse(color, e.X, e.Y, 5, 5);
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
             //Application.Exit();
            handwritingRecognition();

        }

        private void Save_Click(object sender, EventArgs e)
        {
           // handwritingRecognition();

            //Create bitmap with width and height are equal to panel1
            Bitmap bmp = new Bitmap(panelToDraw.Width, panelToDraw.Height);
            //Use using like dispose function to clean up all resources
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //Fix sixe and location of panel1 in screen
                Rectangle rect = panelToDraw.RectangleToScreen(panelToDraw.ClientRectangle);
                //Copy panel1 from screen
                g.CopyFromScreen(rect.Location, Point.Empty, panelToDraw.Size);
            }

            //Save image into bmp
            try
            {
                string directory_name = labelNumberToDraw.Text;
                if (!Directory.Exists(directory_name))
                {
                    Directory.CreateDirectory(directory_name);
                }

                string[] filenames = Directory.GetFiles(directory_name);
                string filename = directory_name + ".bmp";
                if (filenames.Length != 0)
                {
                    int maxNum = filenames.Where(a =>
                    {
                        try
                        {
                            Convert.ToInt32(Path.GetFileNameWithoutExtension(a));
                            return true;
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    })
                                        .Max(a =>
                                        {
                                            return Convert.ToInt32(Path.GetFileNameWithoutExtension(a));
                                        });
                    filename = (maxNum + 1) + ".bmp";
                }
              //bmp.Save(Path.GetFullPath(directory_name) + "/" + filename, ImageFormat.Bmp); //Importante
                bmp.Save("D:/Dano/Escritorio/Dataset-Draw/" + drawToDraw + filename, ImageFormat.Bmp); 
              //labelShowMessage.Text = "--- Image " + filename + " saved ---";
              //labelShowMessage.ForeColor = Color.Blue;
              //MessageBox.Show("Image saved successfully.");

                //Create the dataset with histZero = all 0 in the bmp , histOne = all 1 in the bmp , and the typeOutput
                string rutaCompleta = "D:/Dano/Escritorio/Dataset-Draw/" + drawToDraw + filename + "_his.txt";
                using (StreamWriter file = new StreamWriter(rutaCompleta, true))
                {
                    file.WriteLine(histZero + "," + histOne + "," + typeOutput);
                    file.Close();
                }
                //clearPanel();
                //richTextBoxShowData.Clear();
                
                numberToDraw++;

                if (numberToDraw >= 20)
                {
                    labelNumberToDraw.Text = "Training is complete.";
                }
               labelNumberToDraw.Text = numberToDraw.ToString();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image not save: " + ex.Message);
            }

            histZero = 0;
            histOne  = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Training.Checked == true)
            {
                panelToDraw.Width = 255;
                panelToDraw.Height = 255;
                labelNumberToDraw.Visible = true;
                Save.Visible = true;
                guessDraw.Visible = false;
                richTextBoxShowData.Visible = true;
            }
            else
            {
                panelToDraw.Width = 600;
                panelToDraw.Height = 350;
                labelNumberToDraw.Visible = false;
                Save.Visible = false;
                guessDraw.Visible = true;
                richTextBoxShowData.Visible = false;
            }
        }

        public void handwritingRecognition()
        {
            histZero = 0;
            histOne = 0;
            //Create bitmap with width and height are equal to panel1
            Bitmap bmp = new Bitmap(panelToDraw.Width, panelToDraw.Height);
            //-----use using like dispose function to clean up all resources
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //Fix sixe and location of panel1 in screen
                Rectangle rect = panelToDraw.RectangleToScreen(panelToDraw.ClientRectangle);
                //Copy panel1 from screen
                g.CopyFromScreen(rect.Location, Point.Empty, panelToDraw.Size);
            }

            // Instance of next pixel
            posYU = bmp.Width;
            posYR = 0;
            posYD = bmp.Height;

            //Get value of each pixel
            int[][] pixels = new int[bmp.Height][];
            for (int y = 0; y < bmp.Height; y++)
            {
                pixels[y] = new int[bmp.Width];
            }
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                   if (bmp.GetPixel(x, y).GetBrightness() < 0.5)
                    {
                        //One refers to black
                        pixels[y][x] = 1;
                        histOne++;
                        
                        //Get the pixel Left
                        if (histOne == 1)
                        {
                            posXLeft = x;
                            posYLeft = y;

                           
                        }
                       //Get the pixel of the Up
                        if (y < posYU)
                        {
                            posYU = y;
                            posXUp = x;
                            posYUp = posYU;
                        }
                        //Get the pixel of the Rigth
                        if (y > posYD)
                        {
                            posYD = y;
                            posXDown = x;
                            posYDown= posYD;
                        }
                        if (y < posYD)
                        {
                            posYD = x;
                            posXDown = posYD;
                            posYDown = y;
                        }
                        //Get the pixel of the Down
                        if (y > posYR)
                        {
                            posYR = y;
                            posXRight = x;
                            posYRigth = posYR;
                        }
                    }
                    else
                    {
                        //Zero refers to white
                        pixels[y][x] = 0;
                        histZero++;
                    }
                }
            }
            //Put value in each pixel into array and not show value of pixels == 0, show value of pixels == 1 
            string[] ids = pixels.Select(a => String.Join("", a.Select(b => b == 0 ? " " : "1"))).ToArray();
            //String[] ids = pixels.Select(a => String.Join("", a).ToArray();
            richTextBoxShowData.Lines = ids;
            toFrame();
        }

        private void toFrame()
        {
           Console.WriteLine("FINALES: " + "Arr: " + posXUp + " " + posYUp);
           Console.WriteLine("FINALES: " + "Izq: " + posXLeft + " " + posYLeft);
           Console.WriteLine("FINALES: " + "Der: " + posXDown + " " + posYDown);
           Console.WriteLine("FINALES: " + "Abj: " + posXRight + " " + posYRigth);
        }
    }
}