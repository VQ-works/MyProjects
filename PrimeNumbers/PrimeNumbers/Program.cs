using System;
namespace PrimeNumbers;

class Program
{
    static int x, y;
    static void Main(string[] args)
    {
        for (int i = 0; i <= 1000; i++)
        {
            if (i != x)
            {
                if (i % x == 0)
                {
                    y++;
                }
                i--;
            }
            else
            {
                if (y == 1)
                {
                    Console.WriteLine(i);

                }
                y = 0;
                x = 0;
            }
            x++;

        }
    }
}


