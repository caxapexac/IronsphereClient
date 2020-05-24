using System;


namespace JsonSchemas.RequestsInner
{
    [Serializable]
    public class SessionRequest
    {
        public int session_id;
        public string method;
        public string payload;
    }
}