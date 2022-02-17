using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Zbx1425.DXDynamicTexture;

using Automatic9045.DetailManagerNET.PluginHost;

// ↓「YourHN」をあなたのハンドルネーム、「YourPluginName」をプラグインの名前に変更します。
// 　Visual Studioの場合はCtrl+R 2回連打から一括で改名できます。
// 　プロジェクトのプロパティ内の名称設定もあわせて変更してください。
namespace YourHN.YourPluginName
{
    public class AtsMain : IAtsPlugin
    {
        static AtsMain() // 静的コンストラクタ。一部のこの中で実行する必要がある処理を除き、基本的にはコンストラクタを使用してください。
        {
#if DEBUG
            MessageBox.Show($"{typeof(AtsMain).Namespace}\n\nデバッグモードで読み込まれました。");
#endif
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolver.Resolve; // DXDynamicTexture、HarmonyのDLLがある場所を登録し、読み込めるようにします。
        }

        public AtsMain() // コンストラクタ。Load()に相当します。
        {
            TextureManager.Initialize();
        }

        public void Dispose()
        {
            TextureManager.Dispose();
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
