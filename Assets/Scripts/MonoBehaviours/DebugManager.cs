using System;
using JsonSchemas;
using Network;
using Newtonsoft.Json;
using Singletons;
using Static;
using ThirdParty;
using UnityEngine;


namespace MonoBehaviours
{
    public class DebugManager : MonoBehaviour
    {
        private void Start()
        {
            
        }
        
        public void Update ()
        {
            
        }

        public void LogIn()
        {
            God.NetworkManager.ConnectToServer();
        }
        
        public void ServerInfo()
        {
            in_server_info data = new in_server_info();
            God.NetworkManager.Send(JsonManager.Serialize(data));
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
        
        [ContextMenu("Clear Player Prefs")]
        public void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
