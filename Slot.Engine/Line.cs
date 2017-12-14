#region

using System.Collections.Generic;

#endregion

namespace Slot.Engine
{
    public class Line
    {
        public Line(int[] linePoints)
        {
            LinePoints = linePoints;
            Symbols = new List<Symbol>(5);
        }

        public List<Symbol> Symbols { get; private set; }

        public int[] LinePoints { get; private set; }

        public int Score { get; private set; }

        public void CalculateScore()
        {
            int count = 1;
            bool containsWild = false;

            for (int i = 1; i < Symbols.Count; i++)
            {
                if (Symbols[i].SymbolId == SymbolId.W)
                {
                    containsWild = true;
                    count++;
                }
                else if (Symbols[i].SymbolId == Symbols[0].SymbolId)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            Score = Symbols[0].GetScore(count);

            if (containsWild)
                Score *= 2;
        }
    }
}