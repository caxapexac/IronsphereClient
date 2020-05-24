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

        public static void TestNetwork()
        {
            string d = JsonConvert.SerializeObject(new chat_message(){message = "abc"}, Converter);
            Debug.Log(d);
            j_typed typed = JsonConvert.DeserializeObject<j_typed>(d, Converter);
            Debug.Log(JsonConvert.SerializeObject(typed, Converter));
            Debug.Log(typed.GetType());
        }
    }
}