using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class Gambling
{
    static void Main(string[] args)
    {
        double cash = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        string houseHand = Console.ReadLine();

        //Get house's cards weight;
        string[] houseCards = houseHand.Split(' ');
        int houseWeight = 0;
        foreach (string card in houseCards)
        {
            switch (card)
            {
                case "J": houseWeight += 11; break;
                case "Q": houseWeight += 12; break;
                case "K": houseWeight += 13; break;
                case "A": houseWeight += 14; break;
                //2 to 10 cards;
                default:
                    int cardValue = int.Parse(card);
                    houseWeight += cardValue;
                    break;
            }
        }
        //Console.WriteLine(houseWeight);
        //All combinations;
        double allCombinations = 0;
        double winningCombinations = 0;
        for (int card1 = 2; card1 < 15; card1++)
        {
            for (int card2 = 2; card2 < 15; card2++)
            {
                for (int card3 = 2; card3 < 15; card3++)
                {
                    for (int card4 = 2; card4 < 15; card4++)
                    {
                        int currentHandWeight = 
                            card1 + card2 +
                            card3 + card4;
                        allCombinations++;
                        if (currentHandWeight > houseWeight)
                        {
                            winningCombinations++;
                        }
                    }
                }
            }
        }
        //Calculate percentages;
        double probabilityOfWinning = winningCombinations / allCombinations;
        //Console.WriteLine(probabilityOfWinning);
        string gameCall;
        if (probabilityOfWinning < 0.5d)
        {
            gameCall = "FOLD";
        }
        else
        {
            gameCall = "DRAW";
        }
        double expectedWinning = cash * 2 * probabilityOfWinning;
        Console.WriteLine("{0}\n{1:F}", gameCall, expectedWinning);
    }
}