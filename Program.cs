using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] fillingSlotMachine = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random randomNumber = new Random();

            for (int i = 0; i < fillingSlotMachine.Length; i++)
            {
               fillingSlotMachine[i] = randomNumber.Next(1,9);
            }
          
            Console.WriteLine(String.Join(" ", fillingSlotMachine[0..3]));
            Console.WriteLine(String.Join(" ", fillingSlotMachine[3..6]));
            Console.WriteLine(String.Join(" ", fillingSlotMachine[6..9]));
        }
    }
}