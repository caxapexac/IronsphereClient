using System.Collections.Generic;
using JsonSchemas;
using MonoBehaviours;
using Singletons;
using Static;
using TMPro;
using UnityEngine;


namespace HelpersConcreteComponents
{
    public class SessionInfoPanel : MonoBehaviour
    {
        public TMP_Text SessionName;
        public TMP_Text SessionData; // TODO

        private static SessionInfoPanel _instance;

        private float _lastUpdateTime;

        private void Awake()
        {
            _instance = this;
            _lastUpdateTime = Time.time;
        }

        private void Start()
        {
            UpdateData();
        }

        private void Update()
        {
            if (Time.time - _lastUpdateTime > Constants.SlowUpdateDelay)
            {
                _lastUpdateTime = Time.time;
                UpdateData();
            }
        }

        public static void UpdateData()
        {
            in_game_info.Send();
        }

        public static void DrawPanel(abstract_game game)
        {
            if (!_instance) return;
            session current = SessionScrollList.GetSessionByID(PlayerPrefsWrapper.Get(IntPrefs.session_id));
            if (current == null)
            {
                _instance.ClearPanel();
            }
            else
            {
                _instance.SessionName.text = current.session_name;

                // TODO
                _instance.SessionData.text = "";
                _instance.SessionData.text += "Users\n";
                foreach (KeyValuePair<int, player> player in game.players)
                {
                    _instance.SessionData.text += $"{God.NetworkManager.GetUsernameById(player.Key)} team: {player.Value.team}\n";
                }
                _instance.SessionData.text += $"State {current.state.GetType()}\n";
                _instance.SessionData.text += game.tilemap.GetData();
                // TODO
            }
        }

        private void ClearPanel()
        {
            SessionName.text = "";
            SessionData.text = "";
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}