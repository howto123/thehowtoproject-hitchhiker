using Hitchhicker_Endpoint_V1.Entities;

namespace Hitchhicker_Endpoint_V1.Services.BuilderOfIHitchhiker
{
    public interface IBuilderOfIHitchhiker
    {
        IHitchhiker BuildIHitchhiker(string location, double minutesTillDisposal, string destination = "");
    }
}