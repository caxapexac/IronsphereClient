using System;
using JsonSchemas;
using MonoBehaviours;
using Static;
using UnityEngine;
using UnityEngine.UI;


namespace HelpersComponents
{
    public class ButtonToIntPlayerPrefsBinder : MonoBehaviour
    {
        public IntPrefs KeySholdExist;
        public Requests Request;

        private Button _button;
        
        public void Awake()
        {
            _button = GetComponent<Button>();
            switch (Request)
            {
                case Requests.in_connect:
                    _button.onClick.AddListener(in_connect.Send);
                    break;
                case Requests.in_server_info:
                    _button.onClick.AddListener(in_server_info.Send);
                    break;
                case Requests.in_read_chat:
                    _button.onClick.AddListener(in_read_chat.Send);
                    break;
                case Requests.in_write_chat:
                    _button.onClick.AddListener(in_write_chat.Send);
                    break;
                case Requests.in_create_session:
                    _button.onClick.AddListener(in_create_session.Send);
                    break;
                case Requests.in_game_info:
                    _button.onClick.AddListener(in_game_info.Send);
                    break;
                case Requests.in_game_load:
                    _button.onClick.AddListener(in_game_load.Send);
                    break;
                case Requests.in_game_save:
                    _button.onClick.AddListener(in_game_save.Send);
                    break;
                case Requests.in_game_join:
                    _button.onClick.AddListener(in_game_join.Send);
                    break;
                case Requests.in_game_quit:
                    _button.onClick.AddListener(in_game_quit.Send);
                    break;
                case Requests.in_game_play:
                    _button.onClick.AddListener(in_game_play.Send);
                    break;
                case Requests.in_game_pause:
                    _button.onClick.AddListener(in_game_pause.Send);
                    break;
                case Requests.in_game_stop:
                    _button.onClick.AddListener(in_game_stop.Send);
                    break;
                case Requests.in_game_setup:
                    _button.onClick.AddListener(in_game_setup.Send);
                    break;
                case Requests.in_game_signal:
                    _button.onClick.AddListener(in_game_signal.Send);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _button.interactable = PlayerPrefsWrapper.Get(KeySholdExist) != 0;
            PlayerPrefsWrapper.IntPrefsChanged += ValueChanged;
        }

        private void ValueChanged(object sender, (IntPrefs, int) data)
        {
            Debug.Log(data.Item1 + " " + data.Item2);
            if (data.Item1 == KeySholdExist) _button.interactable = data.Item2 != 0;
        }

        private void OnDestroy()
        {
            PlayerPrefsWrapper.IntPrefsChanged -= ValueChanged;
        }
    }
}