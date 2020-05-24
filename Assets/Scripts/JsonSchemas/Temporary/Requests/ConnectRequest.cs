using System;
using MonoBehaviours;
using UnityEngine;


namespace JsonSchemas.Requests
{
    /// <summary>
    /// Node part API. Registration & authentification
    /// </summary>
    [Serializable]
    public class MessageConnect
    {
        public string nickname;

        public MessageConnect()
        {
            nickname = PlayerPrefs.GetString(StrPrefs.nickname.ToString());
        }
    }
}