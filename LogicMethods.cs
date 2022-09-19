﻿namespace SlotMachine
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

        //public enum WagerVariants
        //{
        //    Line,
        //    Row,
        //    Diagonal
        //}

        public static int WagerResult(List<int>lineVariantList, int linesToPlay, int[,] slotNumbers)
        {
            int wagerResult = 0;
            int variantListPos = 0;
            int vertikalLine = 0;
            int horizontalLine = 0;
            int diagonalLine = 0;
            
            while (linesToPlay > 0)
            {
                if (lineVariantList[variantListPos] == 1)
                {
                    if (slotNumbers[horizontalLine, 1].Equals(slotNumbers[horizontalLine, 0]) && slotNumbers[horizontalLine, 2].Equals(slotNumbers[horizontalLine, 0]))
                    {
                        wagerResult++;
                    }
                    horizontalLine++;
                }

                if (lineVariantList[variantListPos] == 2)
                {
                    if (slotNumbers[1, vertikalLine].Equals(slotNumbers[0, vertikalLine]) && slotNumbers[2, vertikalLine].Equals(slotNumbers[0, vertikalLine]))
                    {
                        wagerResult++;
                    }
                    vertikalLine++;
                }

                if (lineVariantList[variantListPos] == 3)
                {
                    if (diagonalLine == 0)
                    {
                        if (slotNumbers[0,0].Equals(slotNumbers[1, 1]) && slotNumbers[2,2].Equals(slotNumbers[1,1]))
                        {
                            wagerResult++;
                        }
                        else
                        {
                            if (slotNumbers[0, 2].Equals(slotNumbers[1,1]) && slotNumbers[2,0].Equals(slotNumbers[1,1]))
                            {
                                wagerResult++;
                            }
                        }
                        diagonalLine++;
                    }
                }
                variantListPos++;
                linesToPlay--;
            }
            return wagerResult;
        }

        public static int WagerCredit (int wagerResult, int linesToPlay)
        {
            int wagerCredit = 0;

            if (wagerResult == 1)
            {
                wagerCredit = linesToPlay * 2;
            }
            if (wagerResult == 2)
            {
                wagerCredit = linesToPlay * 4;
            }
            if (wagerResult >= 3)
            {
                wagerCredit = linesToPlay * 10;
            }
            return wagerCredit;
        }
    }
}
