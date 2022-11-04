namespace ECommerce.Infrastructure.Common
{
    public static class Calculate
    {
        public static string Discount(double ActualPrice, double DiscountedPrice)
        {
            double result = (DiscountedPrice * 100) / ActualPrice;
            double discount = (double)System.Math.Round(result, 2);
            return discount.ToString() + "%";
        }
    }
}
