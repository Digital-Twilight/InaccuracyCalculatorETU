using InaccuracyCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecimalUnitTests
{
    [TestClass]
    public class DecimalOperationsUnitTests
    {
        [TestMethod]
        public void Test_SizovaRound_WhenZero_ReturnsZero()
        {
            decimal input = 0m;
            int correct_precision = 0;
            decimal result = DecimalOperations.SizovaRound(input, out bool _, out int out_precision);
            Assert.AreEqual(0m, result);
            Assert.AreEqual(correct_precision, out_precision);
        }

        [TestMethod]
        public void Test_SizovaRound_WhenFirstSignificantDigitIsNotOne_RoundsToFirstSignificantDigit()
        {
            decimal input = 123.456m;
            int correct_precision = 2;
            decimal result = DecimalOperations.SizovaRound(input, out bool _, out int out_precision);
            Assert.AreEqual(120m, result);
            Assert.AreEqual(correct_precision, out_precision);
        }

        [TestMethod]
        public void Test_SizovaRound_WhenFirstSignificantDigitIsOne_RoundsToSecondSignificantDigit()
        {
            decimal input = 101.456m;
            int correct_precision = 2;
            decimal result = DecimalOperations.SizovaRound(input, out bool _, out int out_precision);
            Assert.AreEqual(100m, result);
            Assert.AreEqual(correct_precision, out_precision);
        }

        [TestMethod]
        public void Test_SizovaRound_NegativeNumber_RoundsCorrectly()
        {
            decimal input = -250.678m;
            int correct_precision = 2;
            decimal result = DecimalOperations.SizovaRound(input, out bool _, out int out_precision);
            Assert.AreEqual(-300m, result);
            Assert.AreEqual(correct_precision, out_precision);
        }

        [TestMethod]
        public void Test_SizovaRound_SmallNumber_RoundsCorrectly()
        {
            decimal input = 0.000034m;
            int correct_precision = 5;
            decimal result = DecimalOperations.SizovaRound(input, out bool _, out int out_precision);
            Assert.AreEqual(0.00003m, result);
            Assert.AreEqual(correct_precision, out_precision);
        }

        [TestMethod]
        public void Test_SizovaRound_LargeNumber_RoundsCorrectly()
        {
            decimal input = 9876543210.1234m;
            int correct_precision = 1;
            decimal result = DecimalOperations.SizovaRound(input, out bool _, out int out_precision);
            Assert.AreEqual(10000000000m, result);
            Assert.AreEqual(correct_precision, out_precision);
        }
    }
}
