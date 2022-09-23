using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Hitchhicker_Endpoint_V1.Controllers
{
    /* https://localhost:7090; I copied this out of launchSettings.json */

    [ApiController]
    public class HitchhikerController : Controller
    {

        [Route("hitchhiker")]
        [Route("hitchhiker/index")]
        [HttpGet]
        public String Index()
        {
            return "Hello";
        }
        
        [Route("/hitchhiker/all")]
        //[HttpGet(Name = "all")]
        [HttpGet]
        public string GetAll()
        {
            return "getAll was called";
        }
        
        [Route("hitchhiker/{arg?}")]
        // use like this: http://localhost:5090/hitchhiker/myArg
        [HttpGet]
        public string GetOne(string arg)
        {
            return $"The argument was {arg}";
        }

        [Route("hitchhiker/")]
        [HttpPost]
        public string Create(JsonObject request)
        {
            return $"Create was called: {request?.ToString()}";
        }

    }
}
