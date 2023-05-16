namespace Utils
{
    public static class PriceUtils
    {
        public static string ToPriceLabelText(this int price)
        {
            return $"{price}$";
        }
    }
}
