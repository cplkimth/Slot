#region

using System;
using System.Windows.Forms;
using Slot.Engine;
using Slot.Winform.Properties;

#endregion

namespace Slot.Winform
{
    public partial class MainForm : Form
    {
        private Game _game;

        public MainForm()
        {
            InitializeComponent();

            _lineScoreViewers = new[]
                                    {
                                        uscLineScoreViewer0,
                                        uscLineScoreViewer1,
                                        uscLineScoreViewer2,
                                        uscLineScoreViewer3,
                                        uscLineScoreViewer4,
                                        uscLineScoreViewer5,
                                        uscLineScoreViewer6,
                                        uscLineScoreViewer7,
                                        uscLineScoreViewer8,
                                        uscLineScoreViewer9,
                                        uscLineScoreViewer10,
                                        uscLineScoreViewer11,
                                        uscLineScoreViewer12,
                                        uscLineScoreViewer13,
                                        uscLineScoreViewer14,
                                        uscLineScoreViewer15,
                                        uscLineScoreViewer16,
                                        uscLineScoreViewer17,
                                        uscLineScoreViewer18,
                                        uscLineScoreViewer19
                                    };
        }

        private readonly LineScoreViewer[] _lineScoreViewers;

        private long _money;

        private int _gameCount = 0;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            for (int i = 0; i < Settings.Default.MaxLine; i++)
                _lineScoreViewers[i].Display(i, 0);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            _gameCount++;

            _game = Game.Run();

            lblScore.Text = (_game.TotalScore * Settings.Default.WonPerLine).ToString("C0");

            _money -= Settings.Default.MaxLine * Settings.Default.WonPerLine;
            _money += _game.TotalScore * Settings.Default.WonPerLine;
            lblSummary.Text = string.Format("{0:N0}회, {1:C0}", _gameCount, _money);

            uscReelViewer.LoadImages(_game.Symbols);

            for (int i = 0; i < _game.Lines.Count; i++)
                _lineScoreViewers[i].Display(i, _game.Lines[i].Score * Settings.Default.WonPerLine);

            uscReelViewer.ClearLine();
        }

        private void uscLineScoreViewer_Activated(object sender, LineScoreViewer.ActivatedEventArgs e)
        {
            uscReelViewer.DisplayLine(_game.Lines[e.LineIndex]);
        }

        private void uscLineScoreViewer_Deactivated(object sender, LineScoreViewer.DeactivatedEventArgs e)
        {
            uscReelViewer.ClearLine();
        }
    }
}