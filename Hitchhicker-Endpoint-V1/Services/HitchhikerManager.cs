using Hitchhicker_Endpoint_V1.Entities;
using System.Diagnostics;

namespace Hitchhicker_Endpoint_V1.Services
{
    public class HitchhikerManager : IHitchhikerManager
    {
        private List<Hitchhiker> _hitchhikers;

        public HitchhikerManager()
        {
            _hitchhikers = new List<Hitchhiker>();
        }

        public void Create(string location, double minutesTillDisposal, string destination = "")
        {
            try
            {
                Hitchhiker hitchhiker = new(location, minutesTillDisposal, destination);
                _hitchhikers.Add(hitchhiker);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in Manager.Add(): {e.Message}");
                throw;
            }
        }

        public void DeleteAllExpired()
        {
            try
            {
                _hitchhikers = _hitchhikers.FindAll(e => !e.SouldBeDesposed());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in Manager.deleteAllExpired(): {e.Message}");
            }
        }

        public List<Hitchhiker> Read()
        {
            Console.WriteLine("Read() called");
            Console.WriteLine(_hitchhikers.Count);
            return _hitchhikers;
        }
    }
}
