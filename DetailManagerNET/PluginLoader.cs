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
        public static IEnumerable<IAtsPlugin> LoadFrom(string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
            {
                throw new FileNotFoundException(string.Format(Resources.TargetDllNotFound, assemblyPath), assemblyPath);
            }

            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(assemblyPath);
            }
            catch (BadImageFormatException ex)
            {
                throw new Exception(string.Format(Resources.TargetDllBadImageFormat, assemblyPath), ex);
            }

            Type[] types = assembly.GetTypes();
            IEnumerable<Type> pluginTypes = types.Where(t => t.IsPublic && !t.IsAbstract && t.IsClass && t.GetInterfaces().Contains(typeof(IAtsPlugin)));
            if (!pluginTypes.Any())
            {
                throw new Exception(string.Format(Resources.PluginTypeNotFound, assemblyPath, nameof(IAtsPlugin)));
            }

            Type pluginType = pluginTypes.First();

            if (pluginType.GetConstructor(Type.EmptyTypes) is null)
            {
                Type type = pluginTypes.First(t => t.GetConstructor(Type.EmptyTypes) is null);
                throw new TypeLoadException(string.Format(Resources.PluginTypeNoParamLessConstructor, type.FullName));
            }

            IAtsPlugin targetPlugin = (IAtsPlugin)Activator.CreateInstance(pluginType);
            yield return targetPlugin;
        }
    }
}
