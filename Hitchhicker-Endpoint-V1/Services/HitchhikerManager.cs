using Hitchhicker_Endpoint_V1.Entities;

namespace Hitchhicker_Endpoint_V1.Services
{
    public class HitchhikerManager
    {
        private static HitchhikerManager? _instance;
        private List<Hitchhiker> _hitchhikers;

        private HitchhikerManager()
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
                this._hitchhikers.Add(hitchhiker);
            } catch (Exception e)
            {
                Console.WriteLine($"Error in Manager.Add(): {e.Message}");
                throw;
            }
        }
        
        public List<Hitchhiker> Read()
        {
            return this._hitchhikers;
        }

        public void DeleteAllExpired()
        {
            try
            {
                this._hitchhikers = this._hitchhikers.FindAll(e => !e.SouldBeDesposed());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in Manager.deleteAllExpired(): {e.Message}");
            }
        }
    }
}
