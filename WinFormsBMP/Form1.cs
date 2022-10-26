using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsBMP
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string bmp1 = @"1.bmp";

        string bmp2 = @"2.bmp";

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                Bitmap bmp = new Bitmap(bmp1);
                pictureBox1.Image = bmp;
                Color[,] color = new Color[bmp.Width, bmp.Height];
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        color[x, y] = bmp.GetPixel(x, y);
                        
                    }
                }
                double[] average = new double[100];
                for (int x = 0; x < bmp.Width; x++)
                {
                    double summx = 0;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        int a = Convert.ToInt32((color[x, y].R + color[x, y].G + color[x, y].B)/3);
                        summx = summx + a;
                    }
                    average[x] = summx/average.Length;
                }
                double[] plusaverage = new double[100];
                double[] minusaverage = new double[100];
                for (int i = 0; i < average.Length; i++)
                {
                    plusaverage[i] = average[i];
                    plusaverage[i] += 50;
                }
                for (int i = 0; i < average.Length; i++)
                {
                    minusaverage[i] = average[i];
                    minusaverage[i] -= 50;
                }
                int [,] binararray = new int[100,100];
                for (int y = 0; y < bmp.Height; y++)
                {
                    int x = 0;
                    for (; x < bmp.Width - 1; x++)
                    {
                        int a = Convert.ToInt32((color[x, y].R + color[x, y].G + color[x, y].B) / 3);
                        if (a < plusaverage[x] && a > minusaverage[x])
                        {
                            binararray[y,x] = 1;
                        }
                        
                    }
                    var bitmapw = new Bitmap(100, 100);
                    for (int q = 0; q < 100; q++)
                    {
                        for (int w = 0; w < 100; w++)
                        {
                            if (binararray[q, w] >= 1)
                                bitmapw.SetPixel(w, q, Color.White);
                            else
                                bitmapw.SetPixel(w, q, Color.Black);
                        }
                    }
                    bitmapw.Save("C:\\Users\\dimon\\source\\repos\\WinFormsBMP\\WinFormsBMP\\result1.bmp");

                }
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                            textBox5.AppendText(binararray[y, x].ToString());
                        
                    }
                    textBox5.AppendText("\n");
                }


                StringBuilder t = new StringBuilder();

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        t.Append(((color[x, y].R + color[x, y].G + color[x, y].B) / 3).ToString("") + "..");
                    }
                    
                    t.AppendLine();
                }
                textBox1.Text = t.ToString();
            }

            catch (ArgumentException)
            {
                MessageBox.Show("There was an error.");
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            try
            {
                Bitmap bmp = new Bitmap("C:\\Users\\dimon\\source\\repos\\WinFormsBMP\\WinFormsBMP\\2.bmp");
                pictureBox3.Image = bmp;
                Color[,] color = new Color[bmp.Width, bmp.Height];
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        color[x, y] = bmp.GetPixel(x, y);

                    }
                }
                double[] average = new double[100];
                for (int x = 0; x < bmp.Width; x++)
                {
                    double summx = 0;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        int a = Convert.ToInt32((color[x, y].R + color[x, y].G + color[x, y].B) / 3);
                        summx = summx + a;
                    }
                    average[x] = summx / average.Length;
                }
                double[] plusaverage = new double[100];
                double[] minusaverage = new double[100];
                for (int i = 0; i < average.Length; i++)
                {
                    plusaverage[i] = average[i];
                    plusaverage[i] += 50;
                }
                for (int i = 0; i < average.Length; i++)
                {
                    minusaverage[i] = average[i];
                    minusaverage[i] -= 50;
                }
                int[,] binararray = new int[100, 100];
                for (int y = 0; y < bmp.Height; y++)
                {
                    int x = 0;
                    for (; x < bmp.Width - 1; x++)
                    {
                        int a = Convert.ToInt32((color[x, y].R + color[x, y].G + color[x, y].B) / 3);
                        if (a < plusaverage[x] && a > minusaverage[x])
                        {
                            binararray[y, x] = 1;
                        }

                    }

                    var bitmapq = new Bitmap(100, 100);
                    for (int q = 0; q < 100; q++)
                    {
                        for (int w = 0; w < 100; w++)
                        {
                            if (binararray[q, w] >= 1)
                                bitmapq.SetPixel(w, q, Color.White);
                            else
                                bitmapq.SetPixel(w, q, Color.Black);
                        }
                    }
                    bitmapq.Save("C:\\Users\\dimon\\source\\repos\\WinFormsBMP\\WinFormsBMP\\result2.bmp");
                }
                



                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        textBox2.AppendText(binararray[y, x].ToString());

                    }
                    textBox2.AppendText("\n");
                }


                StringBuilder t = new StringBuilder();

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        t.Append(((color[x, y].R + color[x, y].G + color[x, y].B) / 3).ToString("") + "..");
                    }

                    t.AppendLine();
                }
                textBox3.Text = t.ToString();
            }

            catch (ArgumentException)
            {
                MessageBox.Show("There was an error.");
            }
            

 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                Bitmap bmp = new Bitmap(@"C:\Users\dimon\source\repos\WinFormsBMP\WinFormsBMP\2.bmp");
                Color[,] color = new Color[bmp.Width, bmp.Height];
                
                int height = color.GetLength(0);
                int width = color.GetLength(1);
                BitmapData data = bmp.LockBits(new Rectangle(new System.Drawing.Point(0, 0), bmp.Size),
                                 ImageLockMode.ReadWrite,
                                 PixelFormat.Format24bppRgb);
                int stride = data.Stride;
                IntPtr scan0 = data.Scan0;
                int pixlSize = stride / width;

                unsafe
                {
                    for (int i = 100; i < height; i++)
                    {
                        var resultRow = (byte*)scan0 + (i * stride);
                        for (int j = 0; j < width; j++)
                        {
                            resultRow[j * pixlSize] = color[i, j].R;
                            resultRow[j * pixlSize + 1] = color[i, j].G;
                            resultRow[j * pixlSize + 2] = color[i, j].B;
                        }
                    }
                }

                bmp.UnlockBits(data);
                bmp.Save(@"C:\Users\dimon\source\repos\WinFormsBMP\WinFormsBMP\result.bmp");
            
        }
    }
}