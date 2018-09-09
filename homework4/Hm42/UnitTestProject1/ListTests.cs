using Hm42;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable3Test
{
    [TestClass]
    public class ListTest
    {
        private List list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void AddedElement()
        {
            list.Insert("pop");
            list.Insert("lolipop");
            Assert.IsTrue(list.HasElement("lolipop"));
            Assert.IsTrue(list.HasElement("pop"));
        }

        [TestMethod]
        public void HasElement()
        {
            Assert.IsFalse(list.HasElement("o"));
            list.Insert("o");
            Assert.IsTrue(list.HasElement("o"));
            Assert.IsFalse(list.HasElement("m"));
        }

        [TestMethod]
        public void ElementWithIndex()
        {
            list.Insert("lol");
            Assert.AreEqual("Error", list.ElementWithIndex(2));
            list.InsertIndex("po", 1);
            Assert.AreEqual("po", list.ElementWithIndex(1));
            Assert.AreEqual("lol", list.ElementWithIndex(2));
        }

        [TestMethod]
        public void InsertIndex()
        {
            list.Insert("pop");
            list.InsertIndex("op", 1);
            list.InsertIndex("oo", 2);
            Assert.AreEqual(list.ElementWithIndex(1), "op");
            Assert.AreEqual(list.ElementWithIndex(2), "oo");
        }

        [TestMethod]
        public void DeleteElementIndex()
        {
            list.Insert("pop");
            list.InsertIndex("op", 2);
            list.InsertIndex("po", 3);
            list.DeleteElementIndex(2);
            Assert.IsFalse(list.HasElement("op"));
            list.DeleteElementIndex(2);
            Assert.IsFalse(list.HasElement("po"));
            list.DeleteElementIndex(1);
            Assert.IsFalse(list.HasElement("pop"));
        }

        [TestMethod]
        public void DeleteElement()
        {
            list.Insert("pop");
            list.Insert("op");
            list.DeleteElement("op");
            Assert.IsFalse(list.HasElement("op"));
            list.DeleteElement("po");
            Assert.IsFalse(list.HasElement("po"));
            list.DeleteElement("");
            Assert.IsFalse(list.HasElement(""));
        }
    }
}
