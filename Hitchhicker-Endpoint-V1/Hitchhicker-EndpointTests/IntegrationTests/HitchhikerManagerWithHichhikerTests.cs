using Hitchhicker_Endpoint.Entities;
using Hitchhicker_Endpoint.Services.Builder;
using Hitchhicker_Endpoint.Services.HitchhikerManager;
using Hitchhiker_Endpoint.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hitchhicker_EndpointTests.IntegrationTests
{
    internal class HitchhikerManagerWithHichhikerTests
    {
        [TestMethod]
        public void ReadAfterCreate_WithValidArgs_GivesBackTheCreaedElements()
        {
            // setting valid args
            const string LOCATION = "somehwere";
            const int MINUTES_TILL_DISPOSAL = 1;
            const string DESTINATION = "tosomewhere";


            // arrange
            IBuilderOfIHitchhiker builder = new BuilderOfIHitchhiker();
            HitchhikerManager manager = new(builder);
            // the creation time and therefore disposal time are a little earlier
            IHitchhiker almostHitchhikerThatSouldBeCreated = builder.BuildIHitchhiker(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);

            // create three hitchhikers inside manager
            manager.Create(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);
            manager.Create(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);
            manager.Create(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);

            var list = manager.Read();

            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 3);
            Assert.IsInstanceOfType(list[0], typeof(Hitchhiker));
            Assert.IsTrue(TestHelpers.HitchhikersAreAlmostEqual(list[0], almostHitchhikerThatSouldBeCreated));
            Assert.IsInstanceOfType(list[1], typeof(Hitchhiker));
            Assert.IsTrue(TestHelpers.HitchhikersAreAlmostEqual(list[1], almostHitchhikerThatSouldBeCreated));
            Assert.IsInstanceOfType(list[2], typeof(Hitchhiker));
            Assert.IsTrue(TestHelpers.HitchhikersAreAlmostEqual(list[2], almostHitchhikerThatSouldBeCreated));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list[3]);
        }
    }
}
