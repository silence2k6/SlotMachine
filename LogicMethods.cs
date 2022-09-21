namespace SlotMachine
{
    public static class LogicMethods
    {
        /// <summary>
        /// Creats an 3x3 array with random numbers
        /// </summary>
        /// <returns>created array with value</returns>
        public static int[,] CreateRandomSlotNumbers()
        {
            int[,] slotNumbers = new int[3, 3];
            Random randomNumber = new Random();

            int i = 0;

            while (i < slotNumbers.GetLength(0))
            {
                int j = 0;

                while (j < slotNumbers.GetLength(1))
                {
                    slotNumbers[i, j] = randomNumber.Next(1, 5);
                    j++;
                }
                i++;
            }
            return slotNumbers;
        }

        /// <summary>
        /// checks if array integers in lines, rows or diagonals are equal
        /// </summary>
        /// <param name="lineVariantList">archiv where art of verification are stored</param>
        /// <param name="slotNumbers">archiv where grid integers from this wager are stored in</param>
        /// <returns>sum of all found equal lines, rows and diagonals of this wager</returns>
        public static int WagerResult(List<WagerVariant>lineVariantList, int[,] slotNumbers)
        {
            int wagerResult = 0;

            int horizontalLine = 0;
            int vertikalLine = 0;
            int diagonalLine = 0;

            int variantListPos = 0;

            while (variantListPos < lineVariantList.Count)
            {
                if (lineVariantList[variantListPos] == WagerVariant.Row)
                {
                    if (slotNumbers[horizontalLine, 1].Equals(slotNumbers[horizontalLine, 0]) && slotNumbers[horizontalLine, 2].Equals(slotNumbers[horizontalLine, 0]))
                    {
                        wagerResult++;
                    }
                    horizontalLine++;
                }
                else if (lineVariantList[variantListPos] == WagerVariant.Col)
                {
                    if (slotNumbers[1, vertikalLine].Equals(slotNumbers[0, vertikalLine]) && slotNumbers[2, vertikalLine].Equals(slotNumbers[0, vertikalLine]))
                    {
                        wagerResult++;
                    }
                    vertikalLine++;
                }
                else if (lineVariantList[variantListPos] == WagerVariant.Diagonal)
                {
                    if (diagonalLine == 0)
                    {
                        if (slotNumbers[0, 0].Equals(slotNumbers[1, 1]) && slotNumbers[2, 2].Equals(slotNumbers[1, 1]))
                        {
                            wagerResult++;
                        }
                    }
                    else
                    {
                        if (slotNumbers[0, 2].Equals(slotNumbers[1, 1]) && slotNumbers[2, 0].Equals(slotNumbers[1, 1]))
                        {
                            wagerResult++;
                        }
                    }
                    diagonalLine++;
                }
                variantListPos++;
            }
            return wagerResult;
        }
        /// <summary>
        /// calculates the profit of an wager
        /// </summary>
        /// <param name="wagerResult">sum of all found equal lines, rows and diagonals with this wager</param>
        /// <param name="linesToPlay">archiv how much lines, rows an diagonals the user want to play in this wager</param>
        /// <returns>total profit of this wager</returns>
        public static int WagerCredit (int wagerResult, int linesToPlay)
        {
            if (wagerResult == 1)
            {
                return linesToPlay * 2;
            }
            if (wagerResult == 2)
            {
                return linesToPlay * 4;
            }
            if (wagerResult >= 3)
            {
                return linesToPlay * 10;
            }
            return 0;
        }
    }
}
