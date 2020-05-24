using System.Text;
using HybridWebSocket;
using JsonSchemas;
using JsonSchemas.Requests;
using Network;
using UnityEngine;


namespace MonoBehaviours
{
    public class NetworkManager : MonoBehaviour
    {
        public WebSocket Ws = null;
        
        public void ConnectToServer() 
        {
            string ip = PlayerPrefs.GetString(PlayerPrefs.GetString(StrPrefs.server_ip.ToString()));
            Ws = WebSocketFactory.CreateInstance($"ws://{ip}");
            
            God.I.Ws = WebSocketHelper.Init($"ws://{ip}");
            
            Ws.OnOpen += WsOnOpen;
            Ws.OnMessage += WsOnMessage;
            Ws.OnError += WsOnError;
            Ws.OnClose += WsOnClose;
            Ws.Connect();

            MessageConnect request = new MessageConnect {nickname = PlayerPrefs.GetString(StrPrefs.nickname.ToString())};
            God.I.Ws.SendString(JsonUtility.ToJson(request));
        }

        private void WsOnOpen()
        {
            Debug.Log("WS opened");
        }

        private void WsOnMessage (byte[] data)
        {
            string message = Encoding.UTF8.GetString(data);
            Debug.Log("WS received message: " + data);
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
            Debug.LogError("WS error: " + errMsg);
        }

        private void WsOnClose (WebSocketCloseCode code)
        {
            Debug.Log("WS closed with code: " + code);
        }
    }
}