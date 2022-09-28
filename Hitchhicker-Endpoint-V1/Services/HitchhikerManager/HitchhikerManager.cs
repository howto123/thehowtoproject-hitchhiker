using System.Diagnostics;
using Hitchhicker_Endpoint_V1.Entities;
using Hitchhicker_Endpoint_V1.Services.BuilderOfIHitchhiker;

namespace Hitchhicker_Endpoint_V1.Services.HitchhikerManager
{
    public class HitchhikerManager : IHitchhikerManager
    {
        private List<IHitchhiker> _hitchhikers;
        private IBuilderOfIHitchhiker _builder;

        public HitchhikerManager(IBuilderOfIHitchhiker builder)
        {
            _hitchhikers = new List<IHitchhiker>();
            _builder = builder;
        }

        public void Create(string location, double minutesTillDisposal, string? destination = null)
        {
            try
            {
                IHitchhiker hitchhiker = _builder.BuildIHitchhiker(location, minutesTillDisposal, destination);
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

        public List<IHitchhiker> Read()
        {
            Console.WriteLine("Read() called");
            Console.WriteLine(_hitchhikers.Count);
            return _hitchhikers;
        }
    }
}
