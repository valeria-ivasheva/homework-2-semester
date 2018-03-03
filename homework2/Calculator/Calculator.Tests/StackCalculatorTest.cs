using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class StackCalculatorTest
    {
        private StackCalculator calculator;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new StackCalculator("", new Stack());
        }

        [TestMethod]
        public void Sum_2Plus5_7Returned()
        {
            calculator.str = "2 5 +";
            double result = calculator.Calculate();
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void ExpressionWithTwoOperations()
        {
            calculator.str = "2 5 + 7 *";
            double result = calculator.Calculate();
            Assert.AreEqual(49, result);
        }

        [TestMethod]
        public void DivisionByZero()
        {
            calculator.str = "2 0 /";
            double result = calculator.Calculate();
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void ErrorInput()
        {
            calculator.str = "2 + 7 * 1";
            double result = calculator.Calculate();
            Assert.AreEqual(-1, result);
        }
    }
}
