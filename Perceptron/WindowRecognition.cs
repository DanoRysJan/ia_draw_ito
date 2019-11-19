﻿using System;
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
            if (Training.Checked == false)
            {
                Application.Exit();
            }
            else
            {

                //Create bitmap with width and height are equal to panel1
                Bitmap bmp = new Bitmap(panelToDraw.Width, panelToDraw.Height);
                //-----use using like dispose function to clean up all resources
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    //Fix sixe and location of panel1 in screen
                    Rectangle rect = panelToDraw.RectangleToScreen(panelToDraw.ClientRectangle);
                    //-----copy panel1 from screen
                    g.CopyFromScreen(rect.Location, Point.Empty, panelToDraw.Size);
                }

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
                        System.Console.Write(bmp.GetPixel(x, y).GetBrightness());
                        if (bmp.GetPixel(x, y).GetBrightness() < 0.5)
                        {
                            //One refers to black
                            pixels[y][x] = 1;
                            System.Console.Write(pixels[y][x]);
                        }
                        else
                        {
                            //Zero refers to white
                            pixels[y][x] = 0;
                            System.Console.Write(pixels[y][x]);
                        }
                    }
                    System.Console.WriteLine();
                }
                //Put value in each pixel into array and not show value of pixels == 0, show value of pixels == 1 
                string[] ids = pixels.Select(a => String.Join("", a.Select(b => b == 0 ? " " : "1"))).ToArray();
                //String[] ids = pixels.Select(a => String.Join("", a).ToArray();
                richTextBoxShowData.Lines = ids;
            }
           

        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Create bitmap with width and height are equal to panel1
            Bitmap bmp = new Bitmap(panelToDraw.Width, panelToDraw.Height);
            //-----use using like dispose function to clean up all resources
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //Fix sixe and location of panel1 in screen
                Rectangle rect = panelToDraw.RectangleToScreen(panelToDraw.ClientRectangle);
                //-----copy panel1 from screen
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
                //labelNumberToDraw.text is a name of directory
                string[] filenames = Directory.GetFiles(directory_name);
                string filename = directory_name+".bmp";
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
                bmp.Save("D:/Dano/Escritorio/Dataset-Draw/"+"serpiente" + filename, ImageFormat.Bmp); 
              //labelShowMessage.Text = "--- Image " + filename + " saved ---";
              //labelShowMessage.ForeColor = Color.Blue;
              //MessageBox.Show("Image saved successfully.");
                clearPanel();
              // richTextBoxShowData.Clear();
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

    }
}
