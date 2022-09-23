using Hitchhicker_Endpoint_V1.Entities;

namespace Hitchhicker_Endpoint_V1.Services
{
    public class HitchhikerManager
    {
        private static HitchhikerManager? _instance;
        private IEnumerable<Hitchhiker> _hitchhikers;

        private HitchhikerManager()
        {
            _hitchhikers = new List<Hitchhiker>();
        }

        public static HitchhikerManager GetInstance()
        {
            _instance ??= new HitchhikerManager();
            return _instance;
        }


    }
}
