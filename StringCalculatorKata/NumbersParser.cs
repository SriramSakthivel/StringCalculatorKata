using System.Linq;
using System.Text.RegularExpressions;

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
                delimiters = ExtractDelimiters(customDelimiter);
                input = numbers.Substring(end + NewLine.Length);
            }
            else
            {
                input = numbers;
                delimiters = new[] { ",", NewLine };
            }

            return new NumberParseResult(numbers, input, delimiters);
        }

        private static string[] ExtractDelimiters(string customDelimiter)
        {
            string[] delimiters;
            var matches = Regex.Matches(customDelimiter, @"\[(?<cm>[^\]]*)\]");
            if (matches.Count > 0)
            {
                delimiters = matches.Cast<Match>()
                    .Select(x => x.Groups["cm"].Value)
                    .Concat(new[] { NewLine })
                    .ToArray();
            }
            else
            {
                delimiters = new[] { customDelimiter, NewLine };
            }
            return delimiters;
        }
    }
}