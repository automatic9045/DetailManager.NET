using System;
using System.Runtime.InteropServices;

namespace Automatic9045.CSharpAtsPluginWrapper.PluginHost
{
    /// <summary>
    /// ATS Keys
    /// </summary>
    public enum AtsKey
    {
        S = 0,          // S Key
        A1,             // A1 Key
        A2,             // A2 Key
        B1,             // B1 Key
        B2,             // B2 Key
        C1,             // C1 Key
        C2,             // C2 Key
        D,              // D Key
        E,              // E Key
        F,              // F Key
        G,              // G Key
        H,              // H Key
        I,              // I Key
        J,              // J Key
        K,              // K Key
        L               // L Key
    }

    /// <summary>
    /// Initial Position of Handle
    /// </summary>
    public enum AtsInitialHandlePosition
    {
        ServiceBrake = 0,   // Service Brake
        EmergencyBrake,     // Emergency Brake
        Removed             // Handle Removed
    }

    /// <summary>
    /// Sound Control Instruction
    /// </summary>
    public static class AtsSoundControlInstruction
    {
        public const int Stop = -10000;     // Stop
        public const int Play = 1;          // Play Once
        public const int PlayLooping = 0;   // Play Repeatedly
        public const int Continue = 2;      // Continue
    }

    /// <summary>
    /// Type of Horn
    /// </summary>
    public enum AtsHornType
    {
        Primary = 0,    // Horn 1
        Secondary,      // Horn 2
        Music           // Music Horn
    }

    /// <summary>
    /// Constant Speed Control Instruction
    /// </summary>
    public static class AtsCscInstruction
    {
        public const int Continue = 0;       // Continue
        public const int Enable = 1;         // Enable
        public const int Disable = 2;        // Disable
    }

    /// <summary>
    /// Vehicle Specification
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AtsVehicleSpec
    {
        public int BrakeNotches;   // Number of Brake Notches
        public int PowerNotches;   // Number of Power Notches
        public int AtsNotch;       // ATS Cancel Notch
        public int B67Notch;       // 80% Brake (67 degree)
        public int Cars;           // Number of Cars
    };

    /// <summary>
    /// State Quantity of Vehicle
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AtsVehicleState
    {
        public double Location;    // Train Position (Z-axis) (m)
        public float Speed;        // Train Speed (km/h)
        public int Time;           // Time (ms)
        public float BcPressure;   // Pressure of Brake Cylinder (Pa)
        public float MrPressure;   // Pressure of MR (Pa)
        public float ErPressure;   // Pressure of ER (Pa)
        public float BpPressure;   // Pressure of BP (Pa)
        public float SapPressure;  // Pressure of SAP (Pa)
        public float Current;      // Current (A)
    };

    /// <summary>
    /// Received Data from Beacon
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AtsBeaconData
    {
        public int Type;       // Type of Beacon
        public int Signal;     // Signal of Connected Section
        public float Distance; // Distance to Connected Section (m)
        public int Optional;   // Optional Data
    };

    /// <summary>
    /// Train Operation Instruction
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AtsHandles
    {
        public int Brake;               // Brake Notch
        public int Power;               // Power Notch
        public int Reverser;            // Reverser Position
        public int ConstantSpeed;       // Constant Speed Control
    };
}