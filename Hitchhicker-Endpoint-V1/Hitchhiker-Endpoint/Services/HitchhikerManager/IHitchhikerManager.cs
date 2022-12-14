using Hitchhicker_Endpoint.Entities;

namespace Hitchhicker_Endpoint.Services.HitchhikerManager
{
    /// <summary>
    ///  Contains logic to deal with hitchhikers.
    /// </summary>
    public interface IHitchhikerManager
    {
        /// <summary>
        ///  Adds a hitchhiker entity to hitchhikers if the args are valid, throws argument error otherwise
        /// </summary>
        void Create(string location, double minutesTillDisposal, string? destination = null);

        /// <summary>
        ///  Deletes hitchhikers that should not be contained in hitchhikers anymore
        /// </summary>
        void DeleteAllExpired();

        /// <summary>
        ///  Gives back all hitchhikers
        /// </summary>
        List<IHitchhiker> Read();
    }
}