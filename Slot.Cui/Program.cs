#region

using System;
using System.Linq;
using System.Threading;
using Slot.Engine;

#endregion

namespace Slot.Cui
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int count = 0;
            long prizeSum = 0;

            while (true)
            {
                count++;

                Game game = Game.Run();

                prizeSum -= 20;
                prizeSum += game.TotalScore;

                if (game.TotalScore < 20000)
                    continue;

                Console.WriteLine("{0:N0}번째", count);

                PrintSymbols(game);

                Console.WriteLine("상금 {0:C0}", game.TotalScore);
                PrintLineScores(game);
                PrintScatterScore(game);
                Console.WriteLine("잔고 {0:C0}", prizeSum);
                Console.WriteLine();

//                Thread.Sleep(500);
            }
        }

        private static void PrintScatterScore(Game game)
        {
            if (game.ScatterScore > 0)
                Console.WriteLine("Scatter : {0:N0}", game.ScatterScore);
        }

        private static void PrintLineScores(Game game)
        {
            for (int i = 0; i < game.Lines.Count; i++)
            {
                if (game.Lines[i].Score == 0)
                    continue;

                string lineSymbols = string.Join(", ", game.Lines[i].Symbols.Select(x => x.SymbolId.ToString()).ToArray());
                Console.WriteLine("\t라인 {0}, {1:C0} -> {2}", i + 1, game.Lines[i].Score, lineSymbols);
            }
        }

        private static void PrintSymbols(Game game)
        {
            for (int i = 0; i < game.Symbols.Count; i++)
            {
                Console.Write(game.Symbols[i].SymbolId);
                if (i%5 == 4)
                    Console.WriteLine();
            }
        }
    }
}