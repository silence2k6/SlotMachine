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
    }
}
