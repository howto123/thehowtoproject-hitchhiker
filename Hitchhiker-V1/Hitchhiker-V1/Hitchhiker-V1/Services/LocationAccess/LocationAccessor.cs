using System;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Essentials;

namespace Services.LocationAccess
{
    public class LocationAccessor : ILocationAccessor
    {
        public Task<Location> GetLocation()
        {
            return GetCurrentLocation();
        }

        private static async Task<Location> GetCurrentLocation()
        {
            CancellationTokenSource cts;

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    return location;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
