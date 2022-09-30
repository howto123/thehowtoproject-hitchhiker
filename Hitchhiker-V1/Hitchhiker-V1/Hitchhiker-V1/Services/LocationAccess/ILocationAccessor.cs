using Xamarin.Essentials;

namespace Services.LocationAccess
{
    /// <summary>
    /// This interface is responsible for accessing the systems location
    /// </summary>
    public interface ILocationAccessor
    {
        Location GetLocation();
        void UpdateLocation();
    }
}