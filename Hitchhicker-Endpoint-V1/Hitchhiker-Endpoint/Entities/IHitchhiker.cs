namespace Hitchhicker_Endpoint.Entities
{
    public interface IHitchhiker
    {
        string GetDestination();
        string GetLocation();
        bool ShouldBeDesposed();
    }
}