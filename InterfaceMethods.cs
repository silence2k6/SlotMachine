using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class InterfaceMethods
    {
        public static void ShowRandomSlotNumbers()
        {
            int [,] slotNumbers = LogicMethods.GetRandomSlotNumbers();

            int i = 0;

            while (i < slotNumbers.GetLength(0))
            {
                int j = 0;

                while (j < slotNumbers.GetLength(1))
                {
                    Console.Write(slotNumbers[i, j] + " ");
                    j++;
                }
                Console.WriteLine();
                i++;
            }
        }

        public static void GameIntro()
        {
            Console.WriteLine("     ***Welcome to SlotMachine***     \n");
            Console.WriteLine("Game rules:");
            Console.WriteLine("- You will earn money when you find a line with 3 ident numbers");
            Console.WriteLine("- Therefore you can choose between horizontal, vertical and diagonal Lines");
            Console.WriteLine("- For each Line you want to play, you have to pay 1,00 EUR");
            Console.WriteLine("- If you win 1 line, you will get 1,00 EUR");
            Console.WriteLine("- If you win 2 lines, you will get 3,00 EUR");
            Console.WriteLine("- If you win 3 Lines, you will get 5,00 EUR\n");
            Console.WriteLine("You will start with a Credit of 20,00 EUR\n");
        }

        public static int HowMuchLines()
        {
            int chooseLinesToPlay = 0; ;
            bool validInput = false;

            while (validInput == false)
            {
                Console.Write("How much lines you want to play (max 8)?:\t");
                validInput = int.TryParse(Console.ReadLine(), out chooseLinesToPlay);

                if (chooseLinesToPlay < 1 || chooseLinesToPlay > 8)
                {
                    validInput = false;
                    Console.WriteLine("You have to play at least 1 line and maximum 8 lines!");                   
                }
                Console.WriteLine();
            }
            return chooseLinesToPlay;
        }

        public static int WhichLines()
        {
            int chooseLineVariant = 0;
            bool validInput = false;

            while (validInput == false)
            {
                int x = 1;
                string lineVariant = "";
                Console.Write($"How you want to play your {x}.line (press (1)horizontal (2)vertikal (3)diagonal)");
                validInput = int.TryParse(Console.ReadLine(), out chooseLineVariant);
                
                if (chooseLineVariant == 1)
                {
                    lineVariant = "horizintal";
                }
                if (chooseLineVariant == 2)
                {
                    lineVariant = "vertikal";
                }
                if (chooseLineVariant == 3)
                {
                    lineVariant = "diagonal";
                }
                Console.WriteLine($"{x}.Line: {lineVariant}");
            }
            return chooseLineVariant;

            //Console.WriteLine("Which lines you want to Play?");
            //int lineVariant = 0;

            //while (InterfaceMethods.HowMuchLines() > 0)
            //{
            //    int x = 1;
            //    Console.WriteLine($"How you want to play your {x}.line (press (1)horizontal (2)vertikal (3)diagonal)");
            //    //int lineVariant;
            //    bool validInput = int.TryParse(Console.ReadLine(), out lineVariant);
            //    Console.WriteLine($"{x}.Line: {lineVariant}");

            //    if(lineVariant < 1 || lineVariant > 3 || validInput == false)
            //    {
            //        Console.WriteLine("Pls choose only between (1)horizontal (2)vertikal (3)diagonal");
            //    }
            //    x++;
            //    //InterfaceMethods.HowMuchLines()--;               
            //}
            //return lineVariant;
        }
    }
}
