namespace _04.String_Editor
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class StringEditor
    {
        public static void Main(string[] args)
        {
            var data = new BigList<char>();

            var line = Console.ReadLine().Trim();
            while (line != "Exit")
            {
                var tokens = line.Split('|').Select(c => c.Trim()).ToArray();
                var command = tokens[0];
                switch (command)
                {
                    case "Insert":
                        var possition = int.Parse(tokens[2]);
                        if (possition > data.Count || possition < 0)
                        {
                            Console.WriteLine("Error");
                        }
                        else
                        {
                            var insertData = tokens[1].ToCharArray();
                            data.InsertRange(possition, insertData);
                        }

                        break;
                    case "Append":
                        data.AddRange(tokens[1].ToCharArray());
                        break;
                    case "Delete":
                        var startIndex = int.Parse(tokens[1]);
                        var count = int.Parse(tokens[2]);
                        if (startIndex + count >= data.Count || startIndex < 0)
                        {
                            Console.WriteLine("Error");
                        }
                        else
                        {
                            data.RemoveRange(startIndex, count);
                        }

                        break;
                    case "Replace":
                        var startPossition = int.Parse(tokens[1]);
                        var replaceCount = int.Parse(tokens[2]);
                        if (startPossition + replaceCount >= data.Count || startPossition < 0)
                        {
                            Console.WriteLine("Error");
                        }
                        else
                        {
                            var replaceData = tokens[3].ToCharArray();
                            data.RemoveRange(startPossition, replaceCount);
                            data.InsertRange(startPossition, replaceData);
                        }

                        break;
                    case "Print":
                        Console.WriteLine(string.Join("", data));
                        break;
                }

                line = Console.ReadLine().Trim();
            }
        }
    }
}
