using System;

class FriendBits
{
    static void Main(string[] args)
    {
        uint number = uint.Parse(Console.ReadLine());
        string binary = Convert.ToString(number, 2);
        string friendBits = "";
        string aloneBits = "";
        int count = 0;
        int len = binary.Length - 1; //index is 0 to length - 1;
        for (int bit = 0; bit <= len; bit++)
        {
            //All but last bit;
            if (bit < len)
            {
                if (binary[bit] == binary[bit + 1])
                {
                    friendBits += binary[bit];
                    count++;
                }
                else
                {
                    if (count > 0)
                    {
                        friendBits += binary[bit];
                        count = 0;
                    }
                    else
                    {
                        aloneBits += binary[bit];
                    }
                }
            }
            //Last bit;
            else if (bit == len && len > 1)
            {
                if (binary[len] == binary[len - 1])
                {
                    friendBits += binary[len];
                }
                else // Not friends;
                {
                    aloneBits += binary[len];
                }
            }
        }
        if (friendBits == "")
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine(Convert.ToUInt32(friendBits, 2));
        }
        if (aloneBits == "")
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine(Convert.ToUInt32(aloneBits, 2));
        }
    }
}