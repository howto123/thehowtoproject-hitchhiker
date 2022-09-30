using System.Collections.Generic;
using Xamarin.Essentials;

namespace Services.MapsAccess
{
    public interface IMapsManager
    {
        void setPoints(List<Location> pointsToSet);
    }
}