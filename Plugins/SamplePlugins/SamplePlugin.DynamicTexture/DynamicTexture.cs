using System;

using Zbx1425.DXDynamicTexture;

namespace Automatic9045.SampleCSharpAtsPlugins.DynamicTexture
{
    public class DynamicTexture : IDisposable
    {
        public TextureHandle Handle { get; }
        public GDIHelper GDIHelper { get; }

        public int Width => Handle.Width;
        public int Height => Handle.Height;

        public static DynamicTexture Create(string targetFileNameEnding, int width, int height)
        {
            TextureHandle textureHandle = TextureManager.Register(targetFileNameEnding, width, height);
            GDIHelper gdiHelper = new GDIHelper(width, height);

            return new DynamicTexture(textureHandle, gdiHelper);
        }

        public DynamicTexture(TextureHandle textureHandle, GDIHelper gdiHelper)
        {
            Handle = textureHandle;
            GDIHelper = gdiHelper;
        }

        public void Dispose()
        {
            Handle.Dispose();
            GDIHelper.Dispose();
        }

        public void DrawWithGDI(Action<GDIHelper> gdiDrawAction)
        {
            GDIHelper.BeginGDI();
            gdiDrawAction(GDIHelper);
            GDIHelper.EndGDI();
        }

        public void Update() => Handle.Update(GDIHelper);
    }
}
