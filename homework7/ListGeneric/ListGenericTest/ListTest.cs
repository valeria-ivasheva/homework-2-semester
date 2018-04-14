using System;
using ListGeneric;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListGenericTest
{
    [TestClass]
    public class ListTest
    {
        private List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();
        }

        [TestMethod]
        public void TakeElement()
        {
            list.Add(2);
            Assert.AreEqual(list[0], 2);
        }

        [TestMethod]
        public void AddElementList()
        {
            list.Add(232);
            list.Add(2311);
            Assert.AreEqual(list[0], 232);
            Assert.AreEqual(list[1], 2311);
        }

        [TestMethod]
        public void CountOfList()
        {
            list.Add(222);
            list.Add(121);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void Contains()
        {
            list.Add(12);
            Assert.IsTrue(list.Contains(12));
            Assert.IsFalse(list.Contains(-12));
        }

        [TestMethod]
        public void CopyToList()
        {
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            var arrayTemp = new int[3];
            list.CopyTo( arrayTemp, 0);
            for (int i = 1; i <=3; i++)
            {
                Assert.AreEqual(list[i - 1], i);
            }
        }

        [TestMethod]
        public void IndexOfTest()
        {
            list.Add(-12);
            list.Add(12);
            Assert.AreEqual(list.IndexOf(-12), 0);
            Assert.AreEqual(list.IndexOf(12), 1);
            Assert.AreEqual(list.IndexOf(122), -1);
        }

        [TestMethod]
        public void InsertTest()
        {
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            list.Insert(1, 99);
            Assert.AreEqual(list[1], 99);
        }

        [ExpectedException(typeof(IndexOutOfRangeException))]
        [TestMethod]
        public void InsertException()
        {
            list.Insert(12, 12);
        }

        [TestMethod]
        public void Remove()
        {
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            Assert.IsTrue(list.Remove(1));
            Assert.IsTrue(list.Remove(2));
            Assert.IsFalse(list.Contains(2));
            Assert.IsFalse(list.Remove(2));
        }

        [TestMethod]
        public void RemoveAt()
        {
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            list.RemoveAt(0);
            Assert.IsFalse(list.Contains(1));
        }  

        [TestMethod]
        public void EnumeratorTest()
        {
            for (int i = 1; i <= 3; i++)
            {
                list.Add(i);
            }
            int j = 1;
            foreach(var temp in list)
            {
                Assert.AreEqual(temp, j);
                j++;
            }
        }
    }
}
