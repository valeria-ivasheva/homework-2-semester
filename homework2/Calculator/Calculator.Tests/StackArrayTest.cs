using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class StackArrayTest
    {
        private StackArray stack;
        const double delta = 0.0001;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackArray();
        }

        [TestMethod]
        public void PushArrayStackTest()
        {
            stack.Push(1.4);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void PopArrayStackTest()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop(), delta);
        }

        [TestMethod]
        public void TwoElementsPopArrayStackTest()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop(), delta);
            Assert.AreEqual(1, stack.Pop(), delta);
        }

        [TestMethod]
        public void PopFromEmptyStackArrayTest()
        {
            stack.Pop();
        }

        [TestMethod]
        public void ArrayOverflow()
        {
            for (int i = 0; i < 101; i++)
            {
                stack.Push(1);
            }
        }
    }
}
