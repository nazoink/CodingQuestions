using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class BoxMovingCalculatorTests
    {
        [Test]
        public void CalculateNumberOfPiles_NumBoxesIs11AndMaxPileSizeIs2_AndSplitIntoPilesIs2_Returns7()
        {
            // Arrange
            var userInputs = new List<int> { 11, 2, 2 };

            // Act
            var result = BoxMovingCalculator.CalculateNumberOfPiles(userInputs);

            // Assert
            Assert.AreEqual(7, result);
        }


        [Test]
        public void CalculateNumberOfPiles_NumBoxesIs3AndMaxPileSizeIs2_AndSplitIntoPilesIs5_Returns3()
        {
            // Arrange
            var userInputs = new List<int> { 3, 2, 5 };

            // Act
            var result = BoxMovingCalculator.CalculateNumberOfPiles(userInputs);

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void CalculateNumberOfPiles_NumBoxesIs100AndMaxPileSizeIs1_AndSplitIntoPilesIs2_Returns100()
        {
            // Arrange
            var userInputs = new List<int> { 100, 1, 2 };

            // Act
            var result = BoxMovingCalculator.CalculateNumberOfPiles(userInputs);

            // Assert
            Assert.AreEqual(100, result);
        }
    }
}
