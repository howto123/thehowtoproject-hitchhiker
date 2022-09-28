
using Hitchhicker_Endpoint_V1.Services.HitchhikerManager;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hitchhicker_Endpoint_V1.Helpers;

namespace Hitchhicker_Endpoint_V1.Controllers
{
    [ApiController]
    public class HitchhikerController : Controller
    {
        private readonly IHitchhikerManager _manager;

        public HitchhikerController(IHitchhikerManager manager)
        {
            _manager = manager;
        }
        
        [Route("hitchhikers/")]
        [HttpGet]
        public string GetAll()
        {
            {
                var responseList = new List<LocationDestination>();

                try
                {
                    var listFromManager = _manager.Read();
                    Console.WriteLine("Read them all:");
                    listFromManager.ForEach(e =>
                    {
                        LocationDestination newOne = new(e.GetLocation(), e.GetDestination());
                        responseList.Add(newOne);
                    });
                }
                catch (Exception e)
                { 
                    Debug.WriteLine($"{e.Message}");
                    responseList.Clear();
                }

                return HitchhikerHelper.MakeJSON(responseList);
            }
        }

        [Route("hitchhikers/")]
        [HttpPost]
        public object Create(CreateArgs args)
        {
            try
            {
                string? location = args.Location;
                int? minutesTillDisposal = args.MinutesTillDisposal;
                string? destination = args.Destination;

                if (location != null && minutesTillDisposal != null)
                {
                    _manager.Create(location, (int) minutesTillDisposal, destination??"");
                    return $"Hitchhiker created()";
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
            }

            return "Sorry, there was a problem";
        }        
    }
}


