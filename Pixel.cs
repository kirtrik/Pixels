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
            int red, green, blue;
            red = (px1.red + px2.red) > 255 ? 255 : px1.red + px2.red;
            green = (px1.green + px2.green) > 255 ? 255 : px1.green + px2.green;
            blue = (px1.blue + px2.blue) > 255 ? 255 : px1.blue + px2.blue;
            return new Pixel(red, green, blue);
        }
    }
}
