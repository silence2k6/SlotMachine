using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InterfaceMethods.GameIntro();

            InterfaceMethods.HowMuchLines();

            InterfaceMethods.ShowRandomSlotNumbers();
        }
    }
}