using Hitchhicker_Endpoint.Entities;

namespace Hitchhicker_Endpoint.Services.Builder
{
    public interface IBuilderOfIHitchhiker
    {
        IHitchhiker BuildIHitchhiker(string location, double minutesTillDisposal, string? destination=null);
    }
}