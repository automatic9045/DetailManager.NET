using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Zbx1425.DXDynamicTexture;

using Automatic9045.DetailManagerNET.PluginHost;

namespace Automatic9045.SampleCSharpAtsPlugins.DynamicTexture
{
    public class AtsMain : IAtsPlugin
    {
        private DynamicTexture Texture;
        private Random Random;

        static AtsMain()
        {
#if DEBUG
            MessageBox.Show($"{typeof(AtsMain).Namespace}\n\nデバッグモードで読み込まれました。");
#endif
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolver.Resolve;
        }

        public AtsMain()
        {
            TextureManager.Initialize();

            Texture = DynamicTexture.Create(@"_DummyTrain\Panel\Rainbow.tex.png", 256, 128);
            Random = new Random();
        }

        public void Dispose()
        {
            Texture?.Dispose();
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
            if (Texture.Handle.IsCreated)
            {
                if (Texture.Handle.HasEnoughTimePassed(2))
                {
                    Texture.DrawWithGDI(gdi =>
                    {
                        int rgb = Random.Next(0xffffff);
                        int argb = (int)(0xff000000 | rgb);
                        gdi.FillRectWH(Color.FromArgb(argb), 0, 0, Texture.Width, Texture.Height);
                    });

                    Texture.GDIHelper.Graphics.DrawString("SamplePlugin.\nDynamicTexture", new Font("Arial", 24), Brushes.White, 12, 24);

                    Texture.Update();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"a");
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
