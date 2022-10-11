using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hitchhiker_V1.Models;
using System.Text;
using System.Text.Json;

namespace Services.Http
{
    // singleton
    public class HttpManager : IHttpManager
    {
        // private attribute
        private HttpClient client;
        private readonly Uri uri;
        public HttpManager()
        {
            try
            {
                this.uri = new Uri(Environment.GetEnvironmentVariable("hitchhikerUri"));
            }
            catch
            {
                throw new Exception("Defauilt constructor; hitchhikerUri not defined in env");
            }

            this.client = new HttpClient();
        }
        public HttpManager(Uri uri=null, HttpClient client=null)
        {
            if (uri != null)
            {
                this.uri = uri;
            }
            else
            {
                try
                {
                    this.uri = new Uri(Environment.GetEnvironmentVariable("hitchhikerUri"));
                }
                catch
                {
                    throw new Exception("Neigther environment nor constructor arg specify uri");
                }
            }

            this.client = client ?? new HttpClient();
        }

        public async Task<string> AddHitchhiker(Hitchhiker hitchhiker)
        {
            PostArgs toBePosted = new PostArgs()
            {
                Location = hitchhiker.Location.Longitude.ToString(),
                Destination = hitchhiker.Destination,
                MinutesTillDisposal = 2
            };

        HttpContent jsonContent = new StringContent(JsonSerializer.Serialize(
                    toBePosted
                ),
                Encoding.UTF8,
                "application/json");

            //Console.WriteLine(jsonContent.Headers);
            //Console.WriteLine(jsonContent.ReadAsStringAsync().Result);
            try
            {
                var response = await client.PostAsync("http://localhost:5090/hitchhikers", jsonContent);
                Console.WriteLine($"Post request done: {response.Content.ReadAsStringAsync().Result}");
            }
            catch (Exception err)
            {
                Console.WriteLine("Post Request failed :(");
                Console.WriteLine(err);
                Console.WriteLine(err.Message);
            }
            return "nothing to say";
        }

        public async Task<Hitchhiker[]> GetAllHitchhikers()
        {
            Hitchhiker[] hitchhikers = new Hitchhiker[0];

            try
            {
                var response = await client.GetAsync("http://localhost:5090/hitchhikers");
                Console.WriteLine("Get Request successful");
                
                string someString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(someString);
                hitchhikers = Newtonsoft.Json.JsonConvert.DeserializeObject<Hitchhiker[]>(someString);

            }
            catch (Exception err)
            {
                Console.WriteLine("Get Request failed :(");
                Console.WriteLine(err);
                Console.WriteLine(err.Message);
            }

            return hitchhikers;
        }
    }

    public class PostArgs : object
    {
        public string Location { get; set; }
        public double MinutesTillDisposal { get; set; }
        public string Destination { get; set; }
    }
}
