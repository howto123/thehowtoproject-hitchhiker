using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;

namespace Services.MapsAccess
{
    public interface IMapsManager
    {
        void setPoints(List<Location> pointsToSet);

    }
}