using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Hitchhicker_Endpoint_V1.Helpers
{
    public class HitchhikerHelper
    {
        public static string MakeJSON(object toBeConverted)
        {
            return JsonConvert.SerializeObject(
                       toBeConverted, Formatting.Indented,
                       new Newtonsoft.Json.JsonConverter[] { new StringEnumConverter() });
        }
    }
}