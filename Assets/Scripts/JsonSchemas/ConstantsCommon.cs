using System;
using JsonKnownTypes;
using MonoBehaviours;
using Newtonsoft.Json;


namespace JsonSchemas
{
    [JsonConverter(typeof(JsonKnownTypesConverter<j_typed>))]
    public class j_typed
    {

        protected j_typed()
        {
            
        }

        public virtual void Execute()
        {
            throw new NotImplementedException(GetType() + "executing");
        }
    }
}