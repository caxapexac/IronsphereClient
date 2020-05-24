using JsonKnownTypes;
using JsonSchemas;
using Newtonsoft.Json;
using UnityEngine;


namespace MonoBehaviours
{
    public static class JsonManager
    {
        public static JsonKnownTypesConverter<j_typed> Converter = new JsonKnownTypesConverter<j_typed>();
        
        static JsonManager()
        {
            JsonKnownTypesSettingsManager.DefaultDiscriminatorSettings = new JsonDiscriminatorSettings()
            {
                DiscriminatorFieldName = "type",
                UseClassNameAsDiscriminator = true
            };
            
        }

        public static string Serialize(j_typed typed)
        {
            return JsonConvert.SerializeObject(typed, Converter);
        }

        public static j_typed Deserialize(string package)
        {
            return JsonConvert.DeserializeObject<j_typed>(package);
        }
    }
}