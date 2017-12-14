#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Slot.Winform
{
    public partial class LineScoreViewer : UserControl
    {
        public LineScoreViewer()
        {
            InitializeComponent();
        }

        private int _lineIndex;
        
        private int _score;

        public void Display(int lineIndex, int score)
        {
            _lineIndex = lineIndex;
            _score = score;

            lblScore.Text = string.Format("[{0}] {1:C0}", lineIndex + 1, score);

            lblScore.ForeColor = score > 0 ? Color.Blue : Color.Black;
        }

        private void lblScore_MouseEnter(object sender, EventArgs e)
        {
            if (_score > 0)
            OnActivated(_lineIndex);
        }

        private void lblScore_MouseLeave(object sender, EventArgs e)
        {
            OnDeactivated(null);
        }

        #region Activated event things for C# 3.0
        public event EventHandler<ActivatedEventArgs> Activated;

        protected virtual void OnActivated(ActivatedEventArgs e)
        {
            if (Activated != null)
                Activated(this, e);
        }

        protected virtual void OnActivated(int lineIndex)
        {
            OnActivated(new ActivatedEventArgs(lineIndex));
        }

        protected virtual ActivatedEventArgs OnActivatedWithReturn(int lineIndex)
        {
            ActivatedEventArgs args = new ActivatedEventArgs(lineIndex);
            OnActivated(args);

            return args;
        }

        public class ActivatedEventArgs : EventArgs
        {
            public int LineIndex { get; set; }

            public ActivatedEventArgs()
            {
            }

            public ActivatedEventArgs(int lineIndex)
            {
                LineIndex = lineIndex;
            }
        }
        #endregion

        #region Deactivated event things for C# 3.0
        public event EventHandler<DeactivatedEventArgs> Deactivated;

        protected virtual void OnDeactivated(DeactivatedEventArgs e)
        {
            if (Deactivated != null)
                Deactivated(this, e);
        }

        protected virtual void OnDeactivated(object dummy)
        {
            OnDeactivated(new DeactivatedEventArgs(dummy));
        }

        protected virtual DeactivatedEventArgs OnDeactivatedWithReturn(object dummy)
        {
            DeactivatedEventArgs args = new DeactivatedEventArgs(dummy);
            OnDeactivated(args);

            return args;
        }

        public class DeactivatedEventArgs : EventArgs
        {
            public object Dummy { get; set; }

            public DeactivatedEventArgs()
            {
            }

            public DeactivatedEventArgs(object dummy)
            {
                Dummy = dummy;
            }
        }
        #endregion
    }
}