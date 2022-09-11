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
            List<int> totalCreditList = new List<int>();
            totalCreditList.Add(100);

            while (playAgain == true)
            {
                int linesToPlay = InterfaceMethods.HowMuchLines();
                totalCreditList.Add(-linesToPlay);

                List<int> lineVariantList = new List<int>(InterfaceMethods.WhichLines(linesToPlay));
               
                int [,] slotNumbers = InterfaceMethods.ShowRandomSlotNumbers();

                List<int> wagerResultList = LogicMethods.WagerResult(lineVariantList, linesToPlay, slotNumbers);
                int wagerCredit = wagerResultList.Sum();

                InterfaceMethods.ShowWagerCredit(wagerCredit);

                int totalCredit = wagerCredit + totalCreditList.Sum();

                InterfaceMethods.ShowTotalCredit(totalCredit);
            }
        }
    }
}