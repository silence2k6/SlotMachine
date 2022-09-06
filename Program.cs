using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InterfaceMethods.GameIntro();

            bool playAgain = true;

            while (playAgain == true)
            {
                int linesToPlay = InterfaceMethods.HowMuchLines();

                List<int> lineVariantList = new List<int>(InterfaceMethods.WhichLines(linesToPlay));
                break;

                //InterfaceMethods.ShowRandomSlotNumbers();
            }
        }
    }
}