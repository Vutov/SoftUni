using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTests
{
    using System.Collections.Generic;
    using _04.OrderedSet;

    [TestClass]
    public class BinaryTreeTests
    {
        private BinaryTree<int> tree;
        
        [TestInitialize]
        public void InitBinaryTree()
        {
            this.tree = new BinaryTree<int>(1);
        }

        [TestMethod]
        public void TestCountWhenHasNoChildShouldReturnOne()
        {
            var count = this.tree.Count();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TestAddWhenAddingOneElementShouldReturnTwo()
        {
            this.tree.Add(9);
            var count = this.tree.Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestAddWhenAddingFiveElementsShouldReturnSix()
        {
            this.tree.Add(9);
            this.tree.Add(12);
            this.tree.Add(19);
            this.tree.Add(6);
            this.tree.Add(25);
            var count = this.tree.Count();
            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void TestContainsWhenNotInTreeShouldReturnFalse()
        {
            var found = this.tree.Contains(2);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void TestContainsWhenInTreeShouldReturnTrue()
        {
            this.tree.Add(17);
            var found = this.tree.Contains(17);
            Assert.IsTrue(found);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void TestRemoveWhenElementNotThereShouldReturnInvalidOperationException()
        {
            this.tree.Remove(20);
        }

        [TestMethod]
        public void TestRemoveWhenElementPresentShouldRemoveItProperly()
        {
            this.tree.Add(20);
            this.tree.Remove(20);
            Assert.IsFalse(this.tree.Contains(20));
        }

        [TestMethod]
        public void TestGetElementsByValueWhenOnlyOneElementShouldReturnIt()
        {
            var elements = this.tree.GetElementsByValue();
            Assert.AreEqual(1, elements.Count);
        }

        [TestMethod]
        public void TestGetElementsByValueShouldReturnSameValuesAsAdded()
        {
            this.tree.Add(3);
            this.tree.Add(2);
            var expectedResult = new List<int> {1, 2, 3};
            Assert.AreEqual(string.Join(", ", expectedResult), string.Join(", ", this.tree.GetElementsByValue()));
        }
    }
}
