using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator_61_;

namespace CalculatorFunctionTest
{
    [TestClass]
    public class CalculatorFunctionTest
    {
        private CalculatorFunction calculator = new CalculatorFunction();
                
        [TestMethod]
        public void CalculateSum()
        {
            Double.TryParse(calculator.Calculate("2", "23", "+"),out double result);
            Assert.AreEqual(result, 25, 0.00001);
        }

        [TestMethod]
        public void CalculateSumFractions()
        {
            Double.TryParse(calculator.Calculate("2,09", "23", "+"), out double result);
            Assert.AreEqual(result, 25.09, 0.00001);
        }

        [TestMethod]
        public void CalculateDifference()
        {
            double temp = 2.09 - 32.123;
            Double.TryParse(calculator.Calculate("2,09", "32,123", "-"), out double result);
            Assert.AreEqual(result, temp, 0.00001);
        }

        [TestMethod]
        public void Multiplication()
        {
            double temp = 2.09 * 32.123;
            Double.TryParse(calculator.Calculate("2,09", "32,123", "*"), out double result);
            Assert.AreEqual(result, temp, 0.00001);
        }

        [TestMethod]
        public void Division()
        {
            double temp = 2.09 / 32.123;
            Double.TryParse(calculator.Calculate("2,09", "32,123", "/"), out double result);
            Assert.AreEqual(result, temp, 0.00001);
        }

        [TestMethod]
        [ExpectedException(typeof(InputErrorException))]
        public void InputErrorException()
        {
            calculator.Calculate("-", "90", "0");
        }

        [TestMethod]
        [ExpectedException(typeof(InputErrorException))]
        public void WrongInputStringException()
        {
            calculator.Calculate("90", "90", "P");
        }

        [TestMethod]
        [ExpectedException(typeof(InputErrorException))]
        public void NullInputStringException()
        {
            calculator.Calculate("", "90", "-");
        }

        [TestMethod]
        [ExpectedException(typeof(Calculator_61_.DivideByZeroException))]
        public void DivideByZeroException()
        {
            calculator.Calculate("90", "0", "/");
        }
    }
}
