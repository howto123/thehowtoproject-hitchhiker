﻿namespace Hitchhicker_Endpoint.Controllers
{
    public class LocationDestination
    {
        public string? Location;
        public string? Destination;

        public LocationDestination(string? location, string? destination)
        {
            Location = location;
            Destination = destination;
        }
    }
}