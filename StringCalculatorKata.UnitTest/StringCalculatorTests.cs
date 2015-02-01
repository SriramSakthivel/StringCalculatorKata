using NUnit.Framework;

namespace StringCalculatorKata.UnitTest
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        [TestCase("", 0), TestCase("1", 1), TestCase("1,2", 3)]
        public void Add_Should_AddNumbersAndReturnExpectedResult(string numbers, int expected)
        {
            StringCalculator sut = new StringCalculator();

            int result = sut.Add(numbers);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
