using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4
{
    class P4
    {
        private static int max = 0;
        private static List<Rectangle> best;
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            //var line = "Theta: -30 40 55 -10";
            var allRectangles = new List<Rectangle>();
            while (line != "End")
            {
                var data = line.Split(':');
                var name = data[0].Trim();
                var coordinates = data[1].Trim();

                var corrdinatesData = coordinates.Split(' ');
                var topLeft = new CoordinatePoint()
                {
                    X = int.Parse(corrdinatesData[0]),
                    Y = int.Parse(corrdinatesData[1])
                };

                var topRight = new CoordinatePoint()
                {
                    X = int.Parse(corrdinatesData[2]),
                    Y = int.Parse(corrdinatesData[1])
                };

                var bottomLeft = new CoordinatePoint()
                {
                    X = int.Parse(corrdinatesData[0]),
                    Y = int.Parse(corrdinatesData[3])
                };

                var bottomRight = new CoordinatePoint()
                {
                    X = int.Parse(corrdinatesData[2]),
                    Y = int.Parse(corrdinatesData[3])
                };

                var rect = new Rectangle()
                {
                    Name = name,
                    TopLeft = topLeft,
                    TopRight = topRight,
                    BottomLeft = bottomLeft,
                    BottomRight = bottomRight
                };

                allRectangles.Add(rect);

                line = Console.ReadLine();
            }

            //var zeta = allRectangles.Where(r => r.Name == "Zeta").Take(1).ToList()[0];
            //var alpha = allRectangles.Where(r => r.Name == "Alpha").Take(1).ToList()[0];
            //Console.WriteLine(alpha.IsInside(zeta));
            allRectangles.Sort();
            for (int i = 0; i < allRectangles.Count; i++)
            {
                var rectangle = allRectangles[i];
                var visited = new bool[allRectangles.Count];
                Combinations(rectangle, allRectangles, visited, new List<Rectangle>(), i);
            }

            Console.WriteLine(string.Join(" < ", best.Select(r => r.Name)));
        }

        public static void Combinations(Rectangle current, List<Rectangle> allRectangles, bool[] visited, List<Rectangle> nested, int currentId)
        {
            if (!visited[currentId])
            {
                visited[currentId] = true;
                nested.Add(current);
                if (nested.Count > max)
                {
                    max = nested.Count;
                    best = new List<Rectangle>(nested);
                }
                //Console.WriteLine(string.Join(" ", nested.Select(r => r.Name)));
            }

            for (int i = 0; i < allRectangles.Count; i++)
            {
                if (!visited[i])
                {
                    var rect = allRectangles[i];
                    if (rect.IsInside(nested.Last()))
                    {
                        Combinations(rect, allRectangles, visited, nested, i);
                    }

                    visited[i] = false;
                    nested.Remove(rect);
                }
            }
        }
    }

    class Rectangle : IComparable<Rectangle>
    {
        public string Name { get; set; }

        public CoordinatePoint TopLeft { get; set; }
        public CoordinatePoint TopRight { get; set; }
        public CoordinatePoint BottomLeft { get; set; }
        public CoordinatePoint BottomRight { get; set; }

        public bool IsInside(Rectangle other)
        {
            if (this.TopLeft.X >= other.TopLeft.X &&
                this.TopRight.X <= other.TopRight.X &&
                this.TopLeft.Y <= other.TopLeft.Y &&
                this.BottomLeft.Y >= other.BottomLeft.Y)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(Rectangle other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }

    class CoordinatePoint
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}