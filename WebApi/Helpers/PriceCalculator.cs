namespace WebApi.Helpers
{
    public static class PriceCalculator
    {
        public static double CalculatePrice(double popularityScore, double weight, double goldPrice)
        {
            return Math.Round((popularityScore + 1) * weight * goldPrice, 2);
        }

        public static double ConvertPopularityToFiveScale(double score)
        {
            return Math.Round(score * 5, 1);
        }
    }
}
