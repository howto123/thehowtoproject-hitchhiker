using Hitchhiker_V1.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Services.Http
{
    /// <summary>
    /// This interface is responsible communicating with the backend.
    /// </summary>
    public interface IHttpManager
    {
        Task<string> AddHitchhiker(Hitchhiker hitchhiker);
        Task<Hitchhiker[]> GetAllHitchhikers();
    }
}