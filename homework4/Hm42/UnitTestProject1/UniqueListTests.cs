using Hm42;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UniqueListTests
    {
        private UniqueList list;

        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod]
        public void InsertTest()
        {
            list.Insert("pop");
            list.Insert("op");
            Assert.IsTrue(list.HasElement("pop"));
            Assert.IsTrue(list.HasElement("op"));
        }

        [TestMethod]
        public void InsertIndexTest()
        {
            list.InsertIndex("o", 1);
            list.InsertIndex("op", 1);
            list.InsertIndex("lol", 2);
            Assert.AreEqual("lol", list.ElementWithIndex(2));
            Assert.AreEqual("op", list.ElementWithIndex(1));
        }

        [TestMethod]
        public void DeleteElement()
        {
            list.Insert("lol");
            list.Insert("pop");
            list.DeleteElement("pop");
            Assert.IsFalse(list.HasElement("pop"));
            list.DeleteElement("lol");
            Assert.IsFalse(list.HasElement("lol"));
        }

        [TestMethod]
        [ExpectedException(typeof(RepeatingElementException))]
        public void InsertFailTest()
        {
            list.Insert("lol");
            list.Insert("lol");
        }

        [TestMethod]
        [ExpectedException(typeof(RepeatingElementException))]
        public void InsertWithIndexFailTest()
        {
            list.InsertIndex("lol", 1);
            list.InsertIndex("lol", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(NonexistentException))]
        public void DeleteFailTest()
        {
            list.Insert("lol");
            list.DeleteElement("lolo");
        }
    }
}
