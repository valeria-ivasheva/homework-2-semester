using Microsoft.VisualStudio.TestTools.UnitTesting;
using kr1;

namespace QueueTest
{
    [TestClass]
    public class PriorityQueueTest
    {
        private PriorityQueue<int> queueInt;

        [TestInitialize]
        public void Initialize()
        {
            queueInt = new PriorityQueue<int>();
        }

        [TestMethod]
        public void AddElementInEmptyQueueInt()
        {
            queueInt.Enqueue(12, -2);
            Assert.IsTrue(queueInt.HasElement(12));
        }

        [TestMethod]
        public void AddElementInEmptyQueueStr()
        {
            var queueStr = new PriorityQueue<string>();
            queueStr.Enqueue("1221", -2);
            Assert.IsTrue(queueStr.HasElement("1221"));
        }

        [TestMethod]
        public void DeleteElementQueueStr()
        {
            var queueStr = new PriorityQueue<string>();
            queueStr.Enqueue("1221", -2);
            queueStr.Dequeue();
            Assert.IsTrue(!queueStr.HasElement("1221"));
        }

        [TestMethod]
        public void Enqueue()
        {
            queueInt.Enqueue(12, -12);
            queueInt.Enqueue(122, 0);
            queueInt.Enqueue(3, -12);
            Assert.IsTrue(queueInt.HasElement(122));
            Assert.IsTrue(queueInt.HasElement(12));
            Assert.IsTrue(queueInt.HasElement(3));
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyQueueException))]
        public void DequeueEmpty()
        {
            queueInt.Dequeue();
        }

        [TestMethod]
        public void RepeatingElementDelete()
        {
            queueInt.Enqueue(12, -12);
            queueInt.Enqueue(3, -12);
            int temp = queueInt.Dequeue();
            Assert.AreEqual(12, temp);
        }

        [TestMethod]
        public void DeleteElement()
        {
            queueInt.Enqueue(12, -12);
            queueInt.Enqueue(3, -12);
            queueInt.Enqueue(122, 0);
            int result = queueInt.Dequeue();
            Assert.AreEqual(result, 122);
        }

    }
}
