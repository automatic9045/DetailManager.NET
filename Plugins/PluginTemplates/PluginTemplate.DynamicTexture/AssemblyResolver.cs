using System;
using System.IO;
using System.Reflection;

namespace $namespace$
{
    internal class AssemblyResolver
    {
        public static Assembly Resolve(object sender, ResolveEventArgs args)
        {
            string libPath = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            if (args.Name.Contains("DXDynamicTexture"))
            {
                string fileName = (IntPtr.Size == 8) ? "Zbx1425.DXDynamicTexture-net48.dll" : "Zbx1425.DXDynamicTexture-net35.dll";
                return Assembly.LoadFile(Path.Combine(libPath, fileName));
            }
            else if (args.Name.Contains("0Harmony"))
            {
                string fileName = (IntPtr.Size == 8) ? "Harmony-net48.dll" : "Harmony-net35.dll";
                return Assembly.LoadFile(Path.Combine(libPath, fileName));
            }
            return null;
        }
    }
}
