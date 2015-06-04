using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point3D;

namespace Paths
{
    public static class Storage
    {
        public static void Save(string sequenceOFPoints, string name)
        {
            var points = sequenceOFPoints.Split('|').ToList();
            using (var writer = new StreamWriter("../../" + name + ".txt"))
            {
                points.ForEach(x =>
                {
                    var coords = x.Split(' ');
                    writer.WriteLine("({0},{1},{2})", coords[0], coords[1], coords[2]);
                });
            }
        }

        public static void Save(List<Point> sequenceOFPoints, string name)
        {
            using (var writer = new StreamWriter("../../" + name + ".txt"))
            {
                sequenceOFPoints.ForEach(x => writer.WriteLine(x));
            }
        }

        public static string Load(string name)
        {
            var allText = new List<string>();
            using (var reader = new StreamReader("../../" + name + ".txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    allText.Add(line);
                    line = reader.ReadLine();
                }
            }

            return string.Join("|", allText);
        }
    }
}
