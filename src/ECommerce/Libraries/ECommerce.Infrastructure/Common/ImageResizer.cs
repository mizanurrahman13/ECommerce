using SixLabors.ImageSharp;

namespace ECommerce.Infrastructure.Common
{
    public class ImageResizer : IImageResizer
    {
        public string ImageResize(Image img, int MaxWidth, int MaxHeight)
        {
            if (img.Height > MaxHeight || img.Width > MaxWidth)
            {
                double heightRatio = (double)img.Height / (double)MaxHeight;
                double widthRatio = (double)img.Width / (double)MaxWidth;

                double ratio = Math.Max(heightRatio, widthRatio);

                int newHeight = (int)(img.Height / ratio);
                int newWidth = (int)(img.Width / ratio);

                return newHeight.ToString() + "," + newWidth.ToString();
            }
            else
            {
                return img.Height.ToString() + "," + img.Width.ToString();
            }
        }
    }
}
