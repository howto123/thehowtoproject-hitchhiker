using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hitchhicker_Endpoint.Entities;
using Hitchhicker_Endpoint.Helpers;
using Hitchhicker_Endpoint.Services.Builder;
using Hitchhicker_Endpoint.Services.HitchhikerManager;
using Moq;

namespace Hitchhicker_Endpoint.Controllers.Tests
{
    [TestClass()]
    public class HitchhikerControllerTests
    {
        [TestMethod()]
        public void Constructor_ShouldInstanciateHitchhikerController()
        {
            // Arrange
            var builderMock = new Mock<BuilderOfIHitchhiker>();
            var managerMock = new Mock<HitchhikerManager>(builderMock.Object);

            // Act
            var controller = new HitchhikerController(managerMock.Object);

            // Assert
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(HitchhikerController));
        }

        [TestMethod()]
        public void Get_ExpectedBehaviour_GivesBackTheListReceivedFromTheManager()
        {
            //Arrange
            // create mock object
            var managerMock = new Mock<IHitchhikerManager>();

            // set up behaviour
            var predefinedList = GetListOfMockIHitchhikers();
            managerMock.Setup(mockedObject => mockedObject.Read()).Returns(predefinedList);

            // create tested object
            var controller = new HitchhikerController(managerMock.Object);

            // compute expected result
            var intermediateList = HitchhikerHelper.MakeLocationDestinationList(predefinedList);
            var expectedReturn = HitchhikerHelper.MakeJSON(intermediateList);

            // Act
            var returnedString = controller.Get();


            // Assert
            Assert.AreEqual(expectedReturn, returnedString);
            managerMock.Verify(mockedObject => mockedObject.Read(), Times.Once());
        }

        [TestMethod()]
        public void Get_WitchBadManager_GivesOutGeneralErrorMessage()
        {
            //Arrange
            // create mock object
            var managerMock = new Mock<IHitchhikerManager>();

            // set up behaviour
            managerMock.Setup(mockedObject => mockedObject.Read()).Throws(new Exception("manager goes wrong"));

            // create tested object
            var controller = new HitchhikerController(managerMock.Object);

            // Act
            var response = controller.Get();

            // Assert
            Assert.AreEqual("Sorry, there was a problem", response);
            managerMock.Verify(mockedObject => mockedObject.Read(), Times.Once());
        }

        [TestMethod()]
        public void Post_WithTwoValidArgs_MakesACallToTheManagerWithArgsAndNull()
        {
            // Arrange
            const string LOCATION = "somewhere";
            const int MINUTES_TILL_DISPOSAL = 1;
            CreateArgs args = new()
            {
                Location = LOCATION,
                MinutesTillDisposal = MINUTES_TILL_DISPOSAL
            };

            var managerMock = new Mock<IHitchhikerManager>();
            managerMock.Setup(mockedObject => mockedObject.Create(LOCATION, MINUTES_TILL_DISPOSAL, null));

            var controller = new HitchhikerController(managerMock.Object);

            // Act
            controller.Post(args);

            // Assert
            managerMock.VerifyAll();
        }

        [TestMethod()]
        public void Post_WithMissingArgs_DoesNotMakeManagerCall()
        {
            // Arrange
            const string? LOCATION = null;
            const int MINUTES_TILL_DISPOSAL = 1;
            CreateArgs args = new()
            {
                Location = LOCATION,
                MinutesTillDisposal = MINUTES_TILL_DISPOSAL
            };

            var managerMock = new Mock<IHitchhikerManager>();

            var controller = new HitchhikerController(managerMock.Object);

            // Act
            controller.Post(args);

            // Assert
            managerMock.Verify(mockedObject => mockedObject.Create(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()), Times.Never());
            managerMock.Verify(mockedObject => mockedObject.Create(It.IsAny<string>(), It.IsAny<int>(), null), Times.Never());
        }

        [TestMethod()]
        public void Post_WithMissingArgs_GivesBackGeneralErrorMessage()
        {
            // Arrange
            const string? LOCATION = null;
            const int MINUTES_TILL_DISPOSAL = 1;
            CreateArgs args = new()
            {
                Location = LOCATION,
                MinutesTillDisposal = MINUTES_TILL_DISPOSAL
            };

            var managerMock = new Mock<IHitchhikerManager>();

            var controller = new HitchhikerController(managerMock.Object);

            // Act
            var response = controller.Post(args);

            // Assert
            Assert.AreEqual("Sorry, there was a problem", response);
        }

        [TestMethod()]
        public void Post_WithThreeValidArgs_MakesACallToTheManagerWithTheReceivedArguments()
        {
            // Arrange
            const string LOCATION = "somewhere";
            const int MINUTES_TILL_DISPOSAL = 1;
            const string DESTINATION = "somewhere";
            CreateArgs args = new()
            {
                Location = LOCATION,
                MinutesTillDisposal = MINUTES_TILL_DISPOSAL,
                Destination = DESTINATION
            };

            var managerMock = new Mock<IHitchhikerManager>();

            managerMock.Setup(mockedObject => mockedObject.Create(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION));

            var controller = new HitchhikerController(managerMock.Object);

            // Act
            controller.Post(args);

            // Assert
            managerMock.VerifyAll();
        }

        private static List<IHitchhiker> GetListOfMockIHitchhikers()
        {
            // create mock elements
            var hitchhikerMock1 = new Mock<IHitchhiker>();
            var hitchhikerMock2 = new Mock<IHitchhiker>();
            var hitchhikerMock3 = new Mock<IHitchhiker>();

            // set up behaviour
            hitchhikerMock1.Setup(mock => mock.GetLocation()).Returns("a");
            hitchhikerMock1.Setup(mock => mock.SouldBeDesposed()).Returns(false);
            hitchhikerMock1.Setup(mock => mock.GetDestination()).Returns("e");

            hitchhikerMock2.Setup(mock => mock.GetLocation()).Returns("b");
            hitchhikerMock2.Setup(mock => mock.SouldBeDesposed()).Returns(false);
            hitchhikerMock2.Setup(mock => mock.GetDestination()).Returns("");

            hitchhikerMock3.Setup(mock => mock.GetLocation()).Returns("c");
            hitchhikerMock3.Setup(mock => mock.SouldBeDesposed()).Returns(true);
            hitchhikerMock3.Setup(mock => mock.GetDestination()).Returns("f");

            // create list
            List<IHitchhiker> list = new()
        {
            hitchhikerMock1.Object,
            hitchhikerMock2.Object,
            hitchhikerMock3.Object
        };

            return list;
        }
    }
}