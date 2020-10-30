using Xamarin.Forms;

namespace SkiaCheck
{
    internal interface IRenderContext
    {
        Color CheckmarkColor { get; }
        Color FillColor { get; }
        Color OutlineColor { get; }

        float OutlineWidth { get; }
    }
}
