namespace SlotMachine
{
    public static class LogicMethods
    {
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
        public static List<int> WagerResult(List<int>lineVariantList, int linesToPlay, int[,] slotNumbers)
        {
            List<int> wagerResult = new List<int>();
            int variantListPos = 0;
            int vertikalLine = 0;
            int horizontalLine = 0;
            int diagonalPos11 = 0;
            int diagonalPos12 = 0;
            int diagonalPos21 = 2;
            int diagonalPos22 = 0;

            while (linesToPlay > 0)
            {
                if (lineVariantList[variantListPos] == 1)
                {
                    if (slotNumbers[horizontalLine, 1].Equals(slotNumbers[horizontalLine, 0]) && slotNumbers[horizontalLine, 2].Equals(slotNumbers[horizontalLine, 0]))
                    {
                        wagerResult.Add(1);
                    }
                    horizontalLine++;
                }

                if (lineVariantList[variantListPos] == 2)
                {
                    if (slotNumbers[1, vertikalLine].Equals(slotNumbers[0, vertikalLine]) && slotNumbers[2, vertikalLine].Equals(slotNumbers[0, vertikalLine]))
                    {
                        wagerResult.Add(1);
                    }
                    vertikalLine++;
                }

                if (lineVariantList[variantListPos] == 3)
                {
                    if (slotNumbers[diagonalPos11, diagonalPos12].Equals(slotNumbers[1, 1]) && slotNumbers[diagonalPos21, diagonalPos22].Equals(slotNumbers[1, 1]))
                    {
                        wagerResult.Add(1);
                        diagonalPos11 = 2;
                        diagonalPos21 = 0;
                    }
                }
                variantListPos++;
                linesToPlay--;
            }
            return wagerResult;
        }

        public static int wagerCredit (List<int>wagerResult, int linesToPlay)
        {
            int wagerCredit = 0;

            if (wagerResult.Sum() == 1)
            {
                wagerCredit = linesToPlay * 2;
            }
            if (wagerResult.Sum() == 2)
            {
                wagerCredit = linesToPlay * 4;
            }
            if (wagerResult.Sum() >= 3)
            {
                wagerCredit = linesToPlay * 10;
            }
            return wagerCredit;
        }
    }
}
