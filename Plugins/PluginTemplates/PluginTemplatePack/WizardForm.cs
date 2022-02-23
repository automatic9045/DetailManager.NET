using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Automatic9045.DetailManagerNET.PluginTemplates
{
    internal partial class WizardForm : Form
    {
        public static CodeDomProvider CodeDomProvider { get; } = CodeDomProvider.CreateProvider("C#");

        protected int _PageIndex;
        protected int PageIndex
        {
            get => _PageIndex;
            set
            {
                if (value < 0 || Pages.Count <= value)
                {
                    throw new ArgumentOutOfRangeException(nameof(PageIndex));
                }

                _PageIndex = value;

                Pages.ForEach(page => page.Visible = false);
                WizardPageBase currentPage = Pages[PageIndex];

                Caption.Text = $"STEP {PageIndex + 1}/{Pages.Count}: {currentPage.Caption}";
                Description.Text = currentPage.Description;

                Previous.Enabled = 0 < PageIndex;
                Previous.Visible = Previous.Enabled;
                Next.Enabled = PageIndex < Pages.Count - 1;
                Next.Visible = Next.Enabled;
                Create.Enabled = PageIndex == Pages.Count - 1;
                Create.Visible = Create.Enabled;

                currentPage.PreviewShowPage(Pages.AsReadOnly());
                currentPage.Visible = true;
            }
        }

        public string DeveloperName => (Pages.First(page => page is Page1) as Page1).DeveloperName;
        public string PluginName => (Pages.First(page => page is Page1) as Page1).PluginName;
        public string Namespace => (Pages.First(page => page is Page2) as Page2).Namespace;
        public string AssemblyFileName => (Pages.First(page => page is Page2) as Page2).AssemblyFileName;

        public WizardForm(string projectName)
        {
            InitializeComponent(projectName);
            Pages.ForEach(page =>
            {
                page.CanGoNextChanged += OnCanGoNextChanged;
            });

            Shown += (sender, e) => PageIndex = 0;
        }

        private void OnCanGoNextChanged(CanGoNextChangedEventArgs e)
        {
            if (Next.Visible) Next.Enabled = e.CanGoNext;
            if (Create.Visible) Create.Enabled = e.CanGoNext;
        }
    }
}
