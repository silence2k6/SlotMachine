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

                List<int> wagerResultList = new List<int>(LogicMethods.WagerResult(lineVariantList, linesToPlay, slotNumbers));
                int wagerCredit = wagerResultList.Sum();

                InterfaceMethods.ShowWagerResult(wagerCredit);

                int totalCredit = wagerCredit + totalCreditList.Sum();

                if (totalCredit == 0)
                {
                    InterfaceMethods.OutOfCreditMessage(totalCredit);
                }
                totalCreditList.Add(100);
                InterfaceMethods.ShowTotalCredit(totalCredit);
            }
        }
    }
}