using System;


namespace JsonSchemas.Small
{
    [Serializable]
    public class ChatMessage
    {
        public int player_uid;
        public string message;
    }
}