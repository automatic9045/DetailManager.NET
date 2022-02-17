using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.Properties;
using Automatic9045.DetailManagerNET.PluginHost;

namespace Automatic9045.DetailManagerNET
{
    internal static class PluginLoader
    {
        public static IAtsPlugin Load()
        {
            string targetAssemblyPath = null;
            Assembly targetAssembly;
            try
            {
                string executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
                string wrapperDllString = ".wrapper.dll";
                if (!executingAssemblyPath.ToLower().EndsWith(wrapperDllString))
                {
                    throw new FileLoadException(string.Format(Resources.WrapperDllFileNameIllegal, Path.GetFileName(executingAssemblyPath)));
                }

                targetAssemblyPath = executingAssemblyPath.Substring(0, executingAssemblyPath.Length - wrapperDllString.Length) + ".dll";
                if (!File.Exists(targetAssemblyPath))
                {
                    throw new FileNotFoundException(string.Format(Resources.TargetDllNotFound, targetAssemblyPath));
                }

                try
                {
                    targetAssembly = Assembly.LoadFrom(targetAssemblyPath);
                }
                catch (BadImageFormatException ex)
                {
                    throw new Exception(string.Format(Resources.TargetDllBadImageFormat, targetAssemblyPath), ex);
                }

                Type[] types = targetAssembly.GetTypes();
                IEnumerable<Type> pluginTypes = types.Where(t => t.IsPublic && !t.IsAbstract && t.IsClass && t.GetInterfaces().Contains(typeof(IAtsPlugin)));
                if (!pluginTypes.Any())
                {
                    throw new Exception(string.Format(Resources.PluginTypeNotFound, targetAssemblyPath, nameof(IAtsPlugin)));
                }
                else if (pluginTypes.Count() > 1)
                {
                    throw new Exception(string.Format(Resources.PluginTypeTooMeny, targetAssemblyPath));
                }

                Type pluginType = pluginTypes.First();

                if (pluginType.GetConstructor(Type.EmptyTypes) is null)
                {
                    Type type = pluginTypes.First(t => t.GetConstructor(Type.EmptyTypes) is null);
                    throw new TypeLoadException(string.Format(Resources.PluginTypeNoParamLessConstructor, type.FullName));
                }

                IAtsPlugin targetPlugin = (IAtsPlugin)Activator.CreateInstance(pluginType);
                return targetPlugin;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), string.Format(Resources.LoadErrorOccured, targetAssemblyPath is null ? "" : Path.GetFileName(targetAssemblyPath)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
