using Hitchhiker_V1.Models;
using Services.Http;

namespace Hitchhiker_V1.Tests
{
    public class HttpManagerTest
    {
        private HttpManager _sut;
        [SetUp]
        public void SetUp()
        {
            var uri = new Uri("https://postman-echo.com/get");
            _sut = new HttpManager(uri);
        }
        [Test]
        public void Constructor_Works()
        {
            Assert.IsInstanceOf<HttpManager>(_sut);
        }

        [Test]
        public async Task GetAllHitchhikers_ReturnsListOfHitchhikers()
        {
            // Arrange, act
            var hitchhikers = await _sut.GetAllHitchhikers();
            Console.Write($"GetAllHitchhikers returns: {hitchhikers}");

            // Assert
            Assert.IsNotNull(hitchhikers);
            Assert.IsInstanceOf<Hitchhiker[]>(hitchhikers);
        }

        [Test]
        [Ignore("Backend not online yet")]
        public async Task AddHitchhiker_WithValidArgs_DeserializesCorrectly()
        {
            Assert.Fail();
        }
    }
}
