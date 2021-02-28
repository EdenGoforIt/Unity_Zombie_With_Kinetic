

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double test2 = 87.2345524523452;
            decimal test3 = 87.23455m;
            // y == 2
            Console.WriteLine(test2);
            Console.WriteLine(test3);
            var toShowOnScreen = test2.ToString("0.00");
            Console.WriteLine(Math.Round(test3, 2).ToString("0.00"));
            Console.WriteLine(toShowOnScreen);
            Console.WriteLine(decimal.Round(test3, 2));
        }
    }
}
