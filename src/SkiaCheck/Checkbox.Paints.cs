using SkiaSharp;
using SkiaSharp.Views.Forms;

using System;

namespace SkiaCheck
{
    public sealed partial class Checkbox : SKCanvasView,
        IRenderContext,
        IDisposable
    {
        private SKPaint CreateBackgroundPaint()
        {
            return new SKPaint
            {
                Style = SKPaintStyle.Fill,
                StrokeWidth = OutlineWidth,
                StrokeJoin = SKStrokeJoin.Round,
                IsAntialias = true
            };
        }

        private SKPaint CreateCheckmarkPaint()
        {
            return new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = OutlineWidth,
                IsAntialias = true,
                StrokeCap = SKStrokeCap.Butt
            };
        }

        private SKPaint CreateOutlinePaint()
        {
            return new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = OutlineWidth,
                StrokeJoin = SKStrokeJoin.Round,
                IsAntialias = true
            };
        }
    }
}
