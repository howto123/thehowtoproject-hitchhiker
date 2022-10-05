using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Hitchhicker_Endpoint.Controllers;
using Hitchhicker_Endpoint.Entities;

namespace Hitchhicker_Endpoint.Helpers
{
    public class HitchhikerHelper
    {
        public static string MakeJSON(object toBeConverted)
        {
            return JsonConvert.SerializeObject(
                       toBeConverted, Formatting.Indented,
                       new Newtonsoft.Json.JsonConverter[]
                       {
                           new StringEnumConverter()
                       });
        }

        // REVIEWER: hiker anstatt hitchhhiker? sind die Namen zu lang?
        public static List<LocationDestination> MakeLocationDestinationList(List<IHitchhiker> hitchhikerList)
        {
            var returnedList = new List<LocationDestination>();

            try
            {
                hitchhikerList.ForEach(e =>
                {
                    LocationDestination newOne = new(e.GetLocation(), e.GetDestination());
                    returnedList.Add(newOne);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                returnedList.Clear();
            }

            return returnedList;
        }
    }
}