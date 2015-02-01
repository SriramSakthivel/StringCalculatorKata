using System;
using System.Collections.Generic;
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

            var numbersList = parseResult.Input
                .Split(parseResult.Delimiters, StringSplitOptions.None)
                .Select(item => item.TryParseOrDefault())
                .ToList();

            ThrowIfAnyNegative(numbersList);

            return numbersList.Sum();
        }

        private static void ThrowIfAnyNegative(List<int> numbersList)
        {
            if (numbersList.Any(x => x < 0))
            {
                string negativeNumbers = string.Join(",", numbersList.Where(x => x < 0));
                string errorMessage = string.Format("Negative numbers not allowed[{0}]", negativeNumbers);
                throw new ArgumentException(errorMessage, "numbers");
            }
        }
    }
}