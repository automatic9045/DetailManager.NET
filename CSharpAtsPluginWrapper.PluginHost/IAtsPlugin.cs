using System;

namespace Automatic9045.CSharpAtsPluginWrapper.PluginHost
{
    public interface IAtsPlugin : IDisposable
    {
        void SetVehicleSpec(AtsVehicleSpec vehicleSpec);

        void Initialize(int initialHandlePosition);

        AtsHandles Elapse(int brake, int power, int reverser, AtsVehicleState vehicleState, AtsIoArray panel, AtsIoArray sound);

        void SetPower(int handlePosition);

        void SetBrake(int handlePosition);

        void SetReverser(int handlePosition);

        void KeyDown(AtsKey keyIndex);

        void KeyUp(AtsKey keyIndex);

        void HornBlow(int hornIndex);

        void DoorOpen();

        void DoorClose();

        void SetSignal(int signalIndex);

        void SetBeaconData(AtsBeaconData beaconData);
    }
}
