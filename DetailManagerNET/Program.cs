using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.PluginHost;
using Automatic9045.DetailManagerNET.Properties;

namespace Automatic9045.DetailManagerNET
{
    /// <summary>
    /// Basics of ATS plug-in.
    /// </summary>
    internal static class AtsMain
    {
        /// <summary>
        /// ATS Plug-in Version
        /// </summary>
        private const int Version = 0x00020000;

        static AtsMain()
        {
#if DEBUG
            MessageBox.Show($"DetailManager.NET\nCopyright © 2022 Automatic9045\n\nデバッグモードで読み込まれました。");
#endif
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                if (e.Name.Contains("DetailManagerNET.PluginHost"))
                {
                    return Assembly.LoadFile(Path.Combine(BaseDirectory, "DetailManagerNET.PluginHost.dll"));
                }
                else
                {
                    return null;
                }
            };
        }

        private static string BaseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static List<IAtsPlugin> TargetPlugins;

        private static int Brake;
        private static int Power;
        private static int Reverser;

        /// <summary>
        /// Called when this plug-in is loaded
        /// </summary>
        [DllExport(CallingConvention.StdCall)]
        public static void Load()
        {
            string[] assemblyPaths = PluginListLoader.LoadFrom(Path.Combine(BaseDirectory, "DetailModulesNET.txt")).ToArray();
            TargetPlugins = new List<IAtsPlugin>();
            foreach (string assemblyPath in assemblyPaths)
            {
                try
                {
                    TargetPlugins.AddRange(PluginLoader.LoadFrom(Path.Combine(BaseDirectory, assemblyPath)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), string.Format(Resources.LoadErrorOccured, assemblyPath is null ? "" : Path.GetFileName(assemblyPath)), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        /// <summary>
        /// Called when this plug-in is unloaded
        /// </summary>
        [DllExport(CallingConvention.StdCall)]
        public static void Dispose() => TargetPlugins.ForEach(plugin => plugin.Dispose());

        /// <summary>
        /// Returns the version numbers of ATS plug-in
        /// </summary>
        /// <returns>Version numbers of ATS plug-in.</returns>
        [DllExport(CallingConvention.StdCall)]
        public static int GetPluginVersion() => Version;

        /// <summary>
        /// Called when the train is loaded
        /// </summary>
        /// <param name="vehicleSpec">Spesifications of vehicle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetVehicleSpec(AtsVehicleSpec vehicleSpec) => TargetPlugins.ForEach(plugin => plugin.SetVehicleSpec(vehicleSpec));

        /// <summary>
        /// Called when the game is started
        /// </summary>
        /// <param name="initialHandlePosition">Initial position of control handle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void Initialize(int initialHandlePosition) => TargetPlugins.ForEach(plugin => plugin.Initialize(initialHandlePosition));

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="vehicleState">Current state of vehicle.</param>
        /// <param name="panel">Current state of panel.</param>
        /// <param name="sound">Current state of sound.</param>
        /// <returns>Driving operations of vehicle.</returns>
        [DllExport(CallingConvention.StdCall)]
        public static AtsHandles Elapse(AtsVehicleState vehicleState, IntPtr panel, IntPtr sound)
        {
            AtsIoArray panelArray = new AtsIoArray(panel);
            AtsIoArray soundArray = new AtsIoArray(sound);

            AtsHandles handles = new AtsHandles() { Power = Power, Brake = Brake, ConstantSpeed = AtsCscInstruction.Continue, Reverser = Reverser };
            TargetPlugins.ForEach(plugin =>
            {
                handles = plugin.Elapse(handles.Brake, handles.Power, handles.Reverser, vehicleState, panelArray, soundArray);
            });

            return handles;
        }

        /// <summary>
        /// Called when the power is changed
        /// </summary>
        /// <param name="handlePosition">Position of traction control handle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetPower(int handlePosition)
        {
            Power = handlePosition;
            TargetPlugins.ForEach(plugin => plugin.SetPower(handlePosition));
        }

        /// <summary>
        /// Called when the brake is changed
        /// </summary>
        /// <param name="handlePosition">Position of brake control handle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetBrake(int handlePosition)
        {
            Brake = handlePosition;
            TargetPlugins.ForEach(plugin => plugin.SetBrake(handlePosition));
        }

        /// <summary>
        /// Called when the reverser is changed
        /// </summary>
        /// <param name="handlePosition">Position of reveerser handle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetReverser(int handlePosition)
        {
            Reverser = handlePosition;
            TargetPlugins.ForEach(plugin => plugin.SetReverser(handlePosition));
        }

        /// <summary>
        /// Called when any ATS key is pressed
        /// </summary>
        /// <param name="keyIndex">Index of key.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void KeyDown(int keyIndex) => TargetPlugins.ForEach(plugin => plugin.KeyDown((AtsKey)keyIndex));

        /// <summary>
        /// Called when any ATS key is released
        /// </summary>
        /// <param name="keyIndex">Index of key.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void KeyUp(int keyIndex) => TargetPlugins.ForEach(plugin => plugin.KeyUp((AtsKey)keyIndex));

        /// <summary>
        /// Called when the horn is used
        /// </summary>
        /// <param name="hornIndex">Type of horn.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void HornBlow(int hornIndex) => TargetPlugins.ForEach(plugin => plugin.HornBlow(hornIndex));

        /// <summary>
        /// Called when the door is opened
        /// </summary>
        [DllExport(CallingConvention.StdCall)]
        public static void DoorOpen() => TargetPlugins.ForEach(plugin => plugin.DoorOpen());

        /// <summary>
        /// Called when the door is closed
        /// </summary>
        [DllExport(CallingConvention.StdCall)]
        public static void DoorClose() => TargetPlugins.ForEach(plugin => plugin.DoorClose());

        /// <summary>
        /// Called when current signal is changed
        /// </summary>
        /// <param name="signalIndex">Index of signal.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetSignal(int signalIndex) => TargetPlugins.ForEach(plugin => plugin.SetSignal(signalIndex));

        /// <summary>
        /// Called when the beacon data is received
        /// </summary>
        /// <param name="beaconData">Received data of beacon.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetBeaconData(AtsBeaconData beaconData) => TargetPlugins.ForEach(plugin => plugin.SetBeaconData(beaconData));
    }
}