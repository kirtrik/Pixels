using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PixelsConsole
{
    class Program
    {
        static void GenerateFile(string filepath)
        {
            Random rnd = new Random();
            using (BinaryWriter bw = new BinaryWriter(File.Create(filepath), Encoding.ASCII))
            {
                for (int i = 0; i < 3*1000000; i++)
                {
                    bw.Write(Convert.ToByte(rnd.Next(256)));
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Generating files...");
            string path1 = Environment.CurrentDirectory + "\\px1.px";
            string path2 = Environment.CurrentDirectory + "\\px2.px";
            string path3 = Environment.CurrentDirectory + "\\res.px";
            Random rnd = new Random();
            GenerateFile(path1);
            GenerateFile(path2);
            Console.Write("\t\tDone\n");
            using (BinaryReader br1 = new BinaryReader(File.OpenRead(path1), Encoding.ASCII))
            {
                using (BinaryReader br2 = new BinaryReader(File.OpenRead(path2), Encoding.ASCII))
                {
                    using (BinaryWriter bw = new BinaryWriter(File.Create(path3), Encoding.ASCII))
                    {
                        Stopwatch st = new Stopwatch();
                        st.Start();
                        Console.Write("Summing files...");
                        while (br1.PeekChar() != -1 && br2.PeekChar() != -1)
                        {
                            Pixel px1 = new Pixel();
                            Pixel px2 = new Pixel();
                            px1.Fill(br1.ReadBytes(3));
                            px2.Fill(br2.ReadBytes(3));
                            bw.Write((px1 + px2).ToBytes());
                        }
                        st.Stop();
                        
                        Console.Write("\t\tDone\nTime elapsed:{0}", st.Elapsed);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
