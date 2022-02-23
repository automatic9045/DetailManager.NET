using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.PluginTemplates.Properties;

namespace Automatic9045.DetailManagerNET.PluginTemplates
{
    internal partial class WizardForm : Form
    {
        public partial class Page1 : WizardPageBase
        {
            public override string Caption => Resources.Page1Caption;
            public override string Description => Resources.Page1Description;

            public string DeveloperName => DeveloperNameValue?.Text;
            public string PluginName => PluginNameValue?.Text;

            public override event CanGoNextChangedEventHandler CanGoNextChanged;

            protected Label DeveloperNameKey;
            protected TextBox DeveloperNameValue;

            protected Label PluginNameKey;
            protected TextBox PluginNameValue;

            public Page1(string projectName)
            {
                InitializeComponent(projectName);
            }

            protected void InitializeComponent(string projectName)
            {
                AutoScaleMode = AutoScaleMode.Dpi;
                VisibleChanged += OnVisibleChanged;


                DeveloperNameKey = new Label()
                {
                    Left = 0,
                    Top = 0,
                    Width = 640,
                    Text = Resources.Page1DeveloperName,
                };
                Controls.Add(DeveloperNameKey);

                DeveloperNameValue = new TextBox()
                {
                    Left = 0,
                    Top = 0 + 24,
                    Width = 320,
                };
                DeveloperNameValue.TextChanged += OnTextChanged;
                Controls.Add(DeveloperNameValue);


                PluginNameKey = new Label()
                {
                    Left = 0,
                    Top = 64,
                    Width = 640,
                    Text = Resources.Page1PluginName,
                };
                Controls.Add(PluginNameKey);

                PluginNameValue = new TextBox()
                {
                    Left = 0,
                    Top = 64 + 24,
                    Width = 320,
                    Text = projectName,
                };
                PluginNameValue.TextChanged += OnTextChanged;
                Controls.Add(PluginNameValue);
            }

            private void OnVisibleChanged(object sender, EventArgs e)
            {
                if (Visible)
                {
                    DeveloperNameValue.Focus();
                }
            }

            private void OnTextChanged(object sender, EventArgs e)
            {
                UpdateCanGoNext();
            }

            public override void PreviewShowPage(IReadOnlyList<WizardPageBase> pages)
            {
                UpdateCanGoNext();
            }

            private void UpdateCanGoNext()
            {
                bool isDeveloperNameValid = IsValidText(DeveloperName);
                bool isPluginNameValid = IsValidText(PluginName);

                CanGoNextChanged(new CanGoNextChangedEventArgs(isDeveloperNameValid && isPluginNameValid));


                bool IsValidText(string text)
                {
                    return text != "" && Regex.IsMatch(text, @"^[0-9a-zA-Z_]+$");
                }
            }
        }
    }
}
