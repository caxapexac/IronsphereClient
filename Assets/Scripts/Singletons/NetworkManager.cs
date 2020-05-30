using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using GuiConcreteComponents;
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
        // Ws is working on another thread! 
        public WebSocket Ws = null;

        public ConcurrentQueue<string> EventQueue;

        public List<string> Users;

        private void Awake()
        {
            EventQueue = new ConcurrentQueue<string>();
        }

        private void Start()
        {
            ConnectToServer();
        }

        private void Update()
        {
            if (!EventQueue.IsEmpty)
            {
                if (EventQueue.TryDequeue(out string result))
                {
                    Debug.Log("Try " + result);
                    j_typed response = JsonManager.Deserialize(result);
                    Debug.Log(response.GetType() + " " + result);
                    response.Execute();
                }
            }
        }

        public bool IsConnected()
        {
            return Ws != null && Ws.GetState() == WebSocketState.Open;
        }
        
        public void ConnectToServer() 
        {
            if (IsConnected()) return;
            string ip = PlayerPrefsWrapper.Get(StrPrefs.server_ip);
            try
            {
                Ws = WebSocketFactory.CreateInstance($"ws://{ip}");
            }
            catch (Exception e)
            {
                MessageBox.Error($"WebSocketFactory exception: {e.Message}");
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
                MessageBox.Error($"You are not connected (trying to send {message})");
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
            return God.NetworkManager.Users[playerId];
        }

        private void WsOnOpen()
        {
            Debug.Log("WS opened");
        }

        private void WsOnMessage (byte[] data)
        {
            string message = Encoding.UTF8.GetString(data);
            EventQueue.Enqueue(message);
        }

        private void WsOnError (string errMsg)
        {
            MessageBox.Error($"WebSocket error: {errMsg}");
        }

        private void WsOnClose (WebSocketCloseCode code)
        {
            MessageBox.Info($"WebSocket closed with code: {code}");
        }

        private void OnDestroy()
        {
            if (God.NetworkManager == this && IsConnected()) Ws.Close();
        }
    }
}