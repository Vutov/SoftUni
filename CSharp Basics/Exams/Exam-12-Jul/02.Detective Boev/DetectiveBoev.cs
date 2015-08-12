namespace _02.Detective_Boev
{
    using System;
    using System.Text;

    public class DetectiveBoev
    {
        public static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string message = Console.ReadLine();

            int initialMask = 0;
            foreach (var ch in key)
            {
                initialMask += ch;
            }

            int realMask = initialMask;
            do
            {
                int newMask = 0;
                while (realMask != 0)
                {
                    var digit = realMask % 10;
                    realMask /= 10;
                    newMask += digit;
                }

                realMask = newMask;
            } while (realMask > 9);

            StringBuilder decypheredMessage = new StringBuilder();
            foreach (var ch in message)
            {
                if (ch % realMask == 0)
                {
                    char newChar = (char)(ch + realMask);
                    decypheredMessage.Append(newChar);
                }
                else
                {
                    char newChar = (char)(ch - realMask);
                    decypheredMessage.Append(newChar);
                }
            }

            StringBuilder reversedMessage = new StringBuilder();
            for (int i = decypheredMessage.Length - 1; i >= 0; i--)
            {
                reversedMessage.Append(decypheredMessage[i]);
            }

            Console.WriteLine(reversedMessage);
        }
    }
}
