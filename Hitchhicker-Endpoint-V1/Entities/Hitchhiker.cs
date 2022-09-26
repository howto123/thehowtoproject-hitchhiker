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
            if(!AreValidArgs(location, minutesTillDisposal, destination))
            {
                throw new ArgumentException("Hitchhiker could not be created as the arguments were invalid.");
            }

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
        public override string ToString()
        {
            return $"Hitchhiker is: {_location}, {_timeOfDisposal}, {_destination}";
        }
        private bool AreValidArgs(string location, double minutesTillDisposal, string destination)
        {
            // location
            if (!IsValidLocation(location)) return false;

            // minutesTillDisposal
            if (minutesTillDisposal < -10) return false;
            if (minutesTillDisposal > 120) return false;

            // destination
            if (destination == null) return false;
            if (destination.Length > 20) return false;

            return true;
        }

        private bool TimeIsUp()
        {
            return _timeOfDisposal.Subtract(DateTime.UtcNow) <= TimeSpan.Zero;
        }

        private bool IsValidLocation(string location)
        {
            // This will be more elaborated, possibly even another type...
            if (location.Length > 20) return false;
            return true;
        }
    }

}
