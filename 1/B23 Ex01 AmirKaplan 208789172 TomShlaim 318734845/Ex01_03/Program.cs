using System;
using Ex01_02;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            printAdvancedDiamond();
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }
        private static void printAdvancedDiamond()
        {
            bool isGoodInput = false;
            int diamondHeightNumber = 0;

            while (!isGoodInput)
            {
                Console.WriteLine("Please enter the diamond height you would like to build :");
                string diamondHeightString = System.Console.ReadLine();

                isGoodInput = int.TryParse(diamondHeightString, out diamondHeightNumber);

                if (!isGoodInput)
                {
                    Console.WriteLine("Invalid number! Please try again.");
                }
                if(diamondHeightNumber < 0)
                {
                    Console.WriteLine("The diamond height can't be negative! Please try again.");
                    isGoodInput = false;
                }
            }

            Console.WriteLine("Here is your diamond : ");
            Ex01_02.Program.printDiamond(diamondHeightNumber);
        }
    }
}


