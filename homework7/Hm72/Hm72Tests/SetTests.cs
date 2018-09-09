using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hm72.Tests
{
    [TestClass()]
    public class SetTests
    {
        private Set<int> set;

        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int>();
        }

        [TestMethod()]
        public void AddTest()
        {
            set.Add(22);
            set.Add(22);
            Assert.AreEqual(set.Count, 1);
            set.Add(-22);
            Assert.IsTrue(set.Contains(22));
            Assert.IsTrue(set.Contains(-22));
            Assert.AreEqual(2, set.Count);
        }

        [TestMethod()]
        public void CountTest()
        {
            Assert.AreEqual(0, set.Count);
            set = new Set<int> { 12, 23, 90, -12, 23, 0 };
            Assert.AreEqual(5, set.Count);
        }

        [TestMethod()]
        public void ClearTest()
        {
            set.Add(12);
            set.Add(122);
            set.Clear();
            Assert.IsFalse(set.Contains(122));
            Assert.IsFalse(set.Contains(12));
            Assert.AreEqual(0, set.Count);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            set.Add(12);
            set.Add(-2);
            Assert.IsTrue(set.Contains(12));
            Assert.IsTrue(set.Contains(-2));
            Assert.IsFalse(set.Contains(2));
            Assert.IsFalse(set.Contains(122));
        }

        [TestMethod()]
        public void CopyToTest()
        {
            set = new Set<int> { 12, 123, 1233 };
            var arrayTemp = new int[3];
            set.CopyTo(arrayTemp, 0);
            Assert.AreEqual(arrayTemp[0], 1233);
            Assert.AreEqual(arrayTemp[1], 123);
            Assert.AreEqual(arrayTemp[2], 12);
        }

        [TestMethod()]
        public void ExceptWithTest()
        {
            var arrayTemp = new int[3] { 3, 4, 5 };
            set = new Set<int> { 3, 4, 5, 56, 67, -2 };
            set.ExceptWith(arrayTemp);
            Assert.AreEqual(set.Count, 3);
            for (int i = 0; i < 3; i++)
            {
                Assert.IsFalse(set.Contains(arrayTemp[i]));
            }
        }

        [TestMethod()]
        public void IntersectWithTest()
        {
            var arrayTemp = new int[4] { 3, 4, 5 , 3};
            set = new Set<int> { 0, 1, 2, 3, 4, 5 };
            set.IntersectWith(arrayTemp);
            Assert.AreEqual(3, set.Count);
            for (int i = 3; i <6; i++)
            {
                Assert.IsTrue(set.Contains(i));
            }
        }

        [TestMethod()]
        public void IsProperSubsetOfTest()
        {
            Assert.IsTrue(set.IsProperSubsetOf(set));
            var arrayTemp = new int[3] { 1, 2, 3 };
            set.Add(1);
            Assert.IsTrue(set.IsProperSubsetOf(arrayTemp));
            set.Add(-1);
            Assert.IsFalse(set.IsProperSubsetOf(arrayTemp));
            set = new Set<int> { 1, 2, 3 };
            Assert.IsFalse(set.IsProperSubsetOf(arrayTemp));
        }

        [TestMethod()]
        public void IsProperSupersetOfTest()
        {
            var arrayTemp = new int[3] { 1, 2, 3 };
            Assert.IsFalse(set.IsProperSupersetOf(arrayTemp));
            Assert.IsTrue(set.IsProperSupersetOf(set));
            set = new Set<int> { 1, 2, 3 };
            Assert.IsFalse(set.IsProperSupersetOf(arrayTemp));
            set.Add(12);
            Assert.IsTrue(set.IsProperSupersetOf(arrayTemp));
            set = new Set<int> { 1, 2, 43, 33 };
            Assert.IsFalse(set.IsProperSupersetOf(arrayTemp));
        }

        [TestMethod()]
        public void IsSubsetOfTest()
        {
            Assert.IsTrue(set.IsSubsetOf(set));
            var arrayTemp = new int[3] { 1, 2, 3 };
            set.Add(1);
            Assert.IsTrue(set.IsSubsetOf(arrayTemp));
            set.Add(-1);
            Assert.IsFalse(set.IsSubsetOf(arrayTemp));
            set = new Set<int> { 1, 2, 3 };
            Assert.IsTrue(set.IsSubsetOf(arrayTemp));
        }

        [TestMethod()]
        public void IsSupersetOfTest()
        {
            var arrayTemp = new int[3] { 1, 2, 3 };
            Assert.IsFalse(set.IsSupersetOf(arrayTemp));
            Assert.IsTrue(set.IsSupersetOf(set));
            set = new Set<int> { 1, 2, 3 };
            Assert.IsTrue(set.IsSupersetOf(arrayTemp));
            set.Add(12);
            Assert.IsTrue(set.IsSupersetOf(arrayTemp));
            set = new Set<int> { 1, 2, 43, 33 };
            Assert.IsFalse(set.IsSupersetOf(arrayTemp));
        }

        [TestMethod()]
        public void OverlapsTest()
        {
            Assert.IsFalse(set.Overlaps(set));
            var arrayTemp = new int[2] { 9, 2 };
            set = new Set<int> { 12 };
            Assert.IsFalse(set.Overlaps(arrayTemp));
            set.Add(2);
            Assert.IsTrue(set.Overlaps(arrayTemp));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.IsFalse(set.Remove(-1));
            set = new Set<int> { 12, 2, 3 };
            Assert.IsFalse(set.Remove(-1));
            Assert.IsTrue(set.Remove(2));
            Assert.IsFalse(set.Contains(2));
            Assert.AreEqual(2, set.Count);
            Assert.IsTrue(set.Remove(12));
            Assert.IsFalse(set.Contains(12));
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod()]
        public void SetEqualsTest()
        {
            Assert.IsTrue(set.SetEquals(set));
            set = new Set<int> { 12, 1, 2 };
            var arrayTemp = new int[4] { 12, 1, 2, -1 };
            Assert.IsFalse(set.SetEquals(arrayTemp));
            set.Add(-1);
            Assert.IsTrue(set.SetEquals(arrayTemp));
        }

        [TestMethod()]
        public void SymmetricExceptWithTest()
        {
            var arrayTemp = new int[4] { 1, 3, 2, 3 };
            set.SymmetricExceptWith(arrayTemp);
            Assert.AreEqual(set.Count, 3);
            Assert.IsTrue(set.SetEquals(arrayTemp));
            set.SymmetricExceptWith(arrayTemp);
            Assert.AreEqual(0, set.Count);
            set = new Set<int> { 123, 12, 2, 1 };
            set.SymmetricExceptWith(arrayTemp);
            Assert.AreEqual(set.Count, 3);
            Assert.IsTrue(set.Contains(123));
            Assert.IsFalse(set.Contains(1));
            Assert.IsTrue(set.Contains(3));
        }

        [TestMethod()]
        public void UnionWithTest()
        {
            var arrayTemp = new int[4] { 1, 2, 3, 2 };
            set.UnionWith(arrayTemp);
            Assert.AreEqual(set.Count, 3);
            set.Add(45);
            arrayTemp[3] = 90;
            set.UnionWith(arrayTemp);
            Assert.AreEqual(set.Count, 5);
            Assert.IsTrue(set.Contains(45));
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(90));
        }

        [TestMethod()]
        public void EnumeratorTest()
        {
            for (int i = 1; i <= 3; i++)
            {
                set.Add(i);
            }
            int j = 3;
            foreach (var temp in set)
            {
                Assert.AreEqual(temp, j);
                j--;
            }
        }
    }
}