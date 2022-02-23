using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.PluginTemplates.Properties;

namespace Automatic9045.DetailManagerNET.PluginTemplates
{
    internal partial class WizardForm : Form
    {
        protected Label Title;
        protected Label Caption;
        protected Label Description;

        protected List<WizardPageBase> Pages;

        protected Button Previous;
        protected Button Next;
        protected Button Create;

        protected void InitializeComponent(string projectName)
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 400);
            BackColor = Color.FromArgb(0xfb, 0xfb, 0xfb);
            Font = new Font("Yu Gothic UI", 9);
            Text = Resources.Title;


            Title = new Label()
            {
                Left = 32,
                Top = 24,
                Width = 736,
                Height = 56,
                Font = new Font("Yu Gothic UI", 28),
                Text = "DetailManager.NET",
            };
            Controls.Add(Title);

            Caption = new Label()
            {
                Left = 32,
                Top = 88,
                Width = 736,
                Height = 30,
                Font = new Font("Yu Gothic UI", 15),
            };
            Controls.Add(Caption);

            Description = new Label()
            {
                Left = 32,
                Top = 120,
                Width = 752,
                Height = 30,
                Font = new Font("Yu Gothic UI", 12),
            };
            Controls.Add(Description);


            Pages = new List<WizardPageBase>()
            {
                new Page1(projectName),
                new Page2(),
            };
            Pages.ForEach(page => RegisterPage(page));


            Previous = new Button()
            {
                Left = 608,
                Top = 344,
                Text = Resources.Previous,
            };
            Previous.Click += (sender, e) => PageIndex--;
            Controls.Add(Previous);

            Next = new Button()
            {
                Left = 688,
                Top = 344,
                Text = Resources.Next,
            };
            Next.Click += (sender, e) => PageIndex++;
            Controls.Add(Next);

            Create = new Button()
            {
                Left = 688,
                Top = 344,
                Text = Resources.Create,
                DialogResult = DialogResult.OK,
            };
            Create.Click += (sender, e) => Close();
            Controls.Add(Create);


            void RegisterPage(WizardPageBase page)
            {
                page.Left = 32;
                page.Top = 160;
                page.Size = new Size(736, 160);
                page.Visible = false;

                Controls.Add(page);
            }
        }
    }
}
