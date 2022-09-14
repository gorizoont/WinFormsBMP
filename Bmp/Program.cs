using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace steamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap(@"C:\Users\dimon\source\repos\WinFormsBMP\Bmp\2.bmp"); // c : \ 2.bmp - адрес        изображения
            Color[,] color = new Color[bmp.Width, bmp.Height];
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    color[x, y] = bmp.GetPixel(x, y);
                }
            StreamWriter steamWriter = new StreamWriter(@"C:\Users\dimon\source\repos\WinFormsBMP\Bmp\1.txt");
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
        }
    }
}