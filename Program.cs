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
               
                int [,] slotNumbers = InterfaceMethods.ShowRandomSlotNumbers(LogicMethods.CreateRandomSlotNumbers());

                List<int> wagerResultList = new List<int>(LogicMethods.WagerResult(lineVariantList, linesToPlay, slotNumbers));
                int wagerCredit = wagerResultList.Sum();

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