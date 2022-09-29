using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hitchhicker_Endpoint.Services.Builder;
using Hitchhicker_Endpoint.Entities;
using Hitchhiker_Endpoint.Helpers;

namespace Hitchhicker_Endpoint.Services.HitchhikerManager.Tests
{
    [TestClass()]
    public class HitchhikerManagerTests
    {
        // Create
        [TestMethod]
        public void Create_ValidNewHitchhikerWithoutLocation_ReadContainsNewHitchhiker()
        {
            // Arrange
            IBuilderOfIHitchhiker builder = new BuilderOfIHitchhiker();
            HitchhikerManager manager = new(builder);

            IHitchhiker hitchhikerThatShouldBeCreated = builder.BuildIHitchhiker("hSomewhere", 10);

            manager.Create("hSomewhere", 10);
            IHitchhiker hitchhikerThatActuallyWasCreated = manager.Read().Where(h => h.GetLocation() == "hSomewhere").ToList()[0];

            Assert.AreEqual(hitchhikerThatActuallyWasCreated.GetDestination(), hitchhikerThatShouldBeCreated.GetDestination());
            Assert.AreEqual(hitchhikerThatActuallyWasCreated.GetLocation(), hitchhikerThatShouldBeCreated.GetLocation());
            Assert.AreEqual(hitchhikerThatActuallyWasCreated.SouldBeDesposed(), hitchhikerThatShouldBeCreated.SouldBeDesposed());
        }

        [TestMethod]
        public void Create_ValidNewHitchhikerWitchLocation_ReadContainsNewHitchhiker()
        {
            IBuilderOfIHitchhiker builder = new BuilderOfIHitchhiker();
            HitchhikerManager manager = new(builder);

            const string LOCATION = "somewhere";
            const int MINUTES_TILL_DISPOSAL = 120;
            const string DESTINATION = "toElseWhere";
            // IHitchhiker created by manager will be similar but instanciated a little later
            IHitchhiker almostHitchhikerThatShouldBeCreated = builder.BuildIHitchhiker(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);

            manager.Create(LOCATION, MINUTES_TILL_DISPOSAL, DESTINATION);
            IHitchhiker hitchhikerThatActuallyWasCreated = manager.Read().Where(h => h.GetLocation() == LOCATION).ToList()[0];

            Assert.IsTrue(TestHelpers.HitchhikersAreAlmostEqual(hitchhikerThatActuallyWasCreated, almostHitchhikerThatShouldBeCreated));
        }

        [TestMethod]
        public void Create_NonValidNewHitchhiker_NameTooLong_ExceptionIsThrown()
        {
            IBuilderOfIHitchhiker builder = new BuilderOfIHitchhiker();
            HitchhikerManager manager = new(builder);
            Assert.ThrowsException<ArgumentException>(() => manager.Create("Somewhere in a veeeery long and invalid spot", 10));
        }

        [TestMethod]
        public void Create_NonValidNewHitchhiker_NegativeMinutesTillDisposal_ExceptionIsThrown()
        {
            IBuilderOfIHitchhiker builder = new BuilderOfIHitchhiker();
            HitchhikerManager manager = new(builder);
            Assert.ThrowsException<ArgumentException>(() => manager.Create("Somewhere in a veeeery long and invalid spot", 10));
        }

        //Read
        [TestMethod]
        public void Read_CreatedEntriesShouldContainTheInsertedValuesOrDefault()
        {
            IBuilderOfIHitchhiker builder = new BuilderOfIHitchhiker();
            HitchhikerManager manager = new(builder);

            manager.Create("location1", 1, "destination1");
            manager.Create("location2", 2, "destination2");
            manager.Create("location3", 3);

            var list = manager.Read();
            bool check1 = false, check2 = false, check3 = false, check4 = false;

            foreach (Hitchhiker entry in list)
            {
                if (entry.GetLocation() == "location1" && entry.SouldBeDesposed() == false && entry.GetDestination() == "destination1")
                {
                    check1 = true;
                }
                if (entry.GetLocation() == "location2" && entry.SouldBeDesposed() == false && entry.GetDestination() == "destination2")
                {
                    check2 = true;
                }
                if (entry.GetLocation() == "location3" && entry.SouldBeDesposed() == false && entry.GetDestination() == "")
                {
                    check3 = true;
                }
                if (entry.GetLocation() == "location4" && entry.SouldBeDesposed() == false && entry.GetDestination() == "")
                {
                    // should not exist
                    check4 = true;
                }
            }

            Assert.IsTrue(check1);
            Assert.IsTrue(check2);
            Assert.IsTrue(check3);
            Assert.IsFalse(check4);
        }

        // DeleteAllExpired
        [TestMethod]
        public void DeleteAllExpired_SetTimeout_ExpiredShouldNotBeInList()
        {
            IBuilderOfIHitchhiker builder = new BuilderOfIHitchhiker();
            HitchhikerManager manager = new(builder);

            manager.Create("location1", 1 / 6000, "destination1");
            Console.WriteLine(manager.Read().Count());
            Assert.IsTrue(manager.Read().Count > 0);

            Thread.Sleep(500);

            manager.DeleteAllExpired();
            Assert.IsTrue(manager.Read().Count == 0);
        }

        [TestMethod]
        public void DeleteAllExpired_SetTimeout_NotExpiredShouldBeInList()
        {
            IBuilderOfIHitchhiker builder = new BuilderOfIHitchhiker();
            HitchhikerManager manager = new(builder);

            manager.Create("location1", 1, "destination1");
            Assert.IsTrue(manager.Read().Count > 0);

            Thread.Sleep(500);

            manager.DeleteAllExpired();
            Console.WriteLine(manager.Read().Count());
            Assert.IsTrue(manager.Read().Count == 1);
        }
    }
}