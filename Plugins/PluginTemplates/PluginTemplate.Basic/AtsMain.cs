﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Automatic9045.DetailManagerNET.PluginHost;

namespace $namespace$
{
    public class AtsMain : IAtsPlugin
    {
        static AtsMain() // 静的コンストラクタ。一部のこの中で実行する必要がある処理を除き、基本的にはコンストラクタを使用してください。
        {
#if DEBUG
            MessageBox.Show($"{typeof(AtsMain).Namespace}\n\nデバッグモードで読み込まれました。");
#endif
        }

        public AtsMain() // コンストラクタ。Load()に相当します。
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
