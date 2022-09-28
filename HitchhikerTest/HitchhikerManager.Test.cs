using Hitchhicker_Endpoint_V1;
using Hitchhicker_Endpoint_V1.Entities;
using Hitchhicker_Endpoint_V1.Services;

namespace HitchhikerTest
{
    [TestClass]
    public class HitchhikerManagerTest
    {
        // Create
        [TestMethod]
        public void Create_ValidNewHitchhikerWithoutLocation_ReadContainsNewHitchhiker()
        {
            Hitchhiker hitchhikerThatShouldBeCreated = new("hSomewhere", 10);

            HitchhikerManager manager = new();
            manager.Create("hSomewhere", 10);
            Hitchhiker hitchhikerThatActuallyWasCreated = manager.Read().Where(h => h.GetLocation() == "hSomewhere").ToList()[0];

            Assert.AreEqual(hitchhikerThatActuallyWasCreated.GetDestination(), hitchhikerThatShouldBeCreated.GetDestination());
            Assert.AreEqual(hitchhikerThatActuallyWasCreated.GetLocation(), hitchhikerThatShouldBeCreated.GetLocation());
            Assert.AreEqual(hitchhikerThatActuallyWasCreated.SouldBeDesposed(), hitchhikerThatShouldBeCreated.SouldBeDesposed());
        }
        /*
        [TestMethod]
        public void Create_ValidNewHitchhikerWitchLocation_ReadContainsNewHitchhiker()
        {
            Hitchhiker hitchhikerThatShouldBeCreated = new("hSomewhere", 10);

            HitchhikerManager manager = new();
            manager.Create("hSomewhere", 10, "toElseWhere");
            Hitchhiker hitchhikerThatActuallyWasCreated = manager.Read().Where(h => h.GetLocation() == "hSomewhere").ToList()[0];

            Assert.AreEqual(hitchhikerThatActuallyWasCreated.GetDestination(), hitchhikerThatShouldBeCreated.GetDestination());
            Assert.AreEqual(hitchhikerThatActuallyWasCreated.GetLocation(), hitchhikerThatShouldBeCreated.GetLocation());
            Assert.AreEqual(hitchhikerThatActuallyWasCreated.SouldBeDesposed(), hitchhikerThatShouldBeCreated.SouldBeDesposed());
        }
        */

        [TestMethod]
        public void Create_NonValidNewHitchhiker_NameTooLong_ExceptionIsThrown()
        {
            HitchhikerManager manager = new();
            Assert.ThrowsException<ArgumentException>(() => manager.Create("Somewhere in a veeeery long and invalid spot", 10));
        }

        [TestMethod]
        public void Create_NonValidNewHitchhiker_NegativeMinutesTillDisposal_ExceptionIsThrown()
        {
            HitchhikerManager manager = new();
            Assert.ThrowsException<ArgumentException>(() => manager.Create("Somewhere in a veeeery long and invalid spot", 10));
        }

        //Read
        [TestMethod]
        public void Read_CreatedEntriesShouldContainTheInsertedValuesOrDefault()
        {
            HitchhikerManager manager = new();

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
            HitchhikerManager manager = new();

            manager.Create("location1", 1 / 6000, "destination1");
            Console.WriteLine(manager.Read().Count());
            Assert.IsTrue(manager.Read().Count > 0);

            System.Threading.Thread.Sleep(500);

            manager.DeleteAllExpired();
            Assert.IsTrue(manager.Read().Count == 0);
        }

        [TestMethod]
        public void DeleteAllExpired_SetTimeout_NotExpiredShouldBeInList()
        {
            HitchhikerManager manager = new();

            manager.Create("location1", 1, "destination1");
            Assert.IsTrue(manager.Read().Count > 0);

            System.Threading.Thread.Sleep(500);

            manager.DeleteAllExpired();
            Console.WriteLine(manager.Read().Count());
            Assert.IsTrue(manager.Read().Count == 1);
        }
    }
}
