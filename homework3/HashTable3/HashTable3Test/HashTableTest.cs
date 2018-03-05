using HashTable3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable3Test
{
    [TestClass]
    public class HashTableTest
    {
        private HashTable hashTable;

        [TestInitialize]
        public void Initialize()
        {
            hashTable = new HashTable(new HashFunction());
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
    }
}
