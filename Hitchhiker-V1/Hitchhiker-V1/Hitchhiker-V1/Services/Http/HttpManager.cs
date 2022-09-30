using System;
using System.Net.Http;
using System.Threading.Tasks;
using Hitchhiker_V1.Models;

namespace Services.Http
{
    // singleton
    public class HttpManager : IHttpManager
    {
        // Public property


        // Public methods
        public string AddHitchhiker(Hitchhiker hitchhiker)
        {
            return "method not implemented yet...";
        }

        public async Task<Hitchhiker[]> GetAllHitchhikers()
        {
            Hitchhiker[] Hitchhikers = new Hitchhiker[0];

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                Console.WriteLine("response:");
                Console.WriteLine(response);
                Console.WriteLine("StatusCode");
                Console.WriteLine(response.IsSuccessStatusCode);

                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                //Hitchhikers = JsonSerializer.Deserialize<List<Hitchhiker>>(content);

            }
            catch (Exception err)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(err.Message);
            }

            return Hitchhikers;
        }

        /*
        //possibly an improvement?
        public Hitchhiker[] GetFilteredHitchhikers(Filter filter)
        {
            // ...
        }
        */

        public static HttpManager GetInstance()
        {
            if (instance == null)
            {
                instance = new HttpManager();
            }
            return instance;
        }

        // private attribute
        private static HttpManager instance = null;
        private HttpClient client = new HttpClient();
        private readonly Uri uri = new Uri("https://postman-echo.com/get");


        // private constructor
        public HttpManager() { /* empty */ }
    }
}
