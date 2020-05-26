using System;
using JsonKnownTypes;
using MonoBehaviours;
using Newtonsoft.Json;


namespace JsonSchemas
{
    [JsonConverter(typeof(JsonKnownTypesConverter<j_typed>))]
    public class j_typed
    {
        public int version;

        protected j_typed()
        {
            version = Constants.Version;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException(GetType() + "executing");
        }
    }
}