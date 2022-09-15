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

                if (totalCreditList.Sum() < 0)
                {
                    InterfaceMethods.BudgetForWagerToLow();
                    totalCreditList.Add(linesToPlay);
                    continue;
                }

                List<int> lineVariantList = InterfaceMethods.WhichLines(linesToPlay);
               
                int [,] slotNumbers = InterfaceMethods.ShowRandomSlotNumbers(LogicMethods.CreateRandomSlotNumbers());

                int wagerCredit = LogicMethods.wagerCredit(LogicMethods.WagerResult(lineVariantList, linesToPlay, slotNumbers), linesToPlay);

                InterfaceMethods.ShowWagerResult(wagerCredit);

                int totalCredit = wagerCredit + totalCreditList.Sum();

                if (totalCredit == 0)
                {
                    InterfaceMethods.OutOfCreditMessage(totalCredit);
                }
                InterfaceMethods.ShowTotalCredit(totalCredit);
            }
        }
    }
}