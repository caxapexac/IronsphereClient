using System;
using CaxapCommon.Enums;
using CaxapCommon.Wrappers;
using GuiConcreteComponents;
using JsonSchemas;
using Singletons;
using UnityEngine;


namespace MonoBehaviours
{
    public class DebugManager : MonoBehaviour
    {
        public AudioSource Geiger;

        private void Awake()
        {
            Geiger = GetComponent<AudioSource>();
        }

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
            
            if (Input.GetKeyDown(KeyCode.F12) && Input.GetKey(KeyCode.F2))
            {
                PlayerPrefs.DeleteAll();
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                God.NetworkManager.Send(new in_game_info());
            }
        }

        public void PlayShot()
        {
            Geiger.Play();
        }

        [ContextMenu("Clear Player Prefs")]
        public void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
