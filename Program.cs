using System.Xml.Schema;

namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InterfaceMethods.GameIntro();

            bool playAgain = true;
            int totalCredit = 100;

            while (playAgain == true)
            {
                int linesToPlay = InterfaceMethods.HowMuchLines();
                totalCredit = totalCredit - linesToPlay;

                if (totalCredit < 0)
                {
                    InterfaceMethods.BudgetForWagerToLow();
                    totalCredit = totalCredit + linesToPlay;
                    continue;
                }

                List<int> lineVariantList = InterfaceMethods.WhichLines(linesToPlay);

                int[,] getSlotNumbers = LogicMethods.CreateRandomSlotNumbers();

                InterfaceMethods.PrintSlotNumbers(getSlotNumbers);

                int getWagerResult = LogicMethods.WagerResult(lineVariantList, getSlotNumbers);

                int wagerCredit = LogicMethods.WagerCredit(getWagerResult, linesToPlay);

                InterfaceMethods.ShowWagerResult(wagerCredit);

                totalCredit = totalCredit + wagerCredit;

                if (totalCredit == 0)
                {
                    InterfaceMethods.OutOfCreditMessage(totalCredit);
                }
                InterfaceMethods.ShowTotalCredit(totalCredit);

                playAgain = InterfaceMethods.KeepPlaying();
            }
            Console.WriteLine("\nThanks for playing");
        }
    }
}