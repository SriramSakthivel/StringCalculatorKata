namespace StringCalculatorKata
{
    public class NumbersParser
    {
        const string NewLine = "\n";
        const string CustomDelimiterStart = "//";

        public NumberParseResult ParseNumbers(string numbers)
        {
            string input;
            string[] delimiters;
            if (numbers.StartsWith(CustomDelimiterStart) && numbers.Contains(NewLine))
            {
                int end = numbers.IndexOf(NewLine);
                string customDelimiter = numbers.Substring(CustomDelimiterStart.Length, end - CustomDelimiterStart.Length);

                delimiters = new[] { customDelimiter, NewLine };
                input = numbers.Substring(end + NewLine.Length);
            }
            else
            {
                input = numbers;
                delimiters = new[] { ",", NewLine };
            }

            return new NumberParseResult(numbers, input, delimiters);
        }
    }
}