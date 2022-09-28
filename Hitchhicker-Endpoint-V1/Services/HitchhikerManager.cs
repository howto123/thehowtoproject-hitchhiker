using Hitchhicker_Endpoint_V1.Entities;
using System.Diagnostics;

namespace Hitchhicker_Endpoint_V1.Services
{
    public class HitchhikerManager
    {
        private static HitchhikerManager? _instance;
        private List<Hitchhiker> _hitchhikers;

        public HitchhikerManager()
        {
            _hitchhikers = new List<Hitchhiker>();
        }

        public static HitchhikerManager GetInstance()
        {
            _instance ??= new HitchhikerManager();
            return _instance;
        }

        public void Create(string location, double minutesTillDisposal, string destination = "")
        {
            try
            {
                Hitchhiker hitchhiker = new(location, minutesTillDisposal, destination);
                _hitchhikers.Add(hitchhiker);
            } catch (Exception e)
            {
                Console.WriteLine($"Error in Manager.Add(): {e.Message}");
                throw;
            }
        }
        
        public List<Hitchhiker> Read()
        {
            Console.WriteLine("Read() called");
            Console.WriteLine(_hitchhikers.Count);
            return _hitchhikers;
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

        public static void DeleteAll()
        {
            if(_instance!=null) _instance!._hitchhikers.Clear();
        }
    }
}
