using System;
using System.Collections.Generic;
using System.Text;
using HybridWebSocket;
using JsonSchemas;
using MonoBehaviours;
using Static;
using ThirdParty;
using UnityEngine;


namespace Singletons
{
    public class NetworkManager : MonoBehaviour
    {
        public WebSocket Ws = null;

        public string Nickname; // Because is crashes if I try to get it in OnOpen

        public List<string> Users;

        public bool IsConnected()
        {
            return Ws != null && Ws.GetState() == WebSocketState.Open;
        }
        
        public void ConnectToServer() 
        {
            if (IsConnected()) return;
            string ip = PlayerPrefs.GetString(StrPrefs.server_ip.ToString());
            Nickname = PlayerPrefs.GetString(StrPrefs.nickname.ToString());

            try
            {
                Ws = WebSocketFactory.CreateInstance($"ws://{ip}");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return;
            }
            
            Ws.OnOpen += WsOnOpen;
            Ws.OnMessage += WsOnMessage;
            Ws.OnError += WsOnError;
            Ws.OnClose += WsOnClose;
            Ws.Connect();
        }

        public void Send(string message)
        {
            if (!IsConnected())
            {
                Debug.Log("You are not connected");
                return;
            }
            Ws.SendString(message);
        }

        public string GetUsernameById(int playerId)
        {
            if (God.NetworkManager.Users.Count <= playerId)
            {
                in_connect.Send();
                return playerId.ToString(); // TODO
            }
            else
            {
                return God.NetworkManager.Users[playerId];
            }
        }

        private void WsOnOpen()
        {
            Debug.Log("WS opened");
            in_connect.Send();
        }

        private void WsOnMessage (byte[] data)
        {
            string message = Encoding.UTF8.GetString(data);
            j_typed response = JsonManager.Deserialize(message);
            response.Execute();
        }

        private void WsOnError (string errMsg)
        {
            Debug.LogWarning("WS error: " + errMsg); // TODO messagebox
        }

        private void WsOnClose (WebSocketCloseCode code)
        {
            Debug.LogWarning("WS closed with code: " + code); // TODO messagebox
        }

        private void OnDestroy()
        {
            if (IsConnected()) Ws.Close();
        }
    }
}