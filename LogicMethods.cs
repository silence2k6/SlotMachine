using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {
        public static int[,] GetRandomSlotNumbers()
        {
            int[,] slotNumbers = new int[3, 3];
            Random randomNumber = new Random();

            int i = 0;

            while (i < slotNumbers.GetLength(0))
            {
                int j = 0;

                while (j < slotNumbers.GetLength(1))
                {
                    slotNumbers[i, j] = randomNumber.Next(1, 10);
                    j++;
                }
                i++;
            }
            return slotNumbers;
        }
        public static List<int> WagerResult(List<int>lineVariantList, int linesToPlay, int[,] slotNumbers)
        {
            List<int> wagerCredit = new List<int>();

            while (linesToPlay > 0)
            {
                int variantListPos = 0;

                if (lineVariantList[variantListPos] == 1)
                {
                    int horizontalLine = 0;

                    if (slotNumbers[horizontalLine, 1].Equals(slotNumbers[horizontalLine, 0]) && slotNumbers[horizontalLine, 2].Equals(slotNumbers[horizontalLine, 0]))
                    {
                        wagerCredit.Add(1);
                    }
                    variantListPos++;
                    horizontalLine++;
                }

                if (lineVariantList[variantListPos] == 2)
                {
                    int vertikalLine = 0;

                    if (slotNumbers[1, vertikalLine].Equals(slotNumbers[0, vertikalLine]) && slotNumbers[2, vertikalLine].Equals(slotNumbers[0, vertikalLine]))
                    {
                        wagerCredit.Add(1);
                    }
                    variantListPos++;
                    vertikalLine++;
                }

                if (lineVariantList[variantListPos] == 3)
                {
                    int diagonalLine1 = 0;
                    int diagonalLine2 = 2;
                    
                    if (slotNumbers[diagonalLine2, diagonalLine1].Equals(slotNumbers[1, 1]) && slotNumbers[diagonalLine2, diagonalLine1+2].Equals(slotNumbers[1, 1]))
                    {
                        wagerCredit.Add(1);
                    }
                   
                    variantListPos++;
                    diagonalLine1 = diagonalLine1 + 2;
                    diagonalLine2 = diagonalLine2 - 2;
                }
                linesToPlay--;
            }
            return wagerCredit;
        }
    }
}
