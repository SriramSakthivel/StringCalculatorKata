using System;
using System.Linq;

namespace StringCalculatorKata
{
    //"//;\n1;2"
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            const string newLine = "\n";
            const string customDelimiterStart = "//";

            string input;
            string[] delimiters;
            if (numbers.StartsWith(customDelimiterStart) && numbers.Contains(newLine))
            {
                int end = numbers.IndexOf(newLine);
                string customDelimiter = numbers.Substring(2, end - 2);

                delimiters = new[] { customDelimiter, newLine };
                input = numbers.Substring(end + newLine.Length);
            }
            else
            {
                input = numbers;
                delimiters = new[] { ",", newLine };
            }

            return input
                .Split(delimiters, StringSplitOptions.None)
                .Sum(item => item.TryParseOrDefault());
        }
    }
}