using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaCheck.iOS
{
    internal class PlatformRenderer : IPlatformRenderer
    {
        public void DrawBackgroundLayer(
            IRenderContext context,
            SKPaintSurfaceEventArgs @event,
            SKPaint paint)
        {
            var width = @event.Info.Width;
            var height = @event.Info.Height;

            @event.Surface?.Canvas?.DrawCircle(
                width / 2,
                height / 2, 
                (width / 2) - (context.OutlineWidth / 2), 
                paint);
        }

        public void DrawCheckmarkLayer(
            IRenderContext context,
            SKPaintSurfaceEventArgs @event,
            SKPaint paint)
        {
            var path = new SKPath();
            var width = @event.Info.Width;
            var height = @event.Info.Height;

            path.MoveTo(.2f * width, .5f * height);
            path.LineTo(.375f * width, .675f * height);
            path.LineTo(.75f * width, .3f * height);

            @event.Surface?.Canvas.DrawPath(
                path,
                paint);
        }
    }
}
