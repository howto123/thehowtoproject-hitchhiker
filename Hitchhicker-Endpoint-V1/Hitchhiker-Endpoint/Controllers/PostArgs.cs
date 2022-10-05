namespace Hitchhicker_Endpoint.Controllers
{
    /// <summary>
    /// Incomming type. Frontend posts these fields
    /// </summary>
    public class PostArgs : object
    {
        public string? Location { get; set; }
        public double? MinutesTillDisposal { get; set; }
        public string? Destination { get; set; }
    }
}
