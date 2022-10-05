namespace Hitchhicker_Endpoint.Controllers
{
    /// <summary>
    /// Outgoing type: frontend receives these fields in GET response
    /// </summary>
    public class LocationDestination
    {
        public string? Location;
        public string? Destination;

        //LocationDest REVIEWER: too long? road/route better?
        public LocationDestination(string? location, string? destination)
        {
            Location = location;
            Destination = destination;
        }
    }
}
