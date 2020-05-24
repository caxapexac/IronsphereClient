using JsonKnownTypes;
using MonoBehaviours;
using Newtonsoft.Json;


namespace JsonSchemas
{
    [JsonConverter(typeof(JsonKnownTypesConverter<j_typed>))]
    public class j_typed
    {
        public int version = Constants.version;
    }
}