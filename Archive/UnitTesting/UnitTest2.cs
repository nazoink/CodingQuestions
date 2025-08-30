using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class ReverseOrderOfWordsTests
    {
        [Test]
        public void TestOne()
        {
            // Arrange
            var userInputs = new List<string> { "11", "2", "2" };

            // Act
            var result = ReverseOrderOfWords.ReverseWordOrder(userInputs);

            // Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}
