using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace WinFormsBMP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap image1;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the image.
                

                Bitmap bmp = new Bitmap(@"C:\Users\dimon\source\repos\WinFormsBMP\Bmp\2.bmp"); // c : \ 2.bmp - адрес        изображения
                pictureBox1.Image = bmp;
                Color[,] color = new Color[bmp.Width, bmp.Height];
                for (int y = 0; y < bmp.Height; y++)
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        color[x, y] = bmp.GetPixel(x, y);
                    }

                StringBuilder t = new StringBuilder();

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        t.Append(color[x, y].R.ToString("X2"));
                        t.Append(color[x, y].G.ToString("X2"));
                        t.Append(color[x, y].B.ToString("X2") + " ");
                    }
                    t.AppendLine();
                }
                textBox1.Text = t.ToString();



                StreamWriter steamWriter = new StreamWriter(@"C:\Users\dimon\source\repos\WinFormsBMP\Bmp\2.txt");
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        steamWriter.Write(color[x, y].R.ToString("X2"));
                        steamWriter.Write(color[x, y].G.ToString("X2"));
                        steamWriter.Write(color[x, y].B.ToString("X2") + " ");
                    }
                    steamWriter.WriteLine();
                }
                steamWriter.Close();
                //// Loop through the images pixels to reset color.
                //for (x = 0; x < image1.Width; x++)
                //{


                //    for (y = 0; y < image1.Height; y++)
                //    {
                //        textBox1.Text = $"{image1.GetPixel(x, y)}";
                //        Color pixelColor = image1.GetPixel(x, y);
                //        Color newColor = Color.FromArgb(pixelColor.G, 66, 66);
                //        image1.SetPixel(x, y, newColor);
                //    }
                //}

                //// Set the PictureBox to display the image.
                //pictureBox1.Image = image1;

                //// Display the pixel format in Label1.
                //label1.Text = "Pixel format: " + image1.PixelFormat.ToString();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("There was an error." +
                    "Check the path to the image file.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "D:/";
                op.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
                op.FilterIndex = 1;

                if (op.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = Image.FromFile(op.FileName);
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                    Bitmap img = new Bitmap(op.FileName);
                    StringBuilder t = new StringBuilder();
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            t.Append((img.GetPixel(i, j).R > 100 && img.GetPixel(i, j).G > 100 &&
                                     img.GetPixel(i, j).B > 100) ? 0 : 1);
                        }
                        t.AppendLine();
                    }
                    textBox3.Text = t.ToString();
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}