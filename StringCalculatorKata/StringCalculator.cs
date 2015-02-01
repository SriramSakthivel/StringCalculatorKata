using System;
using System.Linq;

namespace StringCalculatorKata
{
    //"//;\n1;2"
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var numbersParser = new NumbersParser();
            var parseResult = numbersParser.ParseNumbers(numbers);
            return parseResult.Input
                .Split(parseResult.Delimiters, StringSplitOptions.None)
                .Sum(item => item.TryParseOrDefault());
        }
    }
}