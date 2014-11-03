using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NakovsMatching
{
    static void Main(string[] args)
    {
        string firstWord = Console.ReadLine();
        string secondWord = Console.ReadLine();
        int allowedWeight = int.Parse(Console.ReadLine());

        int firstWordLen = firstWord.Length;
        int secondWordLen = secondWord.Length;

        bool hasSolution = false;
        int leftWeightA = 0;
        string leftWordA = "";
        int rightWeightA = 0;
        string rightWordA = "";
        int leftWeightB = 0;
        string leftWordB = "";
        int rightWeightB = 0;
        string rightWordB = "";

        //First word;
        for (int indexA = 1; indexA < firstWordLen; indexA++)
        {
            for (int j = 0; j < indexA; j++)
            {
                leftWeightA += firstWord[j];
                leftWordA += firstWord[j];
            }
            for (int k = indexA; k < firstWordLen; k++)
            {
                rightWeightA += firstWord[k];
                rightWordA += firstWord[k];
            }
            //Second word;
            for (int indexB = 0; indexB < secondWordLen; indexB++)
            {
                for (int u = 0; u < indexB; u++)
                {
                    leftWeightB += secondWord[u];
                    leftWordB += secondWord[u];
                }
                for (int l = indexB; l < secondWordLen; l++)
                {
                    rightWeightB += secondWord[l];
                    rightWordB += secondWord[l];
                }

                int nakovs = Math.Abs(leftWeightA * rightWeightB - rightWeightA * leftWeightB);
                bool sizesNotZero = 
                    leftWeightA != 0 && rightWeightA != 0 &&
                    leftWeightB != 0 && rightWeightB != 0; // Lenght of parts of the word > 0;
                if (nakovs <= allowedWeight && sizesNotZero)
                {
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs",
                        leftWordA, rightWordA, leftWordB, rightWordB, nakovs);
                    hasSolution = true;
                }

                leftWeightB = 0;
                rightWeightB = 0;
                leftWordB = "";
                rightWordB = "";
            }

            leftWeightA = 0;
            rightWeightA = 0;
            leftWordA = "";
            rightWordA = "";
        }
        if (!hasSolution)
        {
            Console.WriteLine("No");
        }

    }
}
