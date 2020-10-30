using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaCheck.Android
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

            @event.Surface?.Canvas?.DrawRect(
                context.OutlineWidth,
                context.OutlineWidth,
                width - (context.OutlineWidth * 2),
                height - (context.OutlineWidth * 2),
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
            path.LineTo(.425f * width, .7f * height);
            path.LineTo(.8f * width, .275f * height);

            @event.Surface?.Canvas.DrawPath(
                path,
                paint);
        }
    }
}
