using Hm41;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hm41Test
{
    [TestClass]
    public class ParsTreeTest
    {
        [TestMethod]
        public void ElementaryExpression()
        {
            var tree = new ParseTree("(+ 23 9 )");
            int result = tree.ResultArithmetic();
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void ElementaryWithLeftExpression()
        {
            var tree = new ParseTree("(- (+ 23 9 ) 2 )");
            int result = tree.ResultArithmetic();
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void ElementaryWithRightExpression()
        {
            var tree = new ParseTree("(- 2 (+ 23 9 ) )");
            int result = tree.ResultArithmetic();
            Assert.AreEqual(-30, result);
        }

        [TestMethod]
        public void DoubleExpression()
        {
            var tree = new ParseTree("(- (+ 23 9 ) (- 3 1 ) )");
            int result = tree.ResultArithmetic();
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InputErrorException))]
        public void LoseOpeningBracketsException()
        {
            var tree = new ParseTree("+ 23 9 )");

        }

        [TestMethod]
        [ExpectedException(typeof(InputErrorException))]
        public void LoseClosingBracketsException()
        {
            var tree = new ParseTree("(+ 23 (- 21 9 ) ");
        }

        [TestMethod]
        [ExpectedException(typeof(InputErrorException))]
        public void ErrorInputException()
        {
            var tree = new ParseTree("(23 + 9 )");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroException()
        {
            var tree = new ParseTree("(/ 23 0 )");
            tree.ResultArithmetic();
        }
    }
}
