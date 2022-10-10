using SixLabors.ImageSharp;

namespace ECommerce.Infrastructure.Common
{
    public interface IImageResizer
    {
        string ImageResize(Image img, int MaxWidth, int MaxHeight);
    }
}
