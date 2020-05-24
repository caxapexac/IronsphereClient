using System;
using System.Collections.Generic;
using JsonSchemas.Small;


namespace JsonSchemas.ResponsesInner
{
    [Serializable]
    public class GetInfoSignal
    {
        public string status;
        public int players_online;
        public Dictionary<int, SessionInfo> sessions;
    }
}