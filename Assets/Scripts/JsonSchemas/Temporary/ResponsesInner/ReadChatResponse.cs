using System;
using System.Collections.Generic;
using JsonSchemas.Small;


namespace JsonSchemas.ResponsesInner
{
    [Serializable]
    public class ReadChatResponse
    {
        public List<ChatMessage> chat_buffer;
    }
}