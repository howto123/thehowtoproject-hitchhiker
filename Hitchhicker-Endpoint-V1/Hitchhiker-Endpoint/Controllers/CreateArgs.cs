﻿namespace Hitchhicker_Endpoint.Controllers
{
    public class CreateArgs : object
    {
        public string? Location { get; set; }
        public int? MinutesTillDisposal { get; set; }
        public string? Destination { get; set; }
    }
}