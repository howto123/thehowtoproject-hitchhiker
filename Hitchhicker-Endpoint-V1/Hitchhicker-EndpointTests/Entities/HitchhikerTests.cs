using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hitchhicker_Endpoint.Entities.Tests
{
    [TestClass()]
    public class HitchhikerTests
    {
        [TestMethod]
        public void Constructor_WithValidArgumentsIncludingLocation_CreatesValidObject()
        {
            // Arrange
            string location = "hello";
            string destination = "Paris";
            int minutesTillDisposal = 3;

            // Act
            Hitchhiker hitchhiker = new(location, minutesTillDisposal, destination);

            //Assert
            Assert.IsInstanceOfType(hitchhiker, typeof(Hitchhiker));
            Assert.AreEqual(hitchhiker.GetLocation(), location);
            Assert.AreEqual(hitchhiker.GetDestination(), destination);
            Assert.AreEqual(hitchhiker.SouldBeDesposed(), false);
        }

        [TestMethod]
        public void Constructor_WithValidArgumentsExcludingLocation_CreatesValidObject()
        {
            // Arrange
            string location = "hello";
            int minutesTillDisposal = 3;

            // Act
            Hitchhiker hitchhiker = new(location, minutesTillDisposal);

            //Assert
            Assert.IsInstanceOfType(hitchhiker, typeof(Hitchhiker));
            Assert.AreEqual(hitchhiker.GetLocation(), location);
            Assert.AreEqual(hitchhiker.GetDestination(), "");
            Assert.AreEqual(hitchhiker.SouldBeDesposed(), false);
        }

        [TestMethod]
        public void Constructor_WithNegativeMinutesTillDisposal_ThrowsError()
        {
            // Arrange
            string location = "hello";
            int minutesTillDisposal = -3;
            Hitchhiker hitchhiker;

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => hitchhiker = new(location, minutesTillDisposal));
        }

        [TestMethod]
        public void Constructor_WithTooLongLocation_ThrowsError()
        {
            // Arrange
            string location = "Somewhere in a veeeery long and invalid spot";
            int minutesTillDisposal = 1;
            Hitchhiker hitchhiker;

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => hitchhiker = new(location, minutesTillDisposal));
        }

        [TestMethod]
        public void ShouldBeDesposed_SmallMinutesTilDisposal_ReturnsFalse()
        {
            // Arrange
            string location = "hello";
            double minutesTillDisposal = 0.001 / 60;

            // Act
            Hitchhiker hitchhiker = new(location, minutesTillDisposal);

            // Assert
            Assert.AreEqual(hitchhiker.SouldBeDesposed(), false);
        }

        [TestMethod]
        public void ShouldBeDesposed_SmallMinutesTilDisposal_ReturnsTrueAfterWaiting()
        {
            // Arrange
            string location = "hello";
            double minutesTillDisposal = 0.001 / 60;

            // Act
            Hitchhiker hitchhiker = new(location, minutesTillDisposal);

            // Wait and assert
            Thread.Sleep(1);
            Assert.AreEqual(hitchhiker.SouldBeDesposed(), true);
        }
    }
}