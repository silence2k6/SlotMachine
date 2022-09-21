namespace SlotMachine
{
    public static class InterfaceMethods
    {
        /// <summary>
        /// prints generated grid on console
        /// </summary>
        /// <param name="slotNumbers">archiv where grid integers from this wager are stored in</param>
        public static void PrintSlotNumbers(int[,] slotNumbers)
        {
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
        }
        /// <summary>
        /// prints welcome message and game rules on console
        /// </summary>
        public static void GameIntro()
        {
            Console.WriteLine("     ***Welcome to SlotMachine***     \n");
            Console.WriteLine("Game rules:");
            Console.WriteLine("- You will earn money when you find a line with 3 ident numbers");
            Console.WriteLine("- Therefore you can choose between horizontal, vertical and diagonal Lines");
            Console.WriteLine("- For each Line you want to play, you have to pay 1,00 EUR");
            Console.WriteLine("- If you win 1 line, you double your invested wager");
            Console.WriteLine("- If you win 2 lines, you quadruple your invested wager");
            Console.WriteLine("- If you win 3 Lines or more, you increase tenfold your invested wager\n");
            Console.WriteLine("You will start with a credit of 30,00 EUR\n");
        }

        /// <summary>
        /// asks user how much lines he wants to play
        /// </summary>
        /// <returns>number of lines which the user wants to play</returns>
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
            }
            return chooseLinesToPlay;
        }


        /// <summary>
        /// asks user in which variant he/she wants to play his/her lines, rows and diagonals
        /// </summary>
        /// <param name="linesToPlay">number of lines which the user wants to play</param>
        /// <returns>List in which all variants to be played are stored in</returns>
        public static List<WagerVariant> WhichLines(int linesToPlay)
        {
            Console.Write($"\nHow you want to play your lines?\npress (1)horizontal (2)vertikal (3)diagonal\n");
            List<WagerVariant> lineVariantList = new List<WagerVariant>();
            int numRows = 0;
            int numCols = 0;
            int numDiagonals = 0;
            int choosenVariant;

            while (lineVariantList.Count < linesToPlay)
            {
                while (true)
                {
                    Console.Write($"\n{lineVariantList.Count + 1}.line:\t");
                    bool validInput = int.TryParse(Console.ReadLine(), out choosenVariant);
                    if (validInput == false)
                    {
                        Console.WriteLine("Only numbers are accepted!");
                    }
                    else if (choosenVariant <= 0 || choosenVariant > 3)
                    {
                        Console.WriteLine("Only the line variants (1)horizontal (2)vertikal (3)diagonal are accepted");
                    }
                    else
                    {
                        break;
                    }
                }
       
                if (choosenVariant == 1)
                {
                    if (numRows >= 3)
                    {
                        Console.WriteLine("Sry, you still gave your wager for all 3 horizontal lines. Choose another variant for this line.");
                    }
                    else
                    {
                        Console.Write("horizontal");
                        lineVariantList.Add(WagerVariant.Row);
                        numRows++;
                    }
                }
                else if (choosenVariant == 2)
                {
                    if (numCols >= 3)
                    {
                        Console.WriteLine("Sry, you still gave your wager for all 3 vertical lines. Choose another variant for this line.");
                    }
                    else
                    {
                        Console.Write("vertikal");
                        lineVariantList.Add(WagerVariant.Col);
                        numCols++;
                    }
                }
                else if (choosenVariant == 3)
                {
                    if (numDiagonals >= 2)
                    {
                        Console.WriteLine("Sry, you still gave your wager for all 2 diagonal lines. Choose another variant for this line.");
                    }
                    else
                    {
                        Console.Write("diagonal");
                        lineVariantList.Add(WagerVariant.Diagonal);
                        numDiagonals++;
                    }
                }
            }
            Console.WriteLine("\n");
            return lineVariantList;
        }

        /// <summary>
        /// prints profit of an played wager on console
        /// </summary>
        /// <param name="wagerCredit">calcualated profit of last wager</param>
        public static void ShowWagerResult(int wagerCredit)
        {
            if (wagerCredit < 1)
            {
                Console.WriteLine("Sry, with this wager you didn't found a winning line\n");
            }
            else
            {
                Console.WriteLine($"\nCongratulation, you won {wagerCredit} EUR!!!\n");
            }
        }

        /// <summary>
        /// prints total provit on console
        /// </summary>
        /// <param name="totalCredit">sum of total profit of all played wagers</param>
        public static void ShowTotalCredit (int totalCredit)
        {
            Console.WriteLine($"Your total Credit is {totalCredit} EUR\n");
        }

        /// <summary>
        /// prints message on console that user is out of credit
        /// </summary>
        /// <param name="totalCredit">sum of total profit of all played wagers</param>
        public static void OutOfCreditMessage (int totalCredit)
        {
            Console.Write("Sry, you are out of credit!!! (for playing again you restart the game with an new credit)");
        }

        /// <summary>
        /// asks user to play again
        /// </summary>
        /// <returns>true: if user wants to play again; false: if user doesn*t</returns>
        public static bool KeepPlaying(int totalCredit)
        {
            bool playAgain = true;

           
            Console.Write("If you want to play one more round press 'Y'\t");

            string userInput = Console.ReadLine().ToUpper();

            if (userInput != "Y")
            {
                playAgain = false;
            }
            Console.WriteLine();
            return playAgain;
        }

        /// <summary>
        /// prints message on console that there isn't enough budget to play this number of lines
        /// </summary>
        public static void BudgetForWagerToLow ()
        {
            Console.WriteLine("Sry, you haven't enought budget to play this number of lines");
        }
    }
}
