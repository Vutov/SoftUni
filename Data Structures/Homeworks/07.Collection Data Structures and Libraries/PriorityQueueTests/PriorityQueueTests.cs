namespace PriorityQueueTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _03.PriorityQueue;

    [TestClass]
    public class PriorityQueueTests
    {
        private PriorityQueue<int> queue;

        [TestInitialize]
        public void InitPriorityQueue()
        {
            this.queue = new PriorityQueue<int>();
        }

        [TestMethod]
        public void TestEneueuWhenEmptyShouldEnqueCorrectly()
        {
            this.queue.Enqueue(1, 1);

            Assert.AreEqual(this.queue.Peek(), 1);
            var allElements = new StringBuilder();
            this.queue.ForEach(e =>
            {
                allElements.Append(e);
            });

            Assert.AreEqual("1", allElements.ToString());
        }

        [TestMethod]
        public void TestEneueuWhenAddedManyWithDifferencPriorityShouldEnqueCorrectlyAndPrioritize()
        {
            this.queue.Enqueue(31, 3);
            this.queue.Enqueue(32, 3);
            this.queue.Enqueue(41, 4);
            this.queue.Enqueue(21, 2);
            this.queue.Enqueue(51, 5);
            this.queue.Enqueue(11, 1);
            this.queue.Enqueue(42, 4);
            this.queue.Enqueue(33, 3);
            this.queue.Enqueue(22, 2);
            this.queue.Enqueue(52, 5);
            this.queue.Enqueue(12, 1);
            this.queue.Enqueue(34, 3);
            this.queue.Enqueue(13, 1);
            this.queue.Enqueue(23, 2);
            this.queue.Enqueue(24, 2);
            this.queue.Enqueue(35, 3);
            this.queue.Enqueue(36, 3);
            this.queue.Enqueue(25, 2);

            Assert.AreEqual(this.queue.Peek(), 11);
            var allElements = new StringBuilder();
            this.queue.ForEach(e =>
            {
                allElements.Append(e + ", ");
            });

            Assert.AreEqual("11, 12, 13, 25, 22, 21, 23, 33, 31, 52, 51, 41, 34, 42, 24, 35, 36, 32, ", allElements.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeueWhenNoElementToRemoveShouldThrowInvalidOperationException()
        {
            this.queue.Dequeue();
        }

        [TestMethod]
        public void TestDeqeueWhenAddedManyWithDifferencPriorityShouldDequeueCorrectlyAndPrioritize()
        {
            // Value is two digits - first digit is the priority, second is the adding number.
            // example - 31 -> priority 3, 1st with that priority to be added.
            this.queue.Enqueue(31, 3);
            this.queue.Enqueue(32, 3);
            this.queue.Enqueue(41, 4);
            this.queue.Enqueue(21, 2);
            this.queue.Enqueue(51, 5);
            this.queue.Enqueue(11, 1);
            this.queue.Enqueue(42, 4);
            this.queue.Enqueue(33, 3);
            this.queue.Enqueue(22, 2);
            this.queue.Enqueue(52, 5);
            this.queue.Enqueue(12, 1);
            this.queue.Enqueue(34, 3);
            this.queue.Enqueue(13, 1);
            this.queue.Enqueue(23, 2);
            this.queue.Enqueue(24, 2);
            this.queue.Enqueue(35, 3);
            this.queue.Enqueue(36, 3);
            this.queue.Enqueue(25, 2);
            this.queue.Enqueue(14, 1);

            Assert.AreEqual(this.queue.Peek(), 11);
            Assert.AreEqual(this.queue.Dequeue(), 11);

            Assert.AreEqual(this.queue.Peek(), 12);
            Assert.AreEqual(this.queue.Dequeue(), 12);

            Assert.AreEqual(this.queue.Peek(), 13);
            Assert.AreEqual(this.queue.Dequeue(), 13);

            Assert.AreEqual(this.queue.Peek(), 14);
            Assert.AreEqual(this.queue.Dequeue(), 14);

            Assert.AreEqual(this.queue.Peek(), 21);
            Assert.AreEqual(this.queue.Dequeue(), 21);

            Assert.AreEqual(this.queue.Peek(), 22);
            Assert.AreEqual(this.queue.Dequeue(), 22);

            Assert.AreEqual(this.queue.Peek(), 23);
            Assert.AreEqual(this.queue.Dequeue(), 23);

            Assert.AreEqual(this.queue.Peek(), 24);
            Assert.AreEqual(this.queue.Dequeue(), 24);

            Assert.AreEqual(this.queue.Peek(), 25);
            Assert.AreEqual(this.queue.Dequeue(), 25);

            Assert.AreEqual(this.queue.Peek(), 31);
            Assert.AreEqual(this.queue.Dequeue(), 31);

            Assert.AreEqual(this.queue.Peek(), 32);
            Assert.AreEqual(this.queue.Dequeue(), 32);

            Assert.AreEqual(this.queue.Peek(), 33);
            Assert.AreEqual(this.queue.Dequeue(), 33);

            Assert.AreEqual(this.queue.Peek(), 34);
            Assert.AreEqual(this.queue.Dequeue(), 34);

            Assert.AreEqual(this.queue.Peek(), 35);
            Assert.AreEqual(this.queue.Dequeue(), 35);

            Assert.AreEqual(this.queue.Peek(), 36);
            Assert.AreEqual(this.queue.Dequeue(), 36);

            Assert.AreEqual(this.queue.Peek(), 41);
            Assert.AreEqual(this.queue.Dequeue(), 41);

            Assert.AreEqual(this.queue.Peek(), 42);
            Assert.AreEqual(this.queue.Dequeue(), 42);

            Assert.AreEqual(this.queue.Peek(), 51);
            Assert.AreEqual(this.queue.Dequeue(), 51);

            Assert.AreEqual(this.queue.Peek(), 52);
            Assert.AreEqual(this.queue.Dequeue(), 52);
        }

        [TestMethod]
        public void TestGrowthAndShrinkingWhenAddedHundredElementsAndThanRemovedShouldWorkProperly()
        {
            var rng = new Random();
            for (int i = 0; i < 1000; i++)
            {
                this.queue.Enqueue(rng.Next(0,1000), rng.Next(1,6));
            }

            Assert.AreEqual(1000, this.queue.Count());
            Assert.AreEqual(1024, this.queue.Capacity());

            for (int i = 1; i <= 1000; i++)
            {
                this.queue.Dequeue();
                if (i == 660)
                {
                    Assert.AreEqual(340, this.queue.Count());
                    Assert.AreEqual(512, this.queue.Capacity());
                }

                if (i == 831)
                {
                    Assert.AreEqual(169, this.queue.Count());
                    Assert.AreEqual(256, this.queue.Capacity());
                }
            }

            Assert.AreEqual(0, this.queue.Count());
            Assert.AreEqual(8, this.queue.Capacity());
        }

        [TestMethod]
        public void TestIsEmptyWhenEmptyShouldReturnTrue()
        {
            Assert.IsTrue(this.queue.IsEmpty());
        }

        [TestMethod]
        public void TestIsEmptyWhenNotEmptyShouldReturnFalse()
        {
            this.queue.Enqueue(41, 4);
            Assert.IsFalse(this.queue.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeekWhenEmptyShouldShouldThrowInvalidOperationException()
        {
            this.queue.Peek();
        }


        [TestMethod]
        public void TestContainsWhenDontContainsShouldReturnFalse()
        {
            this.queue.Enqueue(41, 4);
            Assert.IsFalse(this.queue.Contains(1));
        }

        [TestMethod]
        public void TestContainsWhenContainsShouldShouldReturnTrue()
        {
            this.queue.Enqueue(41, 4);
            Assert.IsTrue(this.queue.Contains(41));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGetHighestPriorityWhenEmptyShouldThrowInvalidOperationException()
        {
            this.queue.GetCurrentHightestPriority();
        }

        [TestMethod]
        public void TestGetHighestPriorityWhenNotEmptyShouldReturnHightestPriority()
        {
            this.queue.Enqueue(41, 4);            
            Assert.AreEqual(4, this.queue.GetCurrentHightestPriority());
        }
    }
}