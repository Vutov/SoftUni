using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FIle.GetFileExtension("example"));
            Console.WriteLine(FIle.GetFileExtension("example.pdf"));
            Console.WriteLine(FIle.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FIle.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FIle.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FIle.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Demension.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Demension.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Demension.Width = 3;
            Demension.Height = 4;
            Demension.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", Demension.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Demension.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Demension.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Demension.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Demension.CalcDiagonalYZ());
        }
    }
}
