using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmallestNumbers.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleApplication1;
    using Moq;


    [TestClass]
    public class TestGetSmallestNumbers
    {
        private const int Numbers = 10000;

        [TestMethod]
        [Timeout(150)]
        public void TestGetSmallestNumbers_PerformanceTest_Should_WorkUnder100msFor10000Items()
        {
            var inputMock = new Mock<Input>();
            inputMock.Setup(i => i.GetNextNumber()).Returns(12);
            var numbersCalc = new NumbersCalculator();
            var smallestNums = numbersCalc.GetSmallestNumbers(Numbers, inputMock.Object);
            Assert.AreEqual(3, smallestNums.Count);
        }
    }
}
