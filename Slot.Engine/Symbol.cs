#region

using System;
using System.Collections.Generic;
using System.Drawing;
using Slot.Engine.Properties;

#endregion

namespace Slot.Engine
{
    public class Symbol
    {
        private Symbol(SymbolId symbolId, params int[] scores)
        {
            _scores = scores;
            SymbolId = symbolId;
            Image = (Bitmap) Resources.ResourceManager.GetObject(SymbolId.ToString());
        }

        private readonly int[] _scores;

        public SymbolId SymbolId { get; private set; }

        public int GetScore(int count)
        {
            switch (count)
            {
                case 5:
                    return _scores[0];
                case 4:
                    return _scores[1];
                case 3:
                    return _scores[2];
                case 2:
                    return _scores[3];
                default:
                    return 0;
            }
        }

        public Bitmap Image { get; private set; }

        #region factory

        static Symbol()
        {
            _symbols.Add(new Symbol(SymbolId.W, 10000, 2500, 200, 10));
            _symbols.Add(new Symbol(SymbolId.E, 1000, 125, 25, 2));
            _symbols.Add(new Symbol(SymbolId.D, 1000, 125, 25, 2));
            _symbols.Add(new Symbol(SymbolId.C, 300, 75, 10, 2));
            _symbols.Add(new Symbol(SymbolId.B, 300, 75, 10, 2));
            _symbols.Add(new Symbol(SymbolId.A, 150, 30, 5, 0));
            _symbols.Add(new Symbol(SymbolId.K, 150, 30, 5, 0));
            _symbols.Add(new Symbol(SymbolId.Q, 125, 20, 5, 0));
            _symbols.Add(new Symbol(SymbolId.J, 125, 20, 5, 0));
            _symbols.Add(new Symbol(SymbolId.T, 100, 15, 5, 0));
            _symbols.Add(new Symbol(SymbolId.N, 100, 15, 5, 0));
            _symbols.Add(new Symbol(SymbolId.S, 0, 0, 0, 0));
        }

        private static readonly List<Symbol> _symbols = new List<Symbol>(12);

        private static readonly Random _random = new Random();

        public static Symbol Create()
        {
            return _symbols[_random.Next(_symbols.Count)];
        }
        #endregion

    }
}