using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.PluginHost;

namespace Automatic9045.SampleCSharpAtsPlugins.SimpleAts
{
    /// <summary>
    /// 100km/h を超過すると常用最大ブレーキで 95km/h まで減速する、簡易的な保安装置のサンプルです。<br/>
    /// ATS 警報ベルは ATS0、ATS 警報持続音は ATS1 を使用します。また、減速中は ATS255 のパネルを表示します。
    /// </summary>
    public class AtsMain : IAtsPlugin
    {
        private AtsVehicleSpec VehicleSpec;
        private bool IsFirstTime = true;
        private bool IsAutoBraking = false;
        private bool IsButtonSPressing = false;

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
            VehicleSpec = vehicleSpec;
        }

        public void Initialize(AtsInitialHandlePosition initialHandlePosition)
        {
        }

        public AtsHandles Elapse(int brake, int power, int reverser, AtsVehicleState vehicleState, AtsIoArray panel, AtsIoArray sound)
        {
            if (IsFirstTime)
            {
                IsFirstTime = false;
                sound[0] = AtsSoundControlInstruction.Stop;
                sound[1] = AtsSoundControlInstruction.Stop;
            }

            if (vehicleState.Speed > 100)
            {
                if (!IsAutoBraking)
                {
                    IsAutoBraking = true;
                    sound[0] = AtsSoundControlInstruction.PlayLooping;
                    sound[1] = AtsSoundControlInstruction.Stop;
                    panel[255] = 1;
                }
            }
            else if (vehicleState.Speed < 95)
            {
                if (IsAutoBraking)
                {
                    IsAutoBraking = false;
                    sound[0] = AtsSoundControlInstruction.Stop;
                    sound[1] = AtsSoundControlInstruction.PlayLooping;
                    panel[255] = 0;
                }
            }

            if (IsAutoBraking)
            {
                return new AtsHandles()
                {
                    Brake = VehicleSpec.BrakeNotches,
                    Power = 0,
                    Reverser = reverser,
                    ConstantSpeed = AtsCscInstruction.Disable,
                };
            }
            else
            {
                if (IsButtonSPressing)
                {
                    sound[1] = AtsSoundControlInstruction.Stop;
                }

                return new AtsHandles()
                {
                    Brake = brake,
                    Power = power,
                    Reverser = reverser,
                    ConstantSpeed = AtsCscInstruction.Continue,
                };
            }
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
            if (keyIndex == AtsKey.S)
            {
                IsButtonSPressing = true;
            }
        }

        public void KeyUp(AtsKey keyIndex)
        {
            if (keyIndex == AtsKey.S)
            {
                IsButtonSPressing = false;
            }
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
