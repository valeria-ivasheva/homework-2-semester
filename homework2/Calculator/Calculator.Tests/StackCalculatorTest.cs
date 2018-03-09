using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class StackCalculatorTest
    {
        private StackCalculator calculator;
        const double delta = 0.0001;

        [TestMethod]
        public void Sum_2Plus5_7Returned()
        {
            calculator = new StackCalculator("2 5 +", new Stack());
            double result = calculator.Calculate();
            Assert.AreEqual(7, result, delta);
        }

        [TestMethod]
        public void ExpressionWithTwoOperations()
        {
            calculator = new StackCalculator("2 5 + 7 *", new Stack());
            double result = calculator.Calculate();
            Assert.AreEqual(49, result, delta);
        }

        [TestMethod]
        public void DivisionByZero()
        {
            calculator = new StackCalculator("2 / 0", new Stack());
            double result = calculator.Calculate();
            Assert.AreEqual(-1, result, delta);
        }

        [TestMethod]
        public void ErrorInput()
        {
            calculator = new StackCalculator("2 + 7 * 1", new Stack());
            double result = calculator.Calculate();
            Assert.AreEqual(-1, result, delta);
        }
    }
}
