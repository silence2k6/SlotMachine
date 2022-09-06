using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {
        public static int[,] GetRandomSlotNumbers()
        {
            int[,] slotNumbers = new int[3, 3];
            Random randomNumber = new Random();

            int i = 0;

            while (i < slotNumbers.GetLength(0))
            {
                int j = 0;

                while (j < slotNumbers.GetLength(1))
                {
                    slotNumbers[i, j] = randomNumber.Next(1, 10);
                    j++;
                }
                i++;
            }
            return slotNumbers;
        }

        public static int WagerResult(List<int>lineVariantList, int linesToPlay, int[,] slotNumbers)
        {
            List<int> totalCredit = new List<int>();
            List<int> wagerCredit = new List<int>();
            totalCredit.Add(20);

            while (linesToPlay > 0)
            {
                //Variante WIE 1.Line gespielt werden soll aus VariantenListe holen
                //Line ODER erste Spalte ODER erste Diagonale aus RandomArray holen
                //3 Methoden für Line/Spalte/Diagonale erstellen
                //in entsprechende Methode prüfen ob Übereinstimmung besteht + Wenn ja, EINEN Punkt zu Liste wagerCredit hinzu fügen + EINEN Punkt in Methode setzen
                //Variante WIE 2.Linie gespielt werden soll aus VariantenListe holen
                //prüfen ob Methode schon Einen Punkte hat + Wenn ja, zweite Linie/Spalte/Diagonale aus Liste holen + Wenn schon zwei Punkte dann dritte Linie/Spalte
                //...
                //Wenn linesToPlay erreicht wird, Liste wagerCredit prüfen und Punkte zusammenrechnen + zu Liste total Credit hinzufügen + Spieleinsatz von total Credit abziehen
            }
        }
    }
}
