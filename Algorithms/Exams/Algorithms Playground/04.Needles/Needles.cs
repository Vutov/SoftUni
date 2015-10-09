namespace _04.Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Needles
    {
        static void Main(string[] args)
        {
            // string stackInput = "3 5 11 0 0 0 12 12 0 0 0 12 12 70 71 0 90 123 140 150 166 190 0";
            // string needlesInput = "5 13 90 1 70 75 7 188 12";
            // string stackInput = "0 0 0 0 0 0 0";
            // string needlesInput = "2 5";
            var firstLine = Console.ReadLine();
            var stackInput = Console.ReadLine();
            var needlesInput = Console.ReadLine();
            var stack = stackInput.Split(' ').Select(int.Parse).ToList();
            var needles = needlesInput.Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < stack.Count; i++)
            {
                if (stack[i] == 0 && i != stack.Count - 1)
                {
                    var zeros = 1;
                    while (i != stack.Count - 1 && stack[i + 1] == 0)
                    {
                        zeros++;
                        i++;
                    }

                    // Go back and change all;
                    for (int j = 0; j < zeros; j++)
                    {
                        if (i < stack.Count - 1)
                        {
                            stack[i] = stack[i + 1];
                            i--;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // No point in checking again the elements changed.
                    i += zeros;
                }
            }

            // Remove trailing zeros at the end;
            while (stack.Count != 0 && stack.Last() == 0)
            {
                stack.RemoveAt(stack.Count - 1);
            }

            // Console.WriteLine(string.Join(" ", stack));
            var indexes = new List<int>();
            foreach (var needle in needles)
            {
                var index = stack.BinarySearch(needle);
                if (index < 0)
                {
                    index = ~index;
                }
                else
                {
                    if (index != 0)
                    {
                        while (stack[index] == stack[index - 1])
                        {
                            index--;
                            if (index <= 0)
                            {
                                break;
                            }
                        }
                    }
                }

                indexes.Add(index);
            }

            Console.WriteLine(string.Join(" ", indexes));
        }
    }
}