using System;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Essentials;

namespace Services.LocationAccess
{
    public class LocationAccessor
    {
        // Public constructor
        public LocationAccessor()
        {
            // empty for now
        }

        public static async Task<LocationAccessor> CreateAsync()
        {
            return new LocationAccessor(await GetCurrentLocation());
        }

        // Public Methods
        public Location GetLocation()
        {
            return Location;
        }

        public void UpdateLocation()
        {
            Task.Run(UpdateLocationAsync);
        }

        // Private poperties
        private Location Location { get; set; }

        // Private constructor
        private LocationAccessor(Location location)
        {
            Location = location;
        }

        // Private methods
        private async void UpdateLocationAsync()
        {
            Location = await GetCurrentLocation();
        }

        private static async Task<Location> GetCurrentLocation()
        {
            // Private attribute
            CancellationTokenSource cts;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    return location;
                }
                return null;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine(fnsEx);
                return null;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                Console.WriteLine(fneEx);
                return null;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine(pEx);
                return null;
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
