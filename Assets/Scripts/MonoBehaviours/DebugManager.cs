using System;
using JsonSchemas;
using Network;
using Newtonsoft.Json;
using UnityEngine;


namespace MonoBehaviours
{
    public class DebugManager : MonoBehaviour
    {
        private void Start()
        {
            //JsonManager.TestNetwork();
        }
        
        public void Update ()
        {
            
        }

        public void LogIn()
        {
            
        }
        
        public void ServerInfo()
        {
            in_server_info data = new in_server_info();
            NetworkManager.Ws.SendString(JsonManager.Serialize(data));
        }
        
        public void GameInfo()
        {
            
        }

        public void Load (string input) 
        {
            
        }
    
        public void Save ()
        {
    
        }
    
        public void Join (string input) 
        {
    
        }
    
        public void Quit (string input) 
        {
    
        }
    
        public void Play () 
        {
    
        }
    
        public void Pause ()
        {
    
        }
    
        public void Stop () 
        {
    
        }
    
        public void Setup (string input) 
        {
    
        }

        public void Signal (string input)
        {
    
        }
    }
}
