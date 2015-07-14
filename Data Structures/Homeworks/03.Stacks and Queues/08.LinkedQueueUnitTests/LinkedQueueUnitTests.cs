namespace _08.LinkedQueueUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _07.Linked_Queue;

    [TestClass]
    public class LinkedQueueUnitTests
    {
        private LinkedQueue<int> intStack;
        private LinkedQueue<string> stringStack;

        [TestInitialize]
        public void InitStack()
        {
            this.intStack = new LinkedQueue<int>();
            this.stringStack = new LinkedQueue<string>();
        }

        [TestMethod]
        public void TestEnqueueWhenEmpty()
        {
            Assert.AreEqual(0, this.intStack.Count);
            this.intStack.Enqueue(1);
            Assert.AreEqual(1, this.intStack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeueWhenEmpty()
        {
            this.intStack.Dequeue();
        }

        [TestMethod]
        public void TestDequeueWhenNotEmpty()
        {
            const int Item = 10;
            this.intStack.Enqueue(Item);
            Assert.AreEqual(1, this.intStack.Count);
            var poped = this.intStack.Dequeue();
            Assert.AreEqual(Item, poped);
            Assert.AreEqual(0, this.intStack.Count);
        }

        [TestMethod]
        public void TestEnqueueFor1000Elements()
        {
            Assert.AreEqual(0, this.stringStack.Count);
            for (int i = 0; i < 1000; i++)
            {
                this.stringStack.Enqueue(i.ToString());
                Assert.AreEqual(i + 1, this.stringStack.Count);
            }
        }

        [TestMethod]
        public void TestDequeueFor1000Elements()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.stringStack.Enqueue(i.ToString());
            }

            Assert.AreEqual(1000, this.stringStack.Count);
            for (int i = 999; i >= 0; i--)
            {
                this.stringStack.Dequeue();
                Assert.AreEqual(i, this.stringStack.Count);
            }
        }

        [TestMethod]
        public void TestToArrayWhenNotEmpty()
        {
            this.intStack.Enqueue(3);
            this.intStack.Enqueue(5);
            this.intStack.Enqueue(-2);
            this.intStack.Enqueue(7);
            var arr = this.intStack.ToArray();
            Assert.AreEqual(arr.Length, this.intStack.Count);
            Assert.AreEqual("3, 5, -2, 7", string.Join(", ", arr));
        }

        [TestMethod]
        public void TestToArrayWhenEmpty()
        {
            var arr = this.intStack.ToArray();
            Assert.AreEqual(0, arr.Length);

        }
    }
}