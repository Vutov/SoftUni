using System;

class PrintCards
{
    static void Main(string[] args)
    {
        for (int colours = 1; colours <= 4; colours++)
        {
            for (int cardNumber = 1; cardNumber <= 13; cardNumber++)
            {
                object card = new object();
                switch (cardNumber)
	            {
                    case 1:
                        card = "Ace"; break;
                    case 11:
                        card = "Knave"; break;
                    case 12:
                        card = "Queen"; break;
                    case 13:
                        card = "King"; break;
		            default:
                        card = cardNumber; break;
	            }
                switch (colours)
                {
                    case 1:
                        Console.WriteLine("{0} of Spades", card); break;
                    case 2:
                        Console.WriteLine("{0} of Hearts", card); break;
                    case 3:
                        Console.WriteLine("{0} of Diamonds", card); break;
                    case 4:
                        Console.WriteLine("{0} of Clubs", card); break;
                    default:
                        Console.WriteLine("Loop out of range"); break;
                }
            }
            Console.WriteLine();
        }
    }
}
//Напишете програма, която отпечатва всички възможни карти от стан-
//дартно тесте карти без джокери (имаме 52 карти: 4 бои по 13 карти).