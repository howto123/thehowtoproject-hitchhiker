using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hitchhiker_V1.Models;
using System.Text;
using System.Text.Json;

namespace Services.Http
{
    public class HttpManager : IHttpManager
    {
        //
        // use _uri property instead of hardcoded link. set it in startup file
        //
        // change signature of POST? -> REVIEWER
        //
        // put PostArgs class in its own file
        //

        private HttpClient _client;
        private readonly Uri _uri;
        public HttpManager()
        {
            try
            {
                this._uri = new Uri(Environment.GetEnvironmentVariable("hitchhikerUri"));
            }
            catch
            {
                throw new Exception("Defauilt constructor; hitchhikerUri not defined in env");
            }

            this._client = new HttpClient();
        }
        public HttpManager(Uri uri=null, HttpClient _client=null)
        {
            if (uri != null)
            {
                this._uri = uri;
            }
            else
            {
                try
                {
                    this._uri = new Uri(Environment.GetEnvironmentVariable("hitchhikerUri"));
                }
                catch
                {
                    throw new Exception("Neigther environment nor constructor arg specify _uri");
                }
            }

            this._client = _client ?? new HttpClient();
        }

        public async Task<string> AddHitchhiker(Hitchhiker hitchhiker)
        {
            PostArgs toBePosted = new PostArgs()
            {
                Location = hitchhiker.Location.Longitude.ToString(),
                Destination = hitchhiker.Destination,
                MinutesTillDisposal = 2
            };

            HttpContent jsonContent = new StringContent(
                JsonSerializer.Serialize(toBePosted),
                Encoding.UTF8,
                "application/json"
                );

            try
            {
                var response = await _client.PostAsync("http://localhost:5090/hitchhikers", jsonContent);
            }
            catch (Exception err)
            {
                Console.WriteLine($"Post request failed: {err.Message}");
            }

            return "AddHitchhiker completed";
        }

        public async Task<Hitchhiker[]> GetAllHitchhikers()
        {
            Hitchhiker[] hitchhikers = new Hitchhiker[0];

            try
            {
                var response = await _client.GetAsync("http://localhost:5090/hitchhikers");
                string json = await response.Content.ReadAsStringAsync();
                hitchhikers = Newtonsoft.Json.JsonConvert.DeserializeObject<Hitchhiker[]>(json);

            }
            catch (Exception err)
            {
                Console.WriteLine($"Get request failed: {err.Message}");
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
