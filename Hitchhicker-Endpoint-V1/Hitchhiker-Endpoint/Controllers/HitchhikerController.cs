using Hitchhicker_Endpoint.Services.HitchhikerManager;
using Microsoft.AspNetCore.Mvc;
using Hitchhicker_Endpoint.Helpers;

namespace Hitchhicker_Endpoint.Controllers
{
    [ApiController]
    public class HitchhikerController : Controller
    {
        private readonly IHitchhikerManager _manager;

        // Constructor
        public HitchhikerController(IHitchhikerManager manager)
        {
            _manager = manager;
        }

        // Set up endpoints
        [HttpGet]
        [Route("hitchhikers/")]
        public string Get()
        {
            try
            {
                var hitchhikerList = _manager.Read();
                var responseList = HitchhikerHelper.MakeLocationDestinationList(hitchhikerList);

                return HitchhikerHelper.MakeJSON(responseList);
            }
            catch
            {
                return "Sorry, there was a problem";
            }
        }
        
        [HttpPost]
        [Route("hitchhikers/")]
        public object Post(PostArgs args)
        {
            try
            {
                // read args
                string? location = args.Location;
                double? minutesTillDisposal = args.MinutesTillDisposal;
                string? destination = args.Destination;

                // make call
                if (location != null && minutesTillDisposal != null)
                {
                    _manager.Create(location, (double) minutesTillDisposal, destination??null);
                    return $"Hitchhiker created()";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            return "Sorry, there was a problem";
        }        
    }
}


