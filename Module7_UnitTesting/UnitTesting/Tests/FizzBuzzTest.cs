using FizzBuzzKata;
using NUnit.Framework;

namespace Tests
{
    internal class FizzBuzzTest
    {
        [TestCase(1, "1")]
        [TestCase(16, "16")]
        [TestCase(98, "98")]
        public void CheckForFizzBuzz_PassedAndActualNumbers_AreEqual(int num, string expected)
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();
            // Act
            var actual = fizzBuzz.CheckForFizzBuzz(num);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(12)]
        [TestCase(81)]
        [TestCase(99)]
        public void CheckForFizzBuzz_FizzNumbers_DisplaysFizz(int num)
        {
            var fizzBuzz = new FizzBuzz();
            var expected = "Fizz";
            var actual = fizzBuzz.CheckForFizzBuzz(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5)]
        [TestCase(25)]
        [TestCase(100)]
        public void CheckForFizzBuzz_BuzzNumbers_DisplaysBuzz(int num)
        {
            var fizzBuzz = new FizzBuzz();
            var expected = "Buzz";
            var actual = fizzBuzz.CheckForFizzBuzz(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(45)]
        [TestCase(75)]
        [TestCase(90)]
        public void CheckForFizzBuzz_FizzBuzzNumbers_DisplaysFizzBuzz(int num)
        {
            var fizzBuzz = new FizzBuzz();
            var expected = "FizzBuzz";
            var actual = fizzBuzz.CheckForFizzBuzz(num);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        [TestCase(-15)]
        [TestCase(101)]
        public void CheckForFizzBuzz_InvalidArgument_ThrowsException(int num)
        {
            var fizzBuzz = new FizzBuzz();
            Assert.That(() => fizzBuzz.CheckForFizzBuzz(num), Throws.InvalidOperationException);
        }
    }
}
