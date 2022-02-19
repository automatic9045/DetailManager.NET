using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.Properties;

namespace Automatic9045.DetailManagerNET
{
    internal static class PluginListLoader
    {
        public static IEnumerable<string> LoadFrom(string listPath)
        {
            if (!File.Exists(listPath))
            {
                throw new FileNotFoundException(string.Format(Resources.PluginListNotFound, listPath), listPath);
            }

            using (StreamReader sr = new StreamReader(listPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Split(';')[0];
                    if (line == "") continue;

                    yield return line;
                }
            }
        }
    }
}
