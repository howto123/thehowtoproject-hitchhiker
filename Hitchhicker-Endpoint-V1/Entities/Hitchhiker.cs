using Microsoft.AspNetCore.Components.Routing;
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

        private bool TimeIsUp()
        {
            return _timeOfDisposal.Subtract(DateTime.UtcNow) <= TimeSpan.Zero;
        }
    }

}
