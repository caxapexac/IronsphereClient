using System;
using MonoBehaviours;
using UnityEngine;


namespace JsonSchemas.Requests
{
    /// <summary>
    /// Base class for almost all server requests
    /// </summary>
    [Serializable]
    public abstract class MessageSignal
    {
        public int version;
        public int sender;
        public string command;
        public string data;

        public MessageSignal(string command)
        {
            this.version = Constants.version;
            this.sender = PlayerPrefs.GetInt(IntPrefs.sender.ToString());
            this.command = command;
        }
    }
}