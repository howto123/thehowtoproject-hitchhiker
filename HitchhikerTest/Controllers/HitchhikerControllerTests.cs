
using Hitchhicker_Endpoint_V1.Services.HitchhikerManager;
using Hitchhicker_Endpoint_V1.Services.BuilderOfIHitchhiker;
using Moq;
using Hitchhicker_Endpoint_V1.Entities;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Hitchhicker_Endpoint_V1.Controllers.Tests
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
        public void GetAll_GivesBackTheListReceivedFromTheManager()
        {
            // Arrange
            var managerMock = new Mock<IHitchhikerManager>();

            // create some elements to be in list
            var hitchhikerMock1 = new Mock<IHitchhiker>();
            var hitchhikerMock2 = new Mock<IHitchhiker>();
            var hitchhikerMock3 = new Mock<IHitchhiker>();

            // create list itself
            List<IHitchhiker> predefinedList = new()
            {
                hitchhikerMock1.Object,
                hitchhikerMock2.Object,
                hitchhikerMock3.Object
            };

            // set up mock method that gives back list
            managerMock.Setup(mockedObject => mockedObject.Read()).Returns(predefinedList);

            // finally create object to be tested
            var controller = new HitchhikerController(managerMock.Object);

            // Act
            var returnedList = controller.GetAll();

            // Assert
            Assert.AreEqual(predefinedList, returnedList);
            managerMock.Verify(mockedObject => mockedObject.Read(), Times.Once());
        }

        [TestMethod()]
        public void Create_WithTwoValidArgs_MakesACallToTheManagerWithTheReceivedArguments()
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
            controller.Create(args);

            managerMock.Verify();
        }
    }
}