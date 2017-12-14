#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Slot.Engine;

#endregion

namespace Slot.Winform
{
    public partial class ReelViewer : UserControl
    {
        public ReelViewer()
        {
            InitializeComponent();

            _pictureBoxs = new[]
                               {
                                   ptbSymbol0,
                                   ptbSymbol1,
                                   ptbSymbol2,
                                   ptbSymbol3,
                                   ptbSymbol4,
                                   ptbSymbol5,
                                   ptbSymbol6,
                                   ptbSymbol7,
                                   ptbSymbol8,
                                   ptbSymbol9,
                                   ptbSymbol10,
                                   ptbSymbol11,
                                   ptbSymbol12,
                                   ptbSymbol13,
                                   ptbSymbol14
                               };
        }

        private readonly PictureBox[] _pictureBoxs;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;
        }

        public void LoadImages(List<Symbol> symbols)
        {
            for (int i = 0; i < _pictureBoxs.Length; i++)
                _pictureBoxs[i].Image = symbols[i].Image;
        }

        public void DisplayLine(Line line)
        {
            ClearLine();

            foreach (var linePoint in line.LinePoints)
                _pictureBoxs[linePoint].BackColor = Color.Red;
        }

        public void ClearLine()
        {
            Array.ForEach(_pictureBoxs, x => x.BackColor = BackColor);
        }
    }
}