using System;
using GuiConcreteComponents;
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
            if (Input.GetKeyDown(KeyCode.P))
            {
                MessageBox.Info($"PlayerPrefs:\n"
                    + $"{StrPrefs.input_message.ToString()} {PlayerPrefsWrapper.Get(StrPrefs.input_message)}\n"
                    + $"{StrPrefs.input_nickname.ToString()} {PlayerPrefsWrapper.Get(StrPrefs.input_nickname)}\n"
                    + $"{StrPrefs.server_ip.ToString()} {PlayerPrefsWrapper.Get(StrPrefs.server_ip)}\n"
                    + $"{StrPrefs.input_session_name.ToString()} {PlayerPrefsWrapper.Get(StrPrefs.input_session_name)}\n"
                    + $"{IntPrefs.chat_buffer_updates.ToString()} {PlayerPrefsWrapper.Get(IntPrefs.chat_buffer_updates)}\n"
                    + $"{IntPrefs.sender.ToString()} {PlayerPrefsWrapper.Get(IntPrefs.sender)}\n"
                    + $"{IntPrefs.session_id.ToString()} {PlayerPrefsWrapper.Get(IntPrefs.session_id)}\n");
            }
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
