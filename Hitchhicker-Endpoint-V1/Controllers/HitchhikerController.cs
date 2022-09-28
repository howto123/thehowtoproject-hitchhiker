using Hitchhicker_Endpoint_V1.Services.HitchhikerManager;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

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
        
        [Route("/hitchhiker/")]
        [HttpGet]
        public string GetAll()
        {
            {
                try
                {
                    return JsonConvert.SerializeObject(_manager.Read().ToArray().ToString());
                }
                catch (Exception e)
                { 
                    Debug.WriteLine($"{e.Message}");
                }

                return "Sorry, there was a problem";
            }
        }

        [Route("hitchhiker/")]
        [HttpPost]
        public string Create(CreateArgs request)
        {
            try
            {
                if (request.Location != null && request.MinutesTillDisposal != null)
                {
                    _manager.Create(request.Location, (int)request.MinutesTillDisposal, request.Destination??"");
                    Debug.WriteLine($"Read: {_manager.Read().Count}");
                    return $"Hitchhiker created()";
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
            }

            return "Sorry, there was a problem";
        }

        public class CreateArgs: Object
        {
            public string? Location { get; set; }
            public int? MinutesTillDisposal { get; set; }
            public string? Destination { get; set; }
        }
    }
}


