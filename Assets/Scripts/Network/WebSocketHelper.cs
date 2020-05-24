using System.Text;
using HybridWebSocket;
using UnityEngine;

namespace Network
{
    public static class WebSocketHelper
    {
        // Only for example!
        public static WebSocket Init(string url)
        {
            WebSocket ws = WebSocketFactory.CreateInstance(url);
            
            ws.OnOpen += () =>
            {
                Debug.Log($"WS connected! State: {ws.GetState()}");
            };

            ws.OnMessage += (byte[] data) =>
            {
                string message = Encoding.UTF8.GetString(data);
                Debug.Log("WS received message: " + data);
            };

            ws.OnError += (string errMsg) =>
            {
                Debug.LogError("WS error: " + errMsg);
            };

            ws.OnClose += (WebSocketCloseCode code) =>
            {
                Debug.LogError("WS closed with code: " + code.ToString());
            };

            ws.Connect();
            return ws;
        }
        
        public static void SendString(this WebSocket ws, string data)
        {
            ws.Send(Encoding.UTF8.GetBytes (data));
        }
    }
}