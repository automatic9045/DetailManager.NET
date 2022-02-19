using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.PluginHost;

namespace Automatic9045.SampleCSharpAtsPlugins.Alert
{
    /// <summary>
    /// Initialize メソッドが呼び出された時 (シナリオが開始された時)、シナリオ開始から 10 秒経過した時にダイアログを表示するサンプルです。
    /// </summary>
    public class AtsMain : IAtsPlugin
    {
        private DateTime StartDateTime = new DateTime(3000, 1, 1);
        private bool HasAlerted = false;

        static AtsMain()
        {
#if DEBUG
            MessageBox.Show($"{typeof(AtsMain).Namespace}\n\nデバッグモードで読み込まれました。");
#endif
        }

        public AtsMain()
        {
        }

        public void Dispose()
        {
        }

        public void SetVehicleSpec(AtsVehicleSpec vehicleSpec)
        {
        }

        public void Initialize(AtsInitialHandlePosition initialHandlePosition)
        {
            MessageBox.Show("Initialize メソッドが呼び出されました。", "SamplePlugin.Alert");
            StartDateTime = DateTime.Now;
        }

        public AtsHandles Elapse(int brake, int power, int reverser, AtsVehicleState vehicleState, AtsIoArray panel, AtsIoArray sound)
        {
            if (!HasAlerted && DateTime.Now - StartDateTime > new TimeSpan(0, 0, 10))
            {
                HasAlerted = true;
                MessageBox.Show("シナリオが開始されてから 10 秒が経過しました。", "SamplePlugin.Alert");
            }

            return new AtsHandles()
            {
                Brake = brake,
                Power = power,
                Reverser = reverser,
                ConstantSpeed = AtsCscInstruction.Continue,
            };
        }

        public void SetPower(int handlePosition)
        {
        }

        public void SetBrake(int handlePosition)
        {
        }

        public void SetReverser(int handlePosition)
        {
        }

        public void KeyDown(AtsKey keyIndex)
        {
        }

        public void KeyUp(AtsKey keyIndex)
        {
        }

        public void HornBlow(AtsHornType hornIndex)
        {
        }

        public void DoorOpen()
        {
        }

        public void DoorClose()
        {
        }

        public void SetSignal(int signalIndex)
        {
        }

        public void SetBeaconData(AtsBeaconData beaconData)
        {
        }
    }
}
