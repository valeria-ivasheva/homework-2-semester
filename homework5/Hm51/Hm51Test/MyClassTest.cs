using Hm51;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hm51Test
{
    [TestClass]
    public class MyClassTest
    {
        List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int> { 1, 2, 3 };

        }

        [TestMethod]
        public void MapTest()
        {
            var listResult = MyClass.Map(list, x => x * 2);
            int[] result = new int[3];
            listResult.CopyTo(result);
            for (int i = 1; i < 4; i++)
            {
                Assert.AreEqual(i * 2, result[i - 1]);
            }
        }

        [TestMethod]
        public void FilterTest()
        {
            var listResult = MyClass.Filter(list, x => x % 2 == 1);
            foreach (int element in listResult)
            {
                Assert.IsTrue(element % 2 == 1);
            }
            Assert.AreEqual(-1, listResult.IndexOf(2));
        }

        [TestMethod]
        public void FoldTest()
        {
            int result = MyClass.Fold(list, 3, (start, element) => start * element);
            Assert.AreEqual(18, result);
        }
    }
}
