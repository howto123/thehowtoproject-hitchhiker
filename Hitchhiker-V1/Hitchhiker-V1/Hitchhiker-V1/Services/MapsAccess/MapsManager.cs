using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;

namespace Services.MapsAccess
{
    public class MapsManager : IMapsManager
    {
        private List<Location> displayedPoints;
        public List<Location>  DisplayedPoints
        {
            get => displayedPoints;
            private set
            {
                if(value == displayedPoints)
                {
                    return;
                }
                displayedPoints = value;
                //OnPropertyChanged(nameof(DisplayedPoints));
            }
        }

        public MapsManager()
        {
            // initialize state
            DisplayedPoints = new List<Location>();
        }

        public void setPoints(List<Location> pointsToSet)
        {
            Console.WriteLine(pointsToSet);
        }
    }
}
