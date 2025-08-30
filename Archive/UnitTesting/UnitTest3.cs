using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class NewTests
    {
        [Test]
        public void TestOne()
        {
            // Arrange
            var userInputs = new List<int> { 11, 2, 2 };

            // Act
            var result = 3;

            // Assert
            Assert.AreEqual(3, result);
        }
    }
}
