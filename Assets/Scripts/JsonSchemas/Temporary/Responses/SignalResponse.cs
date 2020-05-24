using System;


namespace JsonSchemas.Responses
{
    [Serializable]
    public class ResponseSignal
    {
        public string success = null;
        public string error = null;
        public string type = null;
        public string data = null;
    }
}