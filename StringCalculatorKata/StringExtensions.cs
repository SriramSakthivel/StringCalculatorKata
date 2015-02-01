namespace StringCalculatorKata
{
    public static class StringExtensions
    {
        public static int TryParseOrDefault(this string number)
        {
            return TryParseOrDefault(number, 0);
        }

        public static int TryParseOrDefault(this string number, int defaultValue)
        {
            int result;
            return int.TryParse(number, out result) ? result : defaultValue;
        }
    }
}