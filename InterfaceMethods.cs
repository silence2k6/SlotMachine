using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class InterfaceMethods
    {
        public static int[,] ShowRandomSlotNumbers()
        {
            int [,] slotNumbers = LogicMethods.GetRandomSlotNumbers();

            int line = 0;

            while (line < slotNumbers.GetLength(0))
            {
                int row = 0;

                while (row < slotNumbers.GetLength(1))
                {
                    Console.Write(slotNumbers[line, row] + " ");
                    row++;
                }
                Console.WriteLine();
                line++;
            }
            return slotNumbers;
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
            Console.WriteLine("- If you win 3 Lines, you will get 5,00 EUR");
            Console.WriteLine("- If you win more than 3 Lines, you will double your invested wager\n");
            Console.WriteLine("You will start with a credit of 20,00 EUR\n");
        }

        public static int HowMuchLines()
        {
            int chooseLinesToPlay = 0;
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
                //Console.WriteLine($"Your total costs for this wager will be {chooseLinesToPlay}EUR\n");
            }
            return chooseLinesToPlay;
        }

        public static List<int> WhichLines(int linesToPlay)
        {
            Console.Write($"\nHow you want to play your lines?\npress (1)horizontal (2)vertikal (3)diagonal\n");
            List<int> lineVariantList = new List<int>();
            int chooseLineVariant = 0;
            int maxLines = 0;
            int maxRows = 0;
            int maxDiagonals = 0;

            while (chooseLineVariant < linesToPlay)
            {
                bool validInput = true;
                int choosenVariant = 0;
                
                while (validInput == true)
                {
                    Console.Write($"\n{chooseLineVariant + 1}.line:\t");
                    validInput = int.TryParse(Console.ReadLine(), out choosenVariant);
                    lineVariantList.Add(choosenVariant);

                    if (choosenVariant == 1)
                    {
                        Console.Write("horizontal");
                        maxLines++;
                    }
                    if (choosenVariant == 2)
                    {
                        Console.Write("vertikal");
                        maxRows++;
                    }
                    if (choosenVariant == 3)
                    {
                        Console.Write("diagonal");
                        maxDiagonals++;
                    }
                    if (choosenVariant <= 0 || choosenVariant > 3)
                    {
                        Console.WriteLine("Only the line variants (1)horizontal (2)vertikal (3)diagonal are accepted");
                        chooseLineVariant--;
                    }
                    if (maxLines >= 4)
                    {
                        Console.WriteLine("Sry, you still gave your wager for all 3 horizontal lines. Choose another variant for this line.");
                        chooseLineVariant--;
                        maxLines--;
                    }
                    if (maxRows >= 4)
                    {
                        Console.WriteLine("Sry, you still gave your wager for all 3 vertical lines. Choose another variant for this line.");
                        chooseLineVariant--;
                        maxRows--;
                    }
                    if (maxDiagonals >= 3)
                    {
                        Console.WriteLine("Sry, you still gave your wager for all 2 diagonal lines. Choose another variant for this line.");
                        chooseLineVariant--;
                        maxDiagonals--;
                    }
                    chooseLineVariant++;
                    break;
                }
            }
            Console.WriteLine("\n");
            return lineVariantList;
        }
    }
}
