using Hitchhicker_Endpoint_V1;
using Hitchhicker_Endpoint_V1.Entities;
using Hitchhicker_Endpoint_V1.Services;

namespace HitchhikerIntegrationTest
{
    [TestClass]
    public class HitchhikerManagerWithHichhiker
    {
        [TestMethod]
        public void ReadAfterCreate_WithValidArgs_GivesBackTheCreaedElements()
        {
            // setting valid args
            const string LOCATION = "somehwere";
            const int MINUTES_TILL_DISPOSAL = 1;
            const string DESTINATION = "tosomewhere";


            // arrange
            var manager = new HitchhikerManager();
            // the creation time and therefore disposal time are a little earlier
            var almostHitchhikerThatSouldBeCreated = new Hitchhiker(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);

            // create three hitchhikers inside manager
            manager.Create(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);
            manager.Create(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);
            manager.Create(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);

            var list = manager.Read();

            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 3);
            Assert.IsInstanceOfType(list[0], typeof(Hitchhiker));
            Assert.IsTrue(HitchhikersAreAlmostEqual(list[0], almostHitchhikerThatSouldBeCreated));
            Assert.IsInstanceOfType(list[1], typeof(Hitchhiker));
            Assert.IsTrue(HitchhikersAreAlmostEqual(list[1], almostHitchhikerThatSouldBeCreated));
            Assert.IsInstanceOfType(list[2], typeof(Hitchhiker));
            Assert.IsTrue(HitchhikersAreAlmostEqual(list[2], almostHitchhikerThatSouldBeCreated));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => list[3]);
        }

        private static bool HitchhikersAreAlmostEqual(Hitchhiker a, Hitchhiker b)
        {
            if( a.GetLocation().Equals(b.GetLocation()) &&
                a.GetDestination().Equals(b.GetDestination()) &&
                a.SouldBeDesposed().Equals(b.SouldBeDesposed()))
            { 
                return true;
            }
            return false;
        }
    }
}