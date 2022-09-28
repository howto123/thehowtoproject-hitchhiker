namespace Hitchhicker_Endpoint_V1.Entities
{
    public interface IHitchhiker
    {
        string GetDestination();
        string GetLocation();
        bool SouldBeDesposed();
    }
}