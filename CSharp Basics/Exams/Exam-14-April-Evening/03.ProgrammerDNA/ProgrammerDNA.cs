using System;

class ProgrammerDNA
{
    static void Main(string[] args)
    {
        int totalLength = int.Parse(Console.ReadLine());// length of dna seq.
        char printChar = char.Parse(Console.ReadLine());
        char spaceChar = '.';
        int blockSize = 7;
        int midPoint = blockSize / 2;
        int diff = 0;
        int diffCounter = 0;

        for (int counter = 0; counter < totalLength; counter++)
        {
            // Print Block
            for (int i = 0; i < blockSize; i++)
            {
                if (i >= midPoint - diff && i <= midPoint + diff)
                {
                    Console.Write(printChar);

                    // Change Letter
                    if (printChar == 'G')
                    {
                        printChar = 'A';
                    }
                    else
                    {
                        printChar++;
                    }
                }
                else
                {
                    Console.Write(spaceChar);
                }
            }

            if (diffCounter >= midPoint)
            {
                diff--;
            }
            else
            {
                diff++;
            }

            diffCounter++;

            if (diffCounter == blockSize)
            {
                diffCounter = 0;
                diff++;
            }

            Console.WriteLine();
        }
    }
}
//...B...
//..CDE..
//.FGABC.
//DEFGABC
//.DEFGA.
//..BCD..
//...E...