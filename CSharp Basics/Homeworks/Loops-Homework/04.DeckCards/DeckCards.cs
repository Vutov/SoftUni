using System;

class DeckCards
{

    private static string GetCard(int color, int cardValue)
    {
        string card = "";
        switch (color)
        {
            case 1: card += '\u2663'; break;
            case 2: card += '\u2666'; break;
            case 3: card += '\u2665'; break;
            case 4: card += '\u2660'; break;
            //No default needed, loop is 1-4;
        }
        switch (cardValue)
        {
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                card += "" + cardValue;
                break;
            case 11: card += "J"; break;
            case 12: card += "Q"; break;
            case 13: card += "K"; break;
            case 14: card += "A"; break;
            //No default needed, loop is 2-14;
        }
        return card;

    }
    
    static void Main(string[] args)
    {
        for (int card = 2; card <= 14; card++)//52 total cards, 13 per color;
        {      
            for (int colors = 1; colors <= 4; colors++)
            {
                Console.Write("{0, -3} ", GetCard(colors, card));
            }
            Console.WriteLine();
        }
    }
}