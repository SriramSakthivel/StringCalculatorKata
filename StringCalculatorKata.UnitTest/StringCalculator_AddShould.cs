using NUnit.Framework;

namespace StringCalculatorKata.UnitTest
{
    [TestFixture]
    public class StringCalculator_AddShould
    {
        [Test]
        public void ReturnZero_GivenEmptyString()
        {
            StringCalculator sut = new StringCalculator();

            int result = sut.Add("");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase("1", 1), TestCase("1,2", 3),
        TestCase("1,2,3,4", 10)]
        public void AddNumbers_GivenCommaSeparatedStrings(string numbers, int expected)
        {
            StringCalculator sut = new StringCalculator();

            int result = sut.Add(numbers);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("1\n2,3", 6)]
        public void AddNumbers_GivenNewLineSeparatedStrings(string numbers, int expected)
        {
            StringCalculator sut = new StringCalculator();

            int result = sut.Add(numbers);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("//;\n1;2", 3), TestCase("//***\n1***2", 3)]
        public void AddNumbers_GivenCustomDelimiterSeparatedStrings(string numbers, int expected)
        {
            StringCalculator sut = new StringCalculator();

            int result = sut.Add(numbers);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("1\n2,-3", "-3"), TestCase("1\n-2,-1", "-2,-1")]
        public void ThrowException_GivenNegativeNumbers(string numbers, string expectedError)
        {
            StringCalculator sut = new StringCalculator();

            TestDelegate code = () => sut.Add(numbers);
            Assert.That(code, Throws.ArgumentException.With.Message.ContainsSubstring(expectedError));
        }

        [Test]
        [TestCase("1\n2,3000,6,1001", 9), TestCase("1\n2,3000,6,1001,1000", 1009)]
        public void IgnoreNumbersGreaterThan1000(string numbers, int expected)
        {
            StringCalculator sut = new StringCalculator();

            int result = sut.Add(numbers);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("//[;][&]\n1&2;8", 11), TestCase("//[*#][&%]\n1*#2&%3", 6)]
        public void AddNumbers_GivenMultipleCustomDelimiterSeparatedStrings(string numbers, int expected)
        {
            StringCalculator sut = new StringCalculator();

            int result = sut.Add(numbers);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
