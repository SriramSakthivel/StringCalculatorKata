namespace StringCalculatorKata
{
    public class NumberParseResult
    {
        public NumberParseResult(string rawInput, string input, string[] delimiters)
        {
            RawInput = rawInput;
            Input = input;
            Delimiters = delimiters;
        }

        public string RawInput { get; private set; }
        public string Input { get; private set; }
        public string[] Delimiters { get; private set; }
    }
}