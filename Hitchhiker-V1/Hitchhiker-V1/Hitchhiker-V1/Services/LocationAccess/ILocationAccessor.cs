using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Services.LocationAccess
{
    /// <summary>
    /// This interface is responsible for accessing the systems location
    /// </summary>
    public interface ILocationAccessor
    {
        Task<Location> GetLocation();
    }
}