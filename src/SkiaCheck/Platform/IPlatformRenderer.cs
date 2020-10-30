using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaCheck
{
    interface IPlatformRenderer
    {
        void DrawBackgroundLayer(
            IRenderContext context,
            SKPaintSurfaceEventArgs @event,
            SKPaint paint);

        void DrawCheckmarkLayer(
            IRenderContext context,
            SKPaintSurfaceEventArgs @event,
            SKPaint paint);
    }
}
