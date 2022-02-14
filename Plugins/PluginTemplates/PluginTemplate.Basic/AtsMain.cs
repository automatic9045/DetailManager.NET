using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Automatic9045.CSharpAtsPluginWrapper.PluginHost;

// ↓「YourHN」をあなたのハンドルネーム、「YourPluginName」をプラグインの名前に変更します。
// 　Visual Studioの場合はCtrl+R 2回連打から一括で改名できます。
// 　プロジェクトのプロパティ内の名称設定もあわせて変更してください。
namespace YourHN.YourPluginName
{
    public class AtsMain : IAtsPlugin
    {
        public AtsMain() // コンストラクタ。Load()に相当します。
        {
        }

        public void Dispose()
        {
        }

        public void SetVehicleSpec(AtsVehicleSpec vehicleSpec)
        {
        }

        public void Initialize(int initialHandlePosition)
        {
        }

        public AtsHandles Elapse(int brake, int power, int reverser, AtsVehicleState vehicleState, AtsIoArray panel, AtsIoArray sound)
        {
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

        public void HornBlow(int hornIndex)
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
