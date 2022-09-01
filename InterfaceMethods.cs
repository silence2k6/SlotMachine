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

            for (int i = 0; i < 3; i++)
            {
                int j = 0;
                Console.Write(slotNumbers[i, 0]);
                j++;

                while (j < 3)
                {
                    Console.WriteLine(slotNumbers[0, j]);
                    j++;
                }
            }
        }
    }
}
