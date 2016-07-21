using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelsConsole
{
    class Pixel
    {
        private int red, green, blue;
        public Pixel()
        {
            this.red = 0;
            this.green = 0;
            this.blue = 0;
        }
        public Pixel(int red, int green, int blue)
        {
            this.red = red;
            this.blue = blue;
            this.green = green;
        }
        public void Fill(byte[] rgb)
        {
            this.red = rgb[0];
            this.green = rgb[1];
            this.blue = rgb[2];
        }
        public byte[] ToBytes()
        {
            return new byte[] { Convert.ToByte(this.red), Convert.ToByte(this.green), Convert.ToByte(this.blue) };
        }
        public static Pixel operator +(Pixel px1, Pixel px2)
        {
            int sumr = px1.red + px2.red;
            int sumg = px1.green + px2.green;
            int sumb = px1.blue + px2.blue;
            sumr = sumr - (sumr / 256) * (sumr - 255);
            sumg = sumg - (sumg / 256) * (sumg - 255);
            sumb = sumb - (sumb / 256) * (sumb - 255);
            return new Pixel(sumr, sumg, sumb);
        }
    }
}
