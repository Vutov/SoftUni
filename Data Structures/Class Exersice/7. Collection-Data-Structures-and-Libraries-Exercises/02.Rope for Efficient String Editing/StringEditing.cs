namespace _02.Rope_for_Efficient_String_Editing
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class StringEditing
    {
        public static void Main(string[] args)
        {
            var data = new BigList<char>();

            Console.WriteLine("Give commands in format commans|value1|value2... etc");
            var line = Console.ReadLine();
            while (line != "Exit")
            {
                var tokens = line.Split('|').Select(c => c.Trim()).ToList();
                var command = tokens[0];
                switch (command)
                {
                    case "Insert":
                        if (tokens.Count != 2)
                        {
                            throw new ArgumentException("Invalid command format!");
                        }

                        data.AddRangeToFront(tokens[1].ToCharArray());
                        Console.WriteLine("OK");
                        break;
                    case "Append":
                        if (tokens.Count != 2)
                        {
                            throw new ArgumentException("Invalid command format!");
                        }

                        data.AddRange(tokens[1].ToCharArray());
                        Console.WriteLine("OK");
                        break;
                    case "Delete":
                        if (tokens.Count != 3)
                        {
                            throw new ArgumentException("Invalid command format!");
                        }

                        data.RemoveRange(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        Console.WriteLine("OK");
                        break;
                    case "Print":
                        if (tokens.Count != 1)
                        {
                            throw new ArgumentException("Invalid command format!");
                        }

                        foreach (var ch in data)
                        {
                             Console.Write(ch);
                        }

                        Console.WriteLine();
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}
