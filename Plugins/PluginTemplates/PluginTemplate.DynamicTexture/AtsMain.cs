using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Zbx1425.DXDynamicTexture;

using Automatic9045.DetailManagerNET.PluginHost;

/* 作業を始める前に……
 * 
 * 1. https://github.com/zbx1425/DXDynamicTexture/releases/latest からDXDynamicTextureのパッケージ（DXDynamicTexture.zip）をダウンロードします。
 * 2. ダウンロードしたzipファイルを解凍します。
 * 3. フォルダ内の4つのDLL（Zbx1425.DXDynamicTexture-net35.dll、Zbx1425.DXDynamicTexture-net48.dll、Harmony-net35.dll、Harmony-net48.dll）について、
 *    右クリック→[プロパティ]からセキュリティロックを解除します（「ブロックの解除」または「許可する」チェックボックスにチェック→「OK」または「適用」）。
 * 4. 4つのDLL全てをこのファイル（AtsMain.cs）と同じフォルダ内に配置します。
 * 
 * 
 * Before you begin work:
 * 
 * 1. Download the package of DXDynamicTexture (DXDynamicTexture.zip) from https://github.com/zbx1425/DXDynamicTexture/releases/latest.
 * 2. Unzip the downloaded zip file.
 * 3. For the four DLLs in the folder (Zbx1425.DXDynamicTexture-net35.dll, Zbx1425.DXDynamicTexture-net48.dll, Harmony-net35.dll, Harmony-net48.dll),
 *    right-click -> select [Properties] -> check the "Unblock" checkbox -> "OK" or "Apply" to remove the security lock.
 * 4. Place all four DLLs in the same folder as this file (AtsMain.cs).
 */
namespace $namespace$
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

        public void Initialize(AtsInitialHandlePosition initialHandlePosition)
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
