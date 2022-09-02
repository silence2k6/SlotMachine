using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class InterfaceMethods
    {
        static public void ShowRandomSlotNumbers()
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

        static public void GameIntro()
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

        static public int HowMuchLines()
        {
            Console.WriteLine("How much lines you want to play (max 8)?");

            int linesToPlay = 0;

            while (linesToPlay < 1 || linesToPlay > 8)
            {
                linesToPlay = Convert.ToInt32(Console.ReadLine());

                if (linesToPlay < 1)
                {
                    Console.WriteLine("Sry, but you have to play at least 1 line");
                }
                if (linesToPlay > 8)
                {
                    Console.WriteLine("Sry, but you can't play more than 8 lines");
                }
            }
            Console.WriteLine();
            return linesToPlay;
        }

        static public int WhichLines()
        {
            Console.WriteLine("Which lines you want to Play?");

            int chooseArtToPlay = InterfaceMethods.WhichLines();

            while (chooseArtToPlay > 0)
            {
                int x = 1;
                Console.WriteLine($"How you want to play your {x}.line (press(1)horizontal(2)vertikal(3)diagonal)");
                int artToPlay = Convert.ToInt32(Console.ReadLine());
                //LIste erstellen und Auswahl in Liste einfügen
                //Auswahl je Zeile am Bildschirm anzeigen
                //falsche Eingabe Wiederholen lassen
                chooseArtToPlay--;              
            }
            return chooseArtToPlay;
        }
    }
}
