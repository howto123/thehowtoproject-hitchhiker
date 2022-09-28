using Microsoft.AspNetCore.Components.Routing;
using System.Diagnostics;
using System.Transactions;

namespace Hitchhicker_Endpoint_V1.Entities
{
    public class Hitchhiker
    {
        private string _location;
        private string _destination;
        private DateTime _timeOfDisposal;

        public Hitchhiker(string location, double minutesTillDisposal, string destination="")
        {
            // validation
            if(!AreValidArgs(location, minutesTillDisposal, destination))
            {
                throw new ArgumentException("Hitchhiker could not be created as the arguments were invalid.");
            }

            // initialisation
            _location = location;
            _timeOfDisposal = DateTime.UtcNow.AddMinutes(minutesTillDisposal);
            _destination = destination;
        }

        public string GetLocation()
        {
            return _location;
        }

        public string GetDestination()
        {
            return _destination;
        }

        public bool SouldBeDesposed()
        {
            return TimeIsUp();
        }

        private bool AreValidArgs(string location, double minutesTillDisposal, string destination)
        {
            // Settings
            const int MAX_DESTINATION_LENGTH = 20;
            const int Min_MIN_TILL_DISPOSAL = 0;
            const int MAX_MIN_TILL_DISPOSAL = 120;  

            // location
            if (!IsValidLocation(location)) return false;

            // minutesTillDisposal
            if (minutesTillDisposal < Min_MIN_TILL_DISPOSAL) return false;
            if (minutesTillDisposal > MAX_MIN_TILL_DISPOSAL) return false;

            // destination
            if (destination == null) return false;
            if (destination.Length > MAX_DESTINATION_LENGTH) return false;

            return true;
        }

        private bool TimeIsUp()
        {
            return _timeOfDisposal.Subtract(DateTime.UtcNow) <= TimeSpan.Zero;
        }

        private bool IsValidLocation(string location)
        {
            // This will be more elaborated, possibly even another type...
            const int MAX_LOCATION_LENGTH = 20;

            if (location.Length > MAX_LOCATION_LENGTH) return false;

            return true;
        }
    }
}
