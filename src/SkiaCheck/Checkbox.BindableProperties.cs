using SkiaSharp;
using SkiaSharp.Views.Forms;

using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace SkiaCheck
{
    public sealed partial class Checkbox : SKCanvasView,
        IRenderContext,
        IDisposable
    {
        public static readonly BindableProperty ToggleCommandProperty =
            BindableProperty.Create(
                nameof(ToggleCommand),
                typeof(ICommand),
                typeof(Checkbox),
                null);

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(
                nameof(IsChecked),
                typeof(bool),
                typeof(Checkbox));

        public static readonly BindableProperty CheckmarkColorProperty =
            BindableProperty.Create(
                nameof(CheckmarkColor),
                typeof(Color),
                typeof(Checkbox));

        public static readonly BindableProperty FillColorProperty =
            BindableProperty.Create(
                nameof(FillColor),
                typeof(Color),
                typeof(Checkbox));

        public static readonly BindableProperty OutlineColorProperty =
            BindableProperty.Create(
                nameof(OutlineColor),
                typeof(Color),
                typeof(Checkbox));

        public static readonly BindableProperty OutlineWidthProperty =
            BindableProperty.Create(
                nameof(OutlineWidth),
                typeof(float),
                typeof(Checkbox),
                4.0f);

        public ICommand ToggleCommand
        {
            get => (ICommand)GetValue(ToggleCommandProperty);
            set => SetValue(ToggleCommandProperty, value);
        }

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
    }
}
