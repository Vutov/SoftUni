using System;

class NewHouse
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // odd
        int length = n;
        int roofHight = n / 2;
        int floorHight = n;
        char star = '*';
        char brick = '-';
        char wall = '|';
        //roof of the house.
        for (int i = 0; i <= roofHight; i++)
        {
            //bricks before the stars.
            for (int bricks = 1; bricks <= roofHight - i; bricks++)
            {
                Console.Write(brick);
            }
            //stars in the middle.
            for (int stars = roofHight - i; stars <= roofHight + i; stars++)
			{
			    Console.Write(star);
			}
            //bricks after the stars.
            for (int bricks = 1; bricks <= roofHight - i; bricks++)
            {
                Console.Write(brick);
            }
            Console.WriteLine();
            
        }
        //floor of the house.
        for (int numOfFloors = 0; numOfFloors < floorHight; numOfFloors++)
        {
            Console.Write(wall);
            for (int floar = 0; floar < length - 2; floar++)
            {
                Console.Write(star);
            }
            Console.Write(wall);
            Console.WriteLine();
        }

    }
}