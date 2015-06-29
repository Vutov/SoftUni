using System;
using System.IO;

namespace Cosmetics
{
    using Engine;

    public class CosmeticsProgram
    {
        public static void Main()
        {
            //FileStream ostrm;
            //StreamWriter writer;
            //TextWriter oldOut = Console.Out;
            //try
            //{
            //    ostrm = new FileStream("../../Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //    writer = new StreamWriter(ostrm);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Cannot open Redirect.txt for writing");
            //    Console.WriteLine(e.Message);
            //    return;
            //}
            //Console.SetOut(writer);

            CosmeticsEngine.Instance.Start();

            //Console.SetOut(oldOut);
            //writer.Close();
            //ostrm.Close();
            //Console.WriteLine("Done");
        }
    }
}
