using Hitchhicker_Endpoint.Entities;

namespace Hitchhicker_Endpoint.Services.Builder
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
