#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Slot.Engine
{
    public class Game
    {
        static Game()
        {
            #region _linePoints
            _linePoints[0] = new[] { 5, 6, 7, 8, 9 };
            _linePoints[1] = new[] { 0, 1, 2, 3, 4 };
            _linePoints[2] = new[] { 10, 11, 12, 13, 14 };
            _linePoints[3] = new[] { 0, 6, 12, 8, 4 };
            _linePoints[4] = new[] { 10, 6, 2, 8, 14 };
            _linePoints[5] = new[] { 5, 1, 7, 3, 9 };
            _linePoints[6] = new[] { 5, 11, 7, 13, 9 };
            _linePoints[7] = new[] { 0, 6, 2, 8, 4 };
            _linePoints[8] = new[] { 10, 6, 12, 8, 14 };
            _linePoints[9] = new[] { 5, 1, 2, 3, 9 };
            _linePoints[10] = new[] { 5, 11, 12, 13, 9 };
            _linePoints[11] = new[] { 10, 11, 7, 13, 14 };
            _linePoints[12] = new[] { 0, 1, 7, 3, 4 };
            _linePoints[13] = new[] { 10, 6, 7, 8, 14 };
            _linePoints[14] = new[] { 0, 6, 7, 8, 4 };
            _linePoints[15] = new[] { 0, 11, 2, 13, 4 };
            _linePoints[16] = new[] { 10, 1, 12, 3, 14 };
            _linePoints[17] = new[] { 5, 6, 2, 8, 9 };
            _linePoints[18] = new[] { 5, 6, 12, 8, 9 };
            _linePoints[19] = new[] { 10, 11, 2, 13, 14 };
            #endregion
        }

        private Game()
        {
            Symbols = new List<Symbol>(15);
            for (int i = 0; i < Symbols.Capacity; i++)
                Symbols.Add(Symbol.Create());

            Lines = new List<Line>(_linePoints.Length);
            foreach (int[] linePoint in _linePoints)
            {
                Line line = new Line(linePoint);

                foreach (int i in linePoint)
                    line.Symbols.Add(Symbols[i]);

                line.CalculateScore();

                Lines.Add(line);
            }

            ScatterScore = CalculateScatter();
            LineScoreSum = Lines.Sum(x => x.Score);
            TotalScore = LineScoreSum + ScatterScore;
        }

        public static Game Run()
        {
            return new Game();
        }

        private static readonly int[][] _linePoints = new int[20][];

        public int ScatterScore { get; private set; }
        
        public int LineScoreSum { get; private set; }

        public int TotalScore { get; private set; }

        public List<Line> Lines { get; private set; }

        public List<Symbol> Symbols { get; private set; }

        private int CalculateScatter()
        {
            switch (Symbols.Count(x => x.SymbolId == SymbolId.S))
            {
                case 5:
                    return 500;
                case 4:
                    return 200;
                case 3:
                    return 5;
                case 2:
                    return 2;
                default:
                    return 0;
            }
        }
    }
}