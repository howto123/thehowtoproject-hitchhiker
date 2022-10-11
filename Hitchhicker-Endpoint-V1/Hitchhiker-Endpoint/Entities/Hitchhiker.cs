namespace Hitchhicker_Endpoint.Entities
{
    public class Hitchhiker : IHitchhiker
    {
        private readonly string _location;
        private readonly string _destination;
        private readonly DateTime _timeOfDisposal;
        public Hitchhiker(string location, double minutesTillDisposal, string destination = "")
        {
            Console.WriteLine($"location: {location}, minutes: {minutesTillDisposal}, destination: {destination}");
            if (!AreValidArgs(location, minutesTillDisposal, destination))
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

        public bool ShouldBeDesposed()
        {
            return TimeIsUp();
        }

        private bool AreValidArgs(string location, double minutesTillDisposal, string destination)
        {
            const int MAX_DESTINATION_LENGTH = 20;
            const int Min_MIN_TILL_DISPOSAL = 0;
            const int MAX_MIN_TILL_DISPOSAL = 120;

            if (!IsValidLocation(location)) return false;

            if (minutesTillDisposal < Min_MIN_TILL_DISPOSAL) return false;
            if (minutesTillDisposal > MAX_MIN_TILL_DISPOSAL) return false;

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
