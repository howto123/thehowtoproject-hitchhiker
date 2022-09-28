using Hitchhicker_Endpoint_V1.Entities;

namespace Hitchhicker_Endpoint_V1.Services.BuilderOfIHitchhiker
{
    public class BuilderOfIHitchhiker : IBuilderOfIHitchhiker
    {
        public IHitchhiker BuildIHitchhiker(string location, double minutesTillDisposal, string? destination=null)
        {
            if (destination == null)
            { 
                return new Hitchhiker(location, minutesTillDisposal);
            } 
            return new Hitchhiker(location, minutesTillDisposal, destination);
        }
    }
}
