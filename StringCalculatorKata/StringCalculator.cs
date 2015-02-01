using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return numbers
                .Split(',')
                .Sum(item => item.TryParseOrDefault());
        }
    }
}