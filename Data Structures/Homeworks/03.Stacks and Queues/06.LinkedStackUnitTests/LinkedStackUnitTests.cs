namespace _06.LinkedStackUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _05.Lined_Stack;

    [TestClass]
    public class LinkedStackUnitTests
    {
        private LinkedStack<int> intStack;
        private LinkedStack<string> stringStack;

        [TestInitialize]
        public void InitStack()
        {
            this.intStack = new LinkedStack<int>();
            this.stringStack = new LinkedStack<string>();
        }

        [TestMethod]
        public void TestPushWhenEmpty()
        {
            Assert.AreEqual(0, this.intStack.Count);
            this.intStack.Push(1);
            Assert.AreEqual(1, this.intStack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopWhenEmpty()
        {
            this.intStack.Pop();
        }

        [TestMethod]
        public void TestPopWhenNotEmpty()
        {
            const int Item = 10;
            this.intStack.Push(Item);
            Assert.AreEqual(1, this.intStack.Count);
            var poped = this.intStack.Pop();
            Assert.AreEqual(Item, poped);
            Assert.AreEqual(0, this.intStack.Count);
        }

        [TestMethod]
        public void TestPushFor1000Elements()
        {
            Assert.AreEqual(0, this.stringStack.Count);
            for (int i = 0; i < 1000; i++)
            {
                this.stringStack.Push(i.ToString());
                Assert.AreEqual(i + 1, this.stringStack.Count);
            }
        }

        [TestMethod]
        public void TestPopFor1000Elements()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.stringStack.Push(i.ToString());
            }

            Assert.AreEqual(1000, this.stringStack.Count);
            for (int i = 999; i >= 0; i--)
            {
                this.stringStack.Pop();
                Assert.AreEqual(i, this.stringStack.Count);
            }
        }

        [TestMethod]
        public void TestToArrayWhenNotEmpty()
        {
            this.intStack.Push(3);
            this.intStack.Push(5);
            this.intStack.Push(-2);
            this.intStack.Push(7);
            var arr = this.intStack.ToArray();
            Assert.AreEqual(arr.Length, this.intStack.Count);
            Assert.AreEqual("7, -2, 5, 3", string.Join(", ", arr));
        }

        [TestMethod]
        public void TestToArrayWhenEmpty()
        {
            var arr = this.intStack.ToArray();
            Assert.AreEqual(0, arr.Length);

        }
    }
}
