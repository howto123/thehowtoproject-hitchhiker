using Hitchhiker_V1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Services.Http;
using Xamarin.Forms.Internals;

namespace Hitchhiker_V1.Tests
{
    public class HttpManagerTest
    {
        private HttpManager _sut;
        [SetUp]
        public void SetUp()
        {
            var uri = new Uri("localhost://5090/hitchhikers");
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
            Hitchhiker[] hitchhikers = await _sut.GetAllHitchhikers();
            Console.WriteLine($"Here we go: {hitchhikers.Length}");
            /*
            hitchhikers.ForEach(h =>
            {
                Console.Write($"GetAllHitchhikers returns: {h}");
            });
            */

            // Assert
            Assert.IsNotNull(hitchhikers);
            Assert.IsInstanceOf<Hitchhiker[]>(hitchhikers);
        }

        [Test]
        public async Task AddHitchhiker_WithValidArgs_DeserializesCorrectly()
        {
            Hitchhiker toBePosted = new Hitchhiker()
            {
                Location = new Xamarin.Essentials.Location(),
                Destination = "Got to work"
            };
            var json = JsonConvert.SerializeObject(
                       toBePosted, Formatting.Indented,
                       new Newtonsoft.Json.JsonConverter[]
                       {
                           new StringEnumConverter()
                       });
            //Console.WriteLine(json);
            await _sut.AddHitchhiker(toBePosted);
            //await _sut.GetAllHitchhikers();

            
        }
    }
}
