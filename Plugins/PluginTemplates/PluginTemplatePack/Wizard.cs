using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

using Automatic9045.DetailManagerNET.PluginTemplates.Properties;

namespace Automatic9045.DetailManagerNET.PluginTemplates
{
    public class Wizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            string destinationDirectory = replacementsDictionary["$destinationdirectory$"];
            string solutionDirectory = replacementsDictionary["$solutiondirectory$"];
            try
            {
                WizardForm form = new WizardForm(replacementsDictionary["$projectname$"]);
                DialogResult result = form.ShowDialog();

                if (result != DialogResult.OK)
                {
                    throw new WizardBackoutException();
                }

                replacementsDictionary.Add("$developername$", form.DeveloperName);
                replacementsDictionary.Add("$pluginname$", form.PluginName);
                replacementsDictionary.Add("$namespace$", form.Namespace);
                replacementsDictionary.Add("$assemblyfilename$", form.AssemblyFileName);
            }
            catch (WizardBackoutException)
            {
                TryCleanDestinationDirectory();
                throw;
            }
            catch (Exception ex)
            {
                TryCleanDestinationDirectory();
                MessageBox.Show(ex.ToString(), Resources.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            void TryCleanDestinationDirectory()
            {
                if (Directory.Exists(destinationDirectory))
                {
                    Directory.Delete(destinationDirectory, true);

                    if (Directory.Exists(solutionDirectory))
                    {
                        Directory.Delete(solutionDirectory, true);
                    }
                }
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}