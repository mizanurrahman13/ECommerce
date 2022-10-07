namespace ECommerce.Infrastructure.Common
{
    public static class DynamicSize
    {
        public static (double width, double height) GetImageSize
            (double w1, double h1, double w2, double h2)
        {
            //in here
            //h1 -> main image height
            //w1 -> main image width
            //h2 -> given height
            //w2 -> given width
            //-------------
            //height -> result (Height)
            //width -> result (Width)

            double mainImageRatio = (h1 / w1) > 1 ? (double)(h1 / w1) : (double)(w1 / h1);
            double ImageRatio = (h2 / w2) > 1 ? (double)(h2 / w2) : (double)(w2 / h2);

            double minSide = Math.Min(w2, h2);//minSide assumed as height--- y-axis
            double maxSide = Math.Max(w2, h2);//maxSize assumed as Width--- x-axis
            double width = 0;
            double height = 0;
            if (w2 <= 0 && h2 <= 0)//base case for returning actualSize
            {
                return (w1, h1);
            }
            else if (mainImageRatio == 1.00)//square image
            {
                height = minSide;
                width = minSide;
            }
            else //rectangle image
            {
                if (mainImageRatio != ImageRatio)//ratio not matched
                {
                    if (w1 >= h1)//landscape
                    {
                        width = minSide * mainImageRatio;
                        height = minSide;
                    }
                    else //portrait
                    {
                        width = minSide;
                        height = minSide * mainImageRatio;
                    }
                }
                else// ratio matched
                {
                    height = h2 * mainImageRatio;
                    width = w2 * mainImageRatio;
                }
            }
            return (width, height);
        }
    }
}
