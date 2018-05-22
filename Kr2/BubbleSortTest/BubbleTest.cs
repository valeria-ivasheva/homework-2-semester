using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Kr2;


namespace BubbleSortTest
{
    [TestClass]
    public class BubbleTest
    {
        private List<int> listInt = new List<int> { 7, -6, 5, 4, 12, -1 };
        private List<string> listStr = new List<string> { "as", "pop", "lolol", "123123" };

        [TestMethod]
        public void SortIntTest()
        {
            BubbleSortGeneric<int>.BubbleSort(listInt, (int x, int y) => x < y);
            var listTemp = new List<int> { -6,-1,4,5,7,12 };
            Assert.AreEqual(listInt.Count, 6);
            for (int i = 0; i < listInt.Count; i++)
            {
                Assert.AreEqual(listInt[i], listTemp[i]);
            }
        }

        [TestMethod]
        public void IntSortTest()
        {
            listInt = new List<int> { 5, 4, 3, 2, -1, -2 };
            BubbleSortGeneric<int>.BubbleSort(listInt, (int x, int y) => x < y);
            var listTemp = new List<int> { -2,-1,2,3,4,5 };
            Assert.AreEqual(listInt.Count, 6);
            for (int i = 0; i < listInt.Count; i++)
            {
                Assert.AreEqual(listInt[i], listTemp[i]);
            }
        }

        [TestMethod]
        public void SortIntAbsTest()
        {
            BubbleSortGeneric<int>.BubbleSort(listInt, (int x, int y) => Math.Abs(x) < Math.Abs(y));
            var listTemp = new List<int> { -1, 4, 5, -6, 7, 12 };
            Assert.AreEqual(listInt.Count, 6);
            for (int i = 0; i < listInt.Count; i++)
            {
                Assert.AreEqual(listInt[i], listTemp[i]);
            }
        }

        [TestMethod]
        public void SortStrLengthTest()
        {
            BubbleSortGeneric<string>.BubbleSort(listStr, (string strA, string strB) => strA.Length < strB.Length);
            var listTemp = new List<string> { "as", "pop", "lolol", "123123" };
            Assert.AreEqual(listStr.Count, 4);
            for (int i = 0; i < listStr.Count; i++)
            {
                Assert.AreEqual(listStr[i], listTemp[i]);
            }
        }
    }
}
