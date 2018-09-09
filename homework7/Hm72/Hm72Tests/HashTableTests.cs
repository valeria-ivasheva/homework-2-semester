using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hm72.Tests
{
    [TestClass]
    public class HashTableTests
    {
        private HashTable<string> hashTable;

        [TestInitialize]
        public void Initialize()
        {
            hashTable = new HashTable<string>();
        }

        [TestMethod]
        public void InsertHashTable()
        {
            hashTable.InsertElement("lol");
            hashTable.InsertElement("pol");
            Assert.IsTrue(hashTable.HasElement("lol"));
            Assert.IsTrue(hashTable.HasElement("pol"));
        }

        [TestMethod]
        public void DeleteElementHashTable()
        {
            hashTable.InsertElement("koko");
            Assert.IsTrue(hashTable.HasElement("koko"));
            hashTable.DeleteElement("koko");
            Assert.IsFalse(hashTable.HasElement("koko"));
        }

        [TestMethod]
        public void HasElementHashTable()
        {
            Assert.IsFalse(hashTable.HasElement("lol"));
            hashTable.InsertElement("lol");
            Assert.IsTrue(hashTable.HasElement("lol"));
        }

        [TestMethod()]
        public void EnumeratorTest()
        {
            var hashTableTemp = new HashTable<int>();
            for (int i = 1; i <= 3; i++)
            {
                hashTableTemp.InsertElement(i);
            }
            int j = 0;
            foreach (var temp in hashTableTemp)
            {
                Assert.AreEqual(temp, j+1);
                j++;
            }
        }
    }
}
