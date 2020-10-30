using SkiaSharp;
using SkiaSharp.Views.Forms;

using System;

using Xamarin.Forms;

namespace SkiaCheck
{
    public sealed partial class Checkbox : SKCanvasView,
        IRenderContext,
        IDisposable
    {
        private const double SIZE = 24.0;

        private readonly IPlatformRenderer _platformRenderer;

        private SKPaint _backgroundPaint;
        private SKPaint _checkmarkPaint;
        private SKPaint _outlinePaint;                

        public Checkbox()
        {
            WidthRequest = HeightRequest = SIZE;

            _platformRenderer = GetPlatformRenderer();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs @event)
        {
            base.OnPaintSurface(@event);

            if (IsChecked)
            {
                DrawBackgroundLayer(@event);
                DrawCheckmarkLayer(@event);

                return;
            }                
                
            DrawOutlineLayer(@event);
        }

        private void DrawBackgroundLayer(SKPaintSurfaceEventArgs @event)
        {
            _backgroundPaint = _backgroundPaint ?? CreateBackgroundPaint();
            _backgroundPaint.Color = FillColor.ToSKColor();
            _backgroundPaint.StrokeWidth = OutlineWidth;

            _platformRenderer.DrawBackgroundLayer(
                this,
                @event,
                _backgroundPaint);
        }

        private void DrawCheckmarkLayer(SKPaintSurfaceEventArgs @event)
        {
            _checkmarkPaint = _checkmarkPaint ?? CreateCheckmarkPaint();
            _checkmarkPaint.Color = CheckmarkColor.ToSKColor();
            _checkmarkPaint.StrokeWidth = OutlineWidth;

            _platformRenderer.DrawCheckmarkLayer(
                this,
                @event,
                _checkmarkPaint);
        }

        private void DrawOutlineLayer(SKPaintSurfaceEventArgs @event)
        {
            _outlinePaint = _outlinePaint ?? CreateOutlinePaint();
            _outlinePaint.Color = OutlineColor.ToSKColor();
            _outlinePaint.StrokeWidth = OutlineWidth;

            _platformRenderer.DrawBackgroundLayer(
                this,
                @event,
                _outlinePaint);
        }

        private IPlatformRenderer GetPlatformRenderer()
        {
            if (Device.RuntimePlatform == Device.iOS)
                return new iOS.PlatformRenderer();

            return new Android.PlatformRenderer();
        }

        public void Dispose()
        {
            _backgroundPaint?.Dispose();
            _checkmarkPaint?.Dispose();
            _outlinePaint?.Dispose();
        }
    }
}
