using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    internal class DATAMethods
    {
        static public int[] getRandomSlotNumbers()
        {
            int[] slotMachine = new int[9];
            Random randomNumber = new Random();

            for (int i = 0; i < slotMachine.Length; i++)
            {
                slotMachine[i] = randomNumber.Next(1, 9);               
            }
            return slotMachine[0..9];          
        }
    }
}
