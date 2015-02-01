using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return numbers
                .Split(',', '\n')
                .Sum(item => item.TryParseOrDefault());
        }
    }
}