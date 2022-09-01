using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class UIMethods
    {
        static public void showRandomSlotNumbers(int[] slotNumbers)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(DATAMethods.getRandomSlotNumbers()[i]);
            }
        }
    }
}
