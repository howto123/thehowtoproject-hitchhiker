using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Services.MapsAccess
{
    public class MapsManager : IMapsManager
    {
        private List<Location> displayedPoints;
        public MapsManager()
        {
            // initialize state
            displayedPoints = new List<Location>();
        }

        public void setPoints(List<Location> pointsToSet)
        {
            Console.WriteLine(pointsToSet);
        }
    }
}
