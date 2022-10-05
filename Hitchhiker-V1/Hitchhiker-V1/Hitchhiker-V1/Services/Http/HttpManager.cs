using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hitchhiker_V1.Models;

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

        public string AddHitchhiker(Hitchhiker hitchhiker)
        {
            Console.WriteLine("HttpManager: AddHitchhiker() called.");
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
                Console.WriteLine(err.Message);
            }

            return Hitchhikers;
        }
    }
}
