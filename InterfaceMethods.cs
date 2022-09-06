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

                //WENN LINE MEHR ALS 3 MAL GESPIELT WERDEN SOLL (GEHT NICHT!!!)

                if (chooseLinesToPlay < 1 || chooseLinesToPlay > 8)
                {
                    validInput = false;
                    Console.WriteLine("You have to play at least 1 line and maximum 8 lines!");                   
                }
                Console.WriteLine($"Your total costs for this wager will be {chooseLinesToPlay}EUR\n");
            }
            return chooseLinesToPlay;
        }

        public static List<int> WhichLines(int linesToPlay)
        {
            Console.Write($"How you want to play your lines?\npress (1)horizontal (2)vertikal (3)diagonal\n");
            List<int> lineVariantList = new List<int>();
            int chooseLineVariant = 0;

            while (chooseLineVariant < linesToPlay)
            {
                Console.Write($"\n{chooseLineVariant+1}.line:\t");
                int choosenLineVariant = Convert.ToInt32(Console.ReadLine());
                lineVariantList.Add(choosenLineVariant);

                if (choosenLineVariant == 1)
                {
                    Console.Write("horizontal");
                }
                if (choosenLineVariant == 2)
                {
                    Console.Write("vertikal");
                }
                if (choosenLineVariant == 3)
                {
                    Console.Write("diagonal"); 
                }
                chooseLineVariant++;
            }
            Console.WriteLine("\n");
            return lineVariantList;
        }
    }
}
