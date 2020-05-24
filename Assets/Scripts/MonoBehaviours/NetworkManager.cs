using System;
using System.Text;
using HybridWebSocket;
using JsonSchemas;
using JsonSchemas.Requests;
using Network;
using Newtonsoft.Json;
using UnityEngine;


namespace MonoBehaviours
{
    public class NetworkManager : MonoBehaviour
    {
        public static WebSocket Ws = null;

        public string Nickname;
        
        public void ConnectToServer() 
        {
            string ip = PlayerPrefs.GetString(StrPrefs.server_ip.ToString());
            Nickname = PlayerPrefs.GetString(StrPrefs.nickname.ToString());

            Ws = WebSocketFactory.CreateInstance($"ws://{ip}");
            Ws.OnOpen += WsOnOpen;
            Ws.OnMessage += WsOnMessage;
            Ws.OnError += WsOnError;
            Ws.OnClose += WsOnClose;
            Ws.Connect();
        }

        private void WsOnOpen()
        {
            Debug.Log("WS opened");
            in_connect request = new in_connect {nickname = Nickname};
            Ws.SendString(JsonManager.Serialize(request));
        }

        private void WsOnMessage (byte[] data)
        {
            string message = Encoding.UTF8.GetString(data);
            Debug.Log("WS received message: " + message);
            if (int.TryParse(message, out int result))
            {
                // Authentification process completed
                PlayerPrefs.SetInt(IntPrefs.sender.ToString(), result);
                return;
            }
            
            // TODO checking type of response
        }

        private void WsOnError (string errMsg)
        {
            Debug.Log("WS error: " + errMsg); // TODO messagebox
        }

        private void WsOnClose (WebSocketCloseCode code)
        {
            Debug.Log("WS closed with code: " + code); // TODO messagebox
        }
        
        private void OnDestroy()
        {
            Ws.Close();
        }
    }
}