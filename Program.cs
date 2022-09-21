using System.Xml.Schema;

namespace SlotMachine
{
    public enum WagerVariant
    {
        Row = 1,
        Col,
        Diagonal
    }

    internal class Program
    {
        const int USER_STARTING_CREDITS = 30;

        static void Main(string[] args)
        {
            InterfaceMethods.GameIntro();

            bool playAgain = true;
            int totalCredit = USER_STARTING_CREDITS;

            while (playAgain == true)
            {
                int linesToPlay = InterfaceMethods.HowMuchLines();

                if (totalCredit - linesToPlay < 0)
                {
                    InterfaceMethods.BudgetForWagerToLow();
                    continue;
                }

                totalCredit -= linesToPlay;

                List<WagerVariant> lineVariantList = InterfaceMethods.WhichLines(linesToPlay);

                int[,] slotNumbers = LogicMethods.CreateRandomSlotNumbers();

                InterfaceMethods.PrintSlotNumbers(slotNumbers);

                int wagerResult = LogicMethods.WagerResult(lineVariantList, slotNumbers);

                int wagerCredit = LogicMethods.WagerCredit(wagerResult, linesToPlay);

                InterfaceMethods.ShowWagerResult(wagerCredit);

                totalCredit += wagerCredit;

                InterfaceMethods.ShowTotalCredit(totalCredit);

                if (totalCredit == 0)
                {
                    InterfaceMethods.OutOfCreditMessage(totalCredit);
                    totalCredit = USER_STARTING_CREDITS;
                }

                playAgain = InterfaceMethods.KeepPlaying(totalCredit);
            }
            Console.WriteLine("\nThanks for playing");
        }
    }
}