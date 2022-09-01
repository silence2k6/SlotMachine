using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class LogicMethods
    {
        static public int[,] GetRandomSlotNumbers()
        {
            int[,] slotNumbers = new int[3, 3];
            Random randomNumber = new Random();

            for (int i = 0; i < 3; i++)
            {
                int j = 0;
                slotNumbers[i, j] = randomNumber.Next(1,9);
                j++;

                while (j < 3)
                {
                    slotNumbers[i, j] = randomNumber.Next(1,9);
                    j++;
                }              
            } 
            return slotNumbers;
        }
    }
}
