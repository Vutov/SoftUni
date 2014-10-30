using System;

class PokerStraight
{
    static void Main(string[] args)
    {
        int weight = int.Parse(Console.ReadLine());
        int count = 0;
        //1-14 card value, 1-4 colors value
        for (int card1 = 1; card1 <= 14; card1++)
        {
            for (int color1 = 1; color1 <= 4; color1++)
            {
                for (int card2 = 1 + card1; card2 <= 14; card2++)
                {
                    for (int color2 = 1; color2 <= 4; color2++)
                    {
                        for (int card3 = 1 + card2; card3 <= 14; card3++)
                        {
                            for (int color3 = 1; color3 <= 4; color3++)
                            {
                                for (int card4 = 1 + card3; card4 <= 14; card4++)
                                {
                                    for (int color4 = 1; color4 <= 4; color4++)
                                    {
                                        for (int card5 = 1 + card4; card5 <= 14; card5++)
                                        {
                                            for (int color5 = 1; color5 <= 4; color5++)
                                            {
                                                //To ensure assending order;
                                                if (card1 + 1 == card2 &&
                                                    card2 + 1 == card3 &&
                                                    card3 + 1 == card4 &&
                                                    card4 + 1 == card5)
                                                {
                                                    int handWeight =
                                                        (10 * card1 + color1) +
                                                        (20 * card2 + color2) +
                                                        (30 * card3 + color3) +
                                                        (40 * card4 + color4) +
                                                        (50 * card5 + color5);
                                                    if (handWeight == weight)
                                                    {
                                                        count++;
                                                        //Console.WriteLine("" + card1 + " " + card2 + " " +
                                                        //    card3 + " " + card4 + " " + card5 + " ");
                                                    }
                                                }
                                                
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(count);
    }
}

//Can be done with 1 loop for cards and every next to be card + 1 , + 2 ect in the weight calc and 5 loops
//for the colors (5 cards = 5 loops);