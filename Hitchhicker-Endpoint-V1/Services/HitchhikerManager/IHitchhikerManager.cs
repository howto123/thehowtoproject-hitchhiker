using Hitchhicker_Endpoint_V1.Entities;

namespace Hitchhicker_Endpoint_V1.Services.HitchhikerManager
{
    /// <summary>
    ///  Contains the logic to do anything related to hitchhikers.
    /// </summary>
    public interface IHitchhikerManager
    {
        /// <summary>
        ///  Adds a hitchhiker entity to hitchhikers if the args are valid, throws argument error otherwise
        /// </summary>
        void Create(string location, double minutesTillDisposal, string destination = "");

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