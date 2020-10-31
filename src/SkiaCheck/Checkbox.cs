using SkiaSharp;
using SkiaSharp.Views.Forms;

using System;

using Xamarin.Forms;

namespace SkiaCheck
{
    public class Checkbox : SKCanvasView,
        IRenderContext,
        IDisposable
    {
        private SKPaint _backgroundPaint;
        private SKPaint _checkmarkPaint;
        private SKPaint _outlinePaint;

        private readonly IPlatformRenderer _platformRenderer;

        private readonly TapGestureRecognizer _tapRecognizer;

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(
                nameof(IsChecked),
                typeof(bool),
                typeof(Checkbox),
                propertyChanged: OnVisualRelevantPropertyChanged);

        public static readonly BindableProperty CheckmarkColorProperty =
            BindableProperty.Create(
                nameof(CheckmarkColor),
                typeof(Color),
                typeof(Checkbox),
                propertyChanged: OnVisualRelevantPropertyChanged);

        public static readonly BindableProperty FillColorProperty =
            BindableProperty.Create(
                nameof(FillColor),
                typeof(Color),
                typeof(Checkbox),
                propertyChanged: OnVisualRelevantPropertyChanged);

        public static readonly BindableProperty OutlineColorProperty =
            BindableProperty.Create(
                nameof(OutlineColor),
                typeof(Color),
                typeof(Checkbox),
                propertyChanged: OnVisualRelevantPropertyChanged);

        public static readonly BindableProperty OutlineWidthProperty =
            BindableProperty.Create(
                nameof(OutlineWidth),
                typeof(float),
                typeof(Checkbox),
                4.0f,
                propertyChanged: OnVisualRelevantPropertyChanged);



        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public Color CheckmarkColor
        {
            get => (Color)GetValue(CheckmarkColorProperty);
            set => SetValue(CheckmarkColorProperty, value);
        }

        public Color FillColor
        {
            get => (Color)GetValue(FillColorProperty);
            set => SetValue(FillColorProperty, value);
        }

        public Color OutlineColor
        {
            get => (Color)GetValue(OutlineColorProperty);
            set => SetValue(OutlineColorProperty, value);
        }

        public float OutlineWidth
        {
            get => (float)GetValue(OutlineWidthProperty);
            set => SetValue(OutlineWidthProperty, value);
        }


        public Checkbox()
        {
            WidthRequest = 24;
            HeightRequest = 24;

            _platformRenderer = GetPlatformRenderer();

            _tapRecognizer = new TapGestureRecognizer
            {
                Command = new Command(() =>
                    IsChecked = !IsChecked)
            };

            GestureRecognizers.Add(_tapRecognizer);
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs @event)
        {
            base.OnPaintSurface(@event);

            @event.Surface.Canvas.Clear();

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

        private static void OnVisualRelevantPropertyChanged(
            BindableObject bindable,
            object oldValue,
            object newValue)
        {
            if (bindable is Checkbox @this && oldValue != newValue)
            {
                @this.InvalidateSurface();
            }
        }

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

        public void Dispose()
        {
            _backgroundPaint?.Dispose();
            _checkmarkPaint?.Dispose();
            _outlinePaint?.Dispose();

            GestureRecognizers?.Clear();
        }
    }
}
