using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.PluginTemplates.Properties;

namespace Automatic9045.DetailManagerNET.PluginTemplates
{
    internal partial class WizardForm : Form
    {
        public partial class Page2 : WizardPageBase
        {
            public override string Caption => Resources.Page2Caption;
            public override string Description => Resources.Page2Description;

            public string Namespace => NamespaceValue?.Text;
            public string AssemblyFileName => AssemblyFileNameValue?.Text;

            public override event CanGoNextChangedEventHandler CanGoNextChanged;

            protected Label NamespaceKey;
            protected TextBox NamespaceValue;

            protected Label AssemblyFileNameKey;
            protected TextBox AssemblyFileNameValue;
            protected Label AssemblyFileNameSuffix;

            public Page2()
            {
                InitializeComponent();
            }

            protected void InitializeComponent()
            {
                AutoScaleMode = AutoScaleMode.Dpi;
                VisibleChanged += OnVisibleChanged;

                NamespaceKey = new Label()
                {
                    Left = 0,
                    Top = 0,
                    Width = 640,
                    Text = Resources.Page2Namespace,
                };
                Controls.Add(NamespaceKey);

                NamespaceValue = new TextBox()
                {
                    Left = 0,
                    Top = 0 + 24,
                    Width = 320,
                };
                NamespaceValue.TextChanged += OnTextChanged;
                Controls.Add(NamespaceValue);


                AssemblyFileNameKey = new Label()
                {
                    Left = 0,
                    Top = 64,
                    Width = 640,
                    Text = Resources.Page2AssemblyFileName,
                };
                Controls.Add(AssemblyFileNameKey);

                AssemblyFileNameValue = new TextBox()
                {
                    Left = 0,
                    Top = 64 + 24,
                    Width = 320,
                };
                AssemblyFileNameValue.TextChanged += OnTextChanged;
                Controls.Add(AssemblyFileNameValue);

                AssemblyFileNameSuffix = new Label()
                {
                    Left = 322,
                    Top = 64 + 24 + 2,
                    Width = 160,
                    Text = ".dll",
                };
                Controls.Add(AssemblyFileNameSuffix);
            }

            private void OnTextChanged(object sender, EventArgs e)
            {
                UpdateCanGoNext();
            }

            private void OnVisibleChanged(object sender, EventArgs e)
            {
                if (Visible)
                {
                    NamespaceValue.Focus();
                }
            }

            public override void PreviewShowPage(IReadOnlyList<WizardPageBase> pages)
            {
                Page1 page1 = pages.First(page => page is Page1) as Page1;

                string developerName = CreateValidIdentifier(FirstLetterToUpper(page1.DeveloperName));
                string pluginName = CreateValidIdentifier(FirstLetterToUpper(page1.PluginName));
                NamespaceValue.Text = $"{developerName}.{pluginName}";

                AssemblyFileNameValue.Text = page1.PluginName;

                UpdateCanGoNext();


                string CreateValidIdentifier(string text)
                {
                    text = CodeDomProvider.CreateValidIdentifier(text);
                    if (!char.IsLetter(text[0]) && text[0] != '_') text = text.Insert(0, "_");

                    return text;
                }

                string FirstLetterToUpper(string text)
                {
                    if (text is null)
                    {
                        throw new ArgumentNullException(nameof(text));
                    }

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (char.IsLetter(text, i))
                        {
                            return text.Substring(0, i) + char.ToUpper(text[i]) + text.Substring(i + 1);
                        }
                    }

                    return text;
                }
            }

            private void UpdateCanGoNext()
            {
                bool isNamespaceValid = IsValidNamespace(Namespace);
                bool isAssemblyFileNameValid = AssemblyFileName != "";

                CanGoNextChanged(new CanGoNextChangedEventArgs(isNamespaceValid && isAssemblyFileNameValid));


                bool IsValidNamespace(string text)
                {
                    string[] sections = text.Split('.');
                    return sections.All(section => Regex.IsMatch(section, @"^[0-9a-zA-Z_]+$") && CodeDomProvider.IsValidIdentifier(section));
                }
            }
        }
    }
}
