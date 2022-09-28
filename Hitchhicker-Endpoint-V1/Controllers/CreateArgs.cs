namespace Hitchhicker_Endpoint_V1.Controllers
{
    public class CreateArgs : object
    {
        public string? Location { get; set; }
        public int? MinutesTillDisposal { get; set; }
        public string? Destination { get; set; }
    }
}
