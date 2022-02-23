using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Automatic9045.DetailManagerNET.PluginTemplates
{
    internal partial class WizardForm : Form
    {
        public delegate void CanGoNextChangedEventHandler(CanGoNextChangedEventArgs e);

        public class CanGoNextChangedEventArgs : EventArgs
        {
            public bool CanGoNext { get; }

            public CanGoNextChangedEventArgs(bool canGoNext)
            {
                CanGoNext = canGoNext;
            }
        }

        public abstract class WizardPageBase : UserControl
        {
            public abstract string Caption { get; }
            public abstract string Description { get; }

            public abstract void PreviewShowPage(IReadOnlyList<WizardPageBase> pages);

            public abstract event CanGoNextChangedEventHandler CanGoNextChanged;
        }
    }
}
