using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Automatic9045.CSharpAtsPluginWrapper.PluginHost;

namespace Automatic9045.CSharpAtsPluginWrapper
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
            string baseDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                if (e.Name.Contains("CSharpPluginHost"))
                {
                    return Assembly.LoadFile(Path.Combine(baseDirectory, "CSharpPluginHost.dll"));
                }
                else
                {
                    return null;
                }
            };
        }

        private static IAtsPlugin TargetPlugin;

        private static int Brake;
        private static int Power;
        private static int Reverser;

        /// <summary>
        /// Called when this plug-in is loaded
        /// </summary>
        [DllExport(CallingConvention.StdCall)]
        public static void Load()
        {
#if DEBUG
            MessageBox.Show($"CSharpAtsPluginWrapper\nCopyright © 2022 Automatic9045\n\nデバッグモードで読み込まれました。");
#endif
            TargetPlugin = PluginLoader.Load();
        }

        /// <summary>
        /// Called when this plug-in is unloaded
        /// </summary>
        [DllExport(CallingConvention.StdCall)]
        public static void Dispose() => TargetPlugin?.Dispose();

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
        public static void SetVehicleSpec(AtsVehicleSpec vehicleSpec) => TargetPlugin?.SetVehicleSpec(vehicleSpec);

        /// <summary>
        /// Called when the game is started
        /// </summary>
        /// <param name="initialHandlePosition">Initial position of control handle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void Initialize(int initialHandlePosition) => TargetPlugin?.Initialize(initialHandlePosition);

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

            if (TargetPlugin is null)
            {
                return new AtsHandles() { Power = 0, Brake = 0, ConstantSpeed = AtsCscInstruction.Continue, Reverser = 0 };
            }
            else
            {
                return TargetPlugin.Elapse(Brake, Power, Reverser, vehicleState, panelArray, soundArray);
            }
        }

        /// <summary>
        /// Called when the power is changed
        /// </summary>
        /// <param name="handlePosition">Position of traction control handle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetPower(int handlePosition)
        {
            Power = handlePosition;
            TargetPlugin?.SetPower(handlePosition);
        }

        /// <summary>
        /// Called when the brake is changed
        /// </summary>
        /// <param name="handlePosition">Position of brake control handle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetBrake(int handlePosition)
        {
            Brake = handlePosition;
            TargetPlugin?.SetBrake(handlePosition);
        }

        /// <summary>
        /// Called when the reverser is changed
        /// </summary>
        /// <param name="handlePosition">Position of reveerser handle.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetReverser(int handlePosition)
        {
            Reverser = handlePosition;
            TargetPlugin?.SetReverser(handlePosition);
        }

        /// <summary>
        /// Called when any ATS key is pressed
        /// </summary>
        /// <param name="keyIndex">Index of key.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void KeyDown(int keyIndex) => TargetPlugin?.KeyDown((AtsKey)keyIndex);

        /// <summary>
        /// Called when any ATS key is released
        /// </summary>
        /// <param name="keyIndex">Index of key.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void KeyUp(int keyIndex) => TargetPlugin?.KeyUp((AtsKey)keyIndex);

        /// <summary>
        /// Called when the horn is used
        /// </summary>
        /// <param name="hornIndex">Type of horn.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void HornBlow(int hornIndex) => TargetPlugin?.HornBlow(hornIndex);

        /// <summary>
        /// Called when the door is opened
        /// </summary>
        [DllExport(CallingConvention.StdCall)]
        public static void DoorOpen() => TargetPlugin?.DoorOpen();

        /// <summary>
        /// Called when the door is closed
        /// </summary>
        [DllExport(CallingConvention.StdCall)]
        public static void DoorClose() => TargetPlugin?.DoorClose();

        /// <summary>
        /// Called when current signal is changed
        /// </summary>
        /// <param name="signalIndex">Index of signal.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetSignal(int signalIndex) => TargetPlugin?.SetSignal(signalIndex);

        /// <summary>
        /// Called when the beacon data is received
        /// </summary>
        /// <param name="beaconData">Received data of beacon.</param>
        [DllExport(CallingConvention.StdCall)]
        public static void SetBeaconData(AtsBeaconData beaconData) => TargetPlugin?.SetBeaconData(beaconData);
    }
}