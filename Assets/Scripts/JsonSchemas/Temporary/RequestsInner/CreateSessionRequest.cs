using System;
using JsonSchemas.Requests;


namespace JsonSchemas.RequestsInner
{
    [Serializable]
    public class CreateSessionSignal
    {
        public int session_id;
        public string session_name;
        
        public CreateSessionSignal(string command)
        {
        }
    }
}