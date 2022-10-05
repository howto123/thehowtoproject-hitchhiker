using Services.LocationAccess;
using Xamarin.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitchhiker_V1.Tests
{
    public  class LocationAccessorTest
    {
        private LocationAccessor _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new LocationAccessor();
        }
        [Test]
        [Ignore("Location only accessible inside emulator or on real device")]
        public async Task GetLocation_ReturnsLocationAsync()
        {
            // Arrance, Act
            var returned = await _sut.GetLocation();
            Console.WriteLine($"returned is: {returned}");

            // Assert
            Assert.NotNull(returned);
            Assert.IsInstanceOf<Location>(returned);
        }
    }
}
